///////////////////////////////////////////////////////////////////////////////
///
/// File: IntegrityPatches.cs
/// Revision: 2
/// Author: JRoeseph
/// Description: The patches to SoG that handle maintaining game integrity
///     between checked locations and the lack of items/events received from
///     doing so (i.e. making sure cards don't keep dropping and quest items
///     only drop once).
/// 
///////////////////////////////////////////////////////////////////////////////
using HarmonyLib;
using SoG;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

public static class InjectedIntegrityFunctions
{
    public static bool CheckCardLocation(bool bCardRoll, Enemy xEnemy)
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
}

[HarmonyPatch(typeof(Game1))]
[HarmonyPatch(nameof(Game1._Enemy_DropLoot))]
public static class CardDupePatch
{
    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
    {
        CodeMatcher codeMatcher = new CodeMatcher(instructions);

        codeMatcher.MatchStartForward(new CodeMatch(OpCodes.Ldstr, "GuaranteeCards"))
            .MatchEndBackwards(new CodeMatch(OpCodes.Clt));

        if (codeMatcher.IsInvalid)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Out.WriteLine("[CardDupePatch] Transpiler Error: Failed to locate proper instructions");
            Console.ResetColor();

            return instructions;
        }
            
        
        codeMatcher.InsertAfterAndAdvance(new CodeInstruction(OpCodes.Ldarg_1))
            .InsertAfterAndAdvance(new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(InjectedIntegrityFunctions),nameof(InjectedIntegrityFunctions.CheckCardLocation))));

        return codeMatcher.Instructions();
    }
}