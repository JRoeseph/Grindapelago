///////////////////////////////////////////////////////////////////////////////
///
/// File: Grindapelago.cs
/// Revision: 1
/// Author: JRoeseph
/// Description: Main project file that contains persistent logic for the
///     client.
/// 
///////////////////////////////////////////////////////////////////////////////
using HarmonyLib;
using SoG;
using System.Collections.Generic;

// TODO: Remove all //DEBUG/TESTING CODE across entire project once no longer needed

public class Grindapelago
{
    public static void Init()
    {
        var harmony = new Harmony("com.jroeseph.grindapelago");
        harmony.PatchAll(typeof(Grindapelago).Assembly);
    }
}

[HarmonyPatch(typeof(Game1))]
[HarmonyPatch(nameof(Game1._GameLoading_LoadLocalCharacter))]
public static class TheGame
{
    public static Game1 Instance;

    static bool Prefix(Game1 __instance)
    {
        Instance = __instance;
        return true;
    }

    public static Dictionary<string, bool> CheckedLocations = new Dictionary<string, bool>
        {
            //NPC Checks
            { "Mrs Wourie", false },
            { "Grandpa Joe - Intro", false },
            { "Luke - After Collector's Exam", false },
            //Cutscene Checks
            { "Collector's Exam Completed", false },
            //Chest Checks
            { "Startington Cave Chest", false },
            { "Upper Pillar Mountains Chest", false },
            { "Middle Pillar Mountains Cave Chest", false },
            { "Lower Pillar Mountains Chest", false },
            { "Left Arena Waiting Room Chest", false },
            { "Center Arena Waiting Room Chest", false },
            { "Right Arena Waiting Room Chest", false },
            //Quest Checks
            { "Road to the City", false },
            { "The Collector's Exam", false },
            { "The Ancient Temple", false },
            //Card Checks
            { "Green Slime Card", false },
            { "Red Slime Card", false },
            { "Rabbi Card", false },
            { "Mrs Bee Card", false },
            { "Bloomo Card", false },
            { "Boar Card", false },
            { "Jumpkin Card", false },
            { "Lantern Jack Card", false },
            { "Scarecrow Card", false },
            { "Halloweed Card", false },
            { "Ghosty Card", false  },
            { "Wisp Card", false },
            { "Pecko Card", false },
            { "Guardian Card", false },
            { "Brawler Bot Card", false },
            { "Blue Slime Card", false },
            { "Frostling Rogue Card", false },
            { "Frostling Scoundrel Card", false },
            { "Yeti Card", false },
            { "Gift Card", false },
            { "Present Card", false },
            { "Season Mage Card", false },
            { "Season Knight Card", false },
            { "Spinsect Card", false },
            { "Shroomie Card", false },
            { "Larvacid Card", false },
            { "Toxic Tulip Card", false },
            { "Thorn Worm Card", false },
            { "Ancient Statue Card", false },
            { "Plantae Hostilis Card", false },
            { "Echo of Madness Card", false },
            { "Monkey Card", false },
            { "Cacute Card", false },
            { "Sand Raven Card", false },
            { "Orange Slime Card", false },
            { "Solem Card", false },
            { "Living Veggies Card", false },
            { "Crabby Card", false },
            { "Skeleton Warrior Card", false },
            { "Skeleton Wizard Card", false },
            { "Hauntie Card", false },
        };
}