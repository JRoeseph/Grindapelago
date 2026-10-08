///////////////////////////////////////////////////////////////////////////////
///
/// File: IntegrityPatches.cs
/// Author: JRoeseph
/// Description: The patches to SoG that handle maintaining game integrity
///     between checked locations and the lack of items/events received from
///     doing so (i.e. making sure cards don't keep dropping and quest items
///     only drop once).
/// 
///////////////////////////////////////////////////////////////////////////////
using HarmonyLib;
using SoG;
using System.Collections.Generic;
using System.Reflection.Emit;

public static class InjectedIntegrityFunctions
{
    public static bool DisableDupeLoc(bool bCardRoll, Enemy xEnemy)
    {
        
        if (!bCardRoll)
        {
            return false;
        }

        EnemyCodex.EnemyTypes enTypeToUse = ((xEnemy.xEnemyDescription.enCardTypeOverride == EnemyCodex.EnemyTypes.Null) ? xEnemy.enType : xEnemy.xEnemyDescription.enCardTypeOverride);
        string LocationName;
        LocationDictionaries.CardDictionary.TryGetValue(enTypeToUse, out LocationName);
        bool bLocationFound = false;
        if (LocationName != null && Grindapelago.CheckedLocations.TryGetValue(LocationName, out bLocationFound) && bLocationFound)
        {
            return false;
        }

        return true;
    }

    public static List<PlayerView> EnableDupeItem(List<PlayerView> lxEligibleViews, Enemy xEnemy)
    {
        if (!lxEligibleViews.Contains(Grindapelago.Game.xLocalPlayer))
        {
            lxEligibleViews.Add(Grindapelago.Game.xLocalPlayer);
        }
        return lxEligibleViews;
    }
}

[HarmonyPatch(typeof(Game1))]
[HarmonyPatch(nameof(Game1._Enemy_DropLoot))]
public static class CardDupePatch
{
    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
    {
        CodeMatcher codeMatcher = new CodeMatcher(instructions);

        // Patch to stop dropping cards when location is checked, even when card is not collected
        codeMatcher.MatchStartForward(new CodeMatch(OpCodes.Ldstr, "GuaranteeCards"))
            .MatchEndBackwards(new CodeMatch(OpCodes.Clt));

        if (codeMatcher.IsInvalid)
        {
            Logger.Log("[CardDupePatch] Transpiler Error: Failed to locate instructions for disabling cards when checked", LoggerVerbosity.Error);

            return instructions;
        }
            
        codeMatcher.InsertAfterAndAdvance(new CodeInstruction(OpCodes.Ldarg_1))
            .InsertAfterAndAdvance(new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(InjectedIntegrityFunctions),nameof(InjectedIntegrityFunctions.DisableDupeLoc))));

        // Patch to keep dropping cards when location is not checked, even when card is collected
        codeMatcher.MatchStartForward(
            new CodeMatch(instruction => instruction.opcode == OpCodes.Ldloc_S
                            && instruction.operand is LocalBuilder builder
                            && builder.LocalIndex == 94),
            new CodeMatch(OpCodes.Callvirt),
            new CodeMatch(OpCodes.Ldc_I4_0));

        if (codeMatcher.IsInvalid)
        {
            Logger.Log("[CardDupePatch] Transpiler Error: Failed to locate instructions for enabling cards while in deck", LoggerVerbosity.Error);

            return instructions;
        }
        
        codeMatcher.InsertAfterAndAdvance(new CodeInstruction(OpCodes.Ldarg_1))
            .InsertAfterAndAdvance(new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(InjectedIntegrityFunctions), nameof(InjectedIntegrityFunctions.EnableDupeItem))));

        return codeMatcher.Instructions();
    }
}