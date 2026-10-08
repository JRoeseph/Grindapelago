///////////////////////////////////////////////////////////////////////////////
///
/// File: ConveniencePatches.cs
/// Author: JRoeseph
/// Description: The patches to SoG that modify the game to make it easier for
///     an Archipelago player like increasing pickup distance or increasing
///     card drop rate.
/// 
///////////////////////////////////////////////////////////////////////////////
using HarmonyLib;
using SoG;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

[HarmonyPatch(typeof(Game1))]
[HarmonyPatch(nameof(Game1._Enemy_DropLoot))]
public static class CardChancePatch
{
    public static bool Prefix(Game1 __instance, ref Enemy xEnemy)
    {
        xEnemy.fLootMultiplier *= Grindapelago.LootMultiplier;
        return true;
    }

    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
    {
        if (Grindapelago.CardKillsPerKill == 1)
        {
            return instructions;
        }

        CodeMatcher codeMatcher = new CodeMatcher(instructions);
        codeMatcher.MatchStartForward(
            new CodeMatch(OpCodes.Ldc_I4_1),
            new CodeMatch(instruction => instruction.opcode == OpCodes.Stloc_S
                            && instruction.operand is LocalBuilder builder
                            && builder.LocalIndex == 92));

        if (codeMatcher.IsInvalid)
        {
            Logger.Log("[CardChancePatch] Transpiler Error: Failed to locate instructions for card chance buffing", LoggerVerbosity.Error);

            return instructions;
        }

        codeMatcher.Set(OpCodes.Ldc_I4_S, (sbyte)Grindapelago.CardKillsPerKill);

        return codeMatcher.Instructions();
    }
}

[HarmonyPatch(typeof(Game1))]
[HarmonyPatch(nameof(Game1._Item_UpdatePostFall))]
public static class PickupRangePatch
{
    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
    {
        if (!Grindapelago.InfinitePickupRange)
        {
            return instructions;
        }

        CodeMatcher codeMatcher = new CodeMatcher(instructions);

        codeMatcher.MatchStartForward(new CodeMatch(OpCodes.Ldc_R4, (float)35));

        if (codeMatcher.IsInvalid)
        {
            Logger.Log("[PickupRangePatch] Transpiler Error: Failed to locate instructions for pickup range patch", LoggerVerbosity.Error);

            return instructions;
        }

        codeMatcher.SetAndAdvance(OpCodes.Ldc_R4, (float)420)
            .Advance()
            .Set(OpCodes.Ldc_R4, (float)20);

        return codeMatcher.Instructions();
    }
}