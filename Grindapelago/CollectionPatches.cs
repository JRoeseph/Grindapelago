///////////////////////////////////////////////////////////////////////////////
///
/// File: Collection Patches.cs
/// Revision: 2
/// Author: JRoeseph
/// Description: The patches that detect when certain locations are checked,
///     sending them via `ArchiConnector.cs`, and tracking them via 
///     `Grindapelago.cs`.
/// 
///////////////////////////////////////////////////////////////////////////////
using HarmonyLib;
using SoG;
using System;

[HarmonyPatch(typeof(Game1))]
[HarmonyPatch(nameof(Game1._Trigger_HandleTriggerEvent))]
[HarmonyPatch(new Type[] { typeof(FlagCodex.FlagID), typeof(byte) })]
public static class EventPatch
{
    static bool Prefix(Game1 __instance, ref bool __result, FlagCodex.FlagID enFlagID, byte bySubTrigger)
    {
        string LocationDiscovered;
        if (LocationDictionaries.EventDictionary.TryGetValue(enFlagID, out LocationDiscovered) 
                && !Grindapelago.CheckedLocations[LocationDiscovered])
        {
            Grindapelago.CheckedLocations[LocationDiscovered] = true;

            // Make sure this event isn't called again
            __instance.xGameSessionData.henActiveFlags.Add(enFlagID);
            __result = true;

            // Event specific logic
            if (enFlagID == FlagCodex.FlagID._Event_GetSlimeCubeFromLuke)
            {
                __instance._NPC_CheckForQuests();
            }

            //DEBUG/TESTING CODE START
            ArchiConnector.GetVanillaItem(LocationDiscovered);
            //DEBUG/TESTING CODE END

            // We handled the event manually, do not run the normal function
            return false;
        }
        return true;
    }
}

[HarmonyPatch(typeof(DialogueSystem))]
[HarmonyPatch(nameof(DialogueSystem.ProgressDialogue))]
public static class DialoguePatch
{
    static bool Prefix(DialogueSystem __instance)
    {
        if (__instance?.xCurrentDialogue?.lxDialogueLines == null)
        {
            return true;
        }

        // This is unintuitive. Because it's a prefix, and the ProgressDialogue option is what updates the actual current line
        // the real current line is actually the NEXT line after the listed current line. Doing it this way assures the check
        // goes through RIGHT when you WOULD have gotten the item. If the "current" line is null or not included (from another
        // dialogue), it means it is the first line
        string FakeCurrentLine = __instance?.xCurrentLine?.sUnparsedBaseLine;
        int RealCurrentLineIdx = 0;
        for (int i = 0; i < __instance?.xCurrentDialogue.lxDialogueLines.Count - 1; i++)
        {
            if (__instance?.xCurrentDialogue.lxDialogueLines[i].sUnparsedBaseLine == FakeCurrentLine)
            {
                RealCurrentLineIdx = i + 1;
            }
        }
        DialogueLine CurrentLine = __instance.xCurrentDialogue.lxDialogueLines[RealCurrentLineIdx];
        
        string LocationDiscovered;
        if (LocationDictionaries.DialogueDictionary.TryGetValue(CurrentLine.sUnparsedBaseLine, out LocationDiscovered)
                && !Grindapelago.CheckedLocations[LocationDiscovered])
        {
            Grindapelago.CheckedLocations[LocationDiscovered] = true;

            // Remove original item from dialogue
            foreach (string PreScript in CurrentLine.lsPreScripts)
            {
                if (PreScript.StartsWith("GiveItem"))
                {
                    CurrentLine.lsPreScripts.Remove(PreScript);
                    break;
                }
            }
            foreach (string PostScripts in CurrentLine.lsPostScripts)
            {
                if (PostScripts.StartsWith("GiveItem"))
                {
                    CurrentLine.lsPostScripts.Remove(PostScripts);
                    break;
                }
            }

            //DEBUG/TESTING CODE START
            ArchiConnector.GetVanillaItem(LocationDiscovered);
            //DEBUG/TESTING CODE END
        }

        return true;
    }
}

[HarmonyPatch(typeof(CutsceneControl))]
[HarmonyPatch(nameof(CutsceneControl.OnSkipped))]
public static class CutscenePatch
{
    static bool Prefix(CutsceneControl __instance)
    {
        if (__instance?.xActiveCutscene == null)
        {
            return true;
        }

        string LocationDiscovered;
        if (LocationDictionaries.CutsceneDictionary.TryGetValue(__instance.xActiveCutscene.enID, out LocationDiscovered)
                && !Grindapelago.CheckedLocations[LocationDiscovered])
        {
            Grindapelago.CheckedLocations[LocationDiscovered] = true;

            // Remove original item
            __instance.xActiveCutscene.lenItemGrantOnSkip.Clear();

            //DEBUG/TESTING CODE START
            ArchiConnector.GetVanillaItem(LocationDiscovered);
            //DEBUG/TESTING CODE END
        }

        return true;
    }
}

[HarmonyPatch(typeof(BasicChest))]
[HarmonyPatch(nameof(BasicChest.Update))]
public static class BasicChestPatch
{
    public static bool Prefix(BasicChest __instance)
    {
        // The Update function is called every game tick, but only handles open
        // logic once selected and OpenDelay is set off 0
        if (__instance.iOpenDelayLol == 0)
        {
            return true;
        }

        string LocationDiscovered;
        if (LocationDictionaries.BasicChestDictionary.TryGetValue(__instance.enFlagID, out LocationDiscovered)
                && !Grindapelago.CheckedLocations[LocationDiscovered])
        {
            Grindapelago.CheckedLocations[LocationDiscovered] = true;
            // Make sure this stops getting called
            __instance.iOpenDelayLol = 0;

            //DEBUG/TESTING CODE START
            ArchiConnector.GetVanillaItem(LocationDiscovered);
            //DEBUG/TESTING CODE END

            // We don't want the chest still giving the item
            return false;
        }

        return true;
    }
}

// Why does the game grant the quest rewards in the GUI renderer...
[HarmonyPatch(typeof(HudRenderComponent))]
[HarmonyPatch(nameof(HudRenderComponent.RenderBotGUI))]
public static class QuestPatch
{
    public static bool Prefix(HudRenderComponent __instance)
    {
        // For some stupid reason, marking quests as completed is handled by the GUI
        // Renderer (???) so we have to do some jank to inject here. Lot's of null
        // checking because there are a lot of null elements only non-null when in 
        // use, and we only want to overhaul them while in use
        GUIStuff xGuiStuff = Grindapelago.Game?.xLocalPlayer?.xGUIStuff;
        if (xGuiStuff == null || xGuiStuff.iQuestCompletedCounter == 0 ||
            xGuiStuff?.xThisQuestInstance?.enQuestID == null || xGuiStuff.xThisQuestDescription.xReward.bAwardGotLol)
        {
            return true;
        }

        string LocationDiscovered;
        if (LocationDictionaries.QuestDictionary.TryGetValue(xGuiStuff.xThisQuestInstance.enQuestID, out LocationDiscovered)
                && !Grindapelago.CheckedLocations[LocationDiscovered])
        {
            Grindapelago.CheckedLocations[LocationDiscovered] = true;
            // Telling the game we've already received the reward to not grant another
            xGuiStuff.xThisQuestDescription.xReward.bAwardGotLol = true;

            //DEBUG/TESTING CODE START
            ArchiConnector.GetVanillaItem(LocationDiscovered);
            //DEBUG/TESTING CODE END
        }


        return true;
    }
}

[HarmonyPatch(typeof(Journal.FakeCardAlbum))]
[HarmonyPatch(nameof(Journal.FakeCardAlbum.Add))]
public static class CardPatch
{
    public static bool Prefix(Game1 __instance, ref EnemyCodex.EnemyTypes enEnemyType, ref bool bAllowMoreThanOne)
    {
        string LocationDiscovered;
        if (LocationDictionaries.CardDictionary.TryGetValue(enEnemyType, out LocationDiscovered)
                && !Grindapelago.CheckedLocations[LocationDiscovered])
        {
            Grindapelago.CheckedLocations[LocationDiscovered] = true;

            //DEBUG/TESTING CODE START
            ArchiConnector.GetVanillaItem(LocationDiscovered);
            //DEBUG/TESTING CODE END

            // We do not want the player to actually get the card
            return false;
        }

        return true;
    }
}