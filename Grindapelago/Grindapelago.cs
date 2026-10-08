///////////////////////////////////////////////////////////////////////////////
///
/// File: Grindapelago.cs
/// Author: JRoeseph
/// Description: Main project file that contains persistent logic for the
///     client.
/// 
///////////////////////////////////////////////////////////////////////////////
using HarmonyLib;
using Quests;
using SoG;
using System.Collections.Generic;

// TODO: Remove all //DEBUG/TESTING CODE across entire project once no longer needed

public static class Grindapelago
{
    public static Game1 Game = null;

    // YAML Config
    public static int CardKillsPerKill = 5;
    public static int LootMultiplier = 3;
    public static bool InfinitePickupRange = true;

    // Client Config
    public static LoggerVerbosity ChatVerbosity = LoggerVerbosity.UserChecks;
    public static LoggerVerbosity ConsoleVerbosity = LoggerVerbosity.AllChecks;
    public static LoggerVerbosity LogFileVerbosity = LoggerVerbosity.AllChecks;

    public static void Init()
    {
        var harmony = new Harmony("com.jroeseph.grindapelago");
        harmony.PatchAll(typeof(Grindapelago).Assembly);
        Logger.Init();
    }

    public static void GetVanillaItem(string LocationDiscovered)
    {
        string VanillaItemID = LocationDictionaries.VanillaLocationDictionary[LocationDiscovered];
        Logger.Log($"[Grindapelago] Checked Location: {LocationDiscovered}", LoggerVerbosity.UserChecks);
        CollectItem(VanillaItemID);
    }

    public static void CollectItem(string ArchiItemID)
    {
        ArchiItem ArchiItemObj = null;
        if (ArchiItemDictionary.TryGetValue(ArchiItemID, out ArchiItemObj))
        {
            ArchiItemObj.Collect();
            Logger.Log($"[Grindapelago] Collected Item: {ArchiItemID}", LoggerVerbosity.UserChecks);
        }
        else
        {
            Logger.Log($"[Grindapelago] Failed to find item with ID: {ArchiItemID}", LoggerVerbosity.Error);
        }
    }

    public static Dictionary<string, ArchiItem> ArchiItemDictionary = new Dictionary<string, ArchiItem>()
    {
        { "Wooden Sword", new ArchiItemItem(ItemCodex.ItemTypes._OneHanded_WoodenSword, 1)},
        { "Stick", new ArchiItemItem(ItemCodex.ItemTypes._TwoHanded_Stick, 1)},
        { "Green Slime Cube", new ArchiItemItem(ItemCodex.ItemTypes._Misc_SlimeCube, 1)},
        { "Wooden Bow", new ArchiItemItem(ItemCodex.ItemTypes._Bow_WoodenBow, 1)},
        { "Quiver", new ArchiItemItem(ItemCodex.ItemTypes._KeyItem_Quiver, 1)},
        { "Strawboater", new ArchiItemItem(ItemCodex.ItemTypes._Hat_Strawboater, 1)},
        { "Wooden Shield", new ArchiItemItem(ItemCodex.ItemTypes._Shield_WoodenShield, 1)},
        { "Toy Wand", new ArchiItemItem(ItemCodex.ItemTypes._OneHanded_ToyWand, 1)},
        { "Sandals", new ArchiItemItem(ItemCodex.ItemTypes._Shoes_Sandals, 1)},
        { "200g", new ArchiItemGold(200)},
        { "Iron Sword", new ArchiItemItem(ItemCodex.ItemTypes._OneHanded_IronSword, 1)},
        { "Claymore", new ArchiItemItem(ItemCodex.ItemTypes._TwoHanded_Claymore, 1)},
        { "Staff", new ArchiItemItem(ItemCodex.ItemTypes._TwoHanded_Staff, 1)},
        { "Adventure Shirt", new ArchiItemItem(ItemCodex.ItemTypes._Armor_AdventureShirt, 1)},
        { "Level 4 Boss XP Reward", new ArchiItemXP(4, EnemyDescription.Category.Boss)},
        { "Talent Orb", new ArchiItemPoint(SkillPointReward.SkillPointType.Talent, 1)},
        { "Green Slime Card", new ArchiItemCard(EnemyCodex.EnemyTypes.GreenSlime)},
        { "Red Slime Card", new ArchiItemCard(EnemyCodex.EnemyTypes.RedSlime)},
        { "Rabbi Card", new ArchiItemCard(EnemyCodex.EnemyTypes.Rabbi)},
        { "Mrs Bee Card", new ArchiItemCard(EnemyCodex.EnemyTypes.Bee)},
        { "Bloomo Card", new ArchiItemCard(EnemyCodex.EnemyTypes.Blomma)},
        { "Boar Card", new ArchiItemCard(EnemyCodex.EnemyTypes.Boar)},
        { "Jumpkin Card", new ArchiItemCard(EnemyCodex.EnemyTypes.Pumpkin)},
        { "Lantern Jack Card", new ArchiItemCard(EnemyCodex.EnemyTypes.PyroPumpkin)},
        { "Scarecrow Card", new ArchiItemCard(EnemyCodex.EnemyTypes.Scarecrow)},
        { "Halloweed Card", new ArchiItemCard(EnemyCodex.EnemyTypes.Halloweed)},
        { "Ghosty Card", new ArchiItemCard(EnemyCodex.EnemyTypes.Ghosty)},
        { "Wisp Card", new ArchiItemCard(EnemyCodex.EnemyTypes.Wisp)},
        { "Pecko Card", new ArchiItemCard(EnemyCodex.EnemyTypes.Pecko)},
        { "Guardian Card", new ArchiItemCard(EnemyCodex.EnemyTypes.Guardian)},
        { "Brawler Bot Card", new ArchiItemCard(EnemyCodex.EnemyTypes.BrawlerBot)},
        { "Blue Slime Card", new ArchiItemCard(EnemyCodex.EnemyTypes.BlueSlime)},
        { "Frostling Rogue Card", new ArchiItemCard(EnemyCodex.EnemyTypes.FrostlingRogue)},
        { "Frostling Scoundrel Card", new ArchiItemCard(EnemyCodex.EnemyTypes.FrostlingScoundrel)},
        { "Yeti Card", new ArchiItemCard(EnemyCodex.EnemyTypes.Yeti)},
        { "Gift Card", new ArchiItemCard(EnemyCodex.EnemyTypes.GiftBoxMelee)},
        { "Present Card", new ArchiItemCard(EnemyCodex.EnemyTypes.GiftBoxRanged)},
        { "Season Mage Card", new ArchiItemCard(EnemyCodex.EnemyTypes.SeasonMage_CardEntry)},
        { "Season Knight Card", new ArchiItemCard(EnemyCodex.EnemyTypes.SeasonKnight_CardEntry)},
        { "Spinsect Card", new ArchiItemCard(EnemyCodex.EnemyTypes.MtBloom_CrystalBeetle)},
        { "Shroomie Card", new ArchiItemCard(EnemyCodex.EnemyTypes.MtBloom_Shroom)},
        { "Larvacid Card", new ArchiItemCard(EnemyCodex.EnemyTypes.MtBloom_Larva)},
        { "Toxic Tulip Card", new ArchiItemCard(EnemyCodex.EnemyTypes.MtBloom_PoisonFlower)},
        { "Thorn Worm Card", new ArchiItemCard(EnemyCodex.EnemyTypes.TimeTemple_Worm)},
        { "Ancient Statue Card", new ArchiItemCard(EnemyCodex.EnemyTypes.TimeTemple_Statue)},
        { "Plantae Hostilis Card", new ArchiItemCard(EnemyCodex.EnemyTypes.TimeTemple_Moss)},
        { "Echo of Madness Card", new ArchiItemCard(EnemyCodex.EnemyTypes.TimeTemple_Echo)},
        { "Monkey Card", new ArchiItemCard(EnemyCodex.EnemyTypes.TimeTemple_Monkey)},
        { "Cacute Card", new ArchiItemCard(EnemyCodex.EnemyTypes.Desert_Cacute)},
        { "Sand Raven Card", new ArchiItemCard(EnemyCodex.EnemyTypes.Desert_Bird)},
        { "Orange Slime Card", new ArchiItemCard(EnemyCodex.EnemyTypes.Desert_OrangeSlime)},
        { "Solem Card", new ArchiItemCard(EnemyCodex.EnemyTypes.Desert_Solem)},
        { "Living Veggies Card", new ArchiItemCard(EnemyCodex.EnemyTypes.Desert_VegetableCardEntry)},
        { "Crabby Card", new ArchiItemCard(EnemyCodex.EnemyTypes.GhostShip_Crabby)},
        { "Skeleton Warrior Card", new ArchiItemCard(EnemyCodex.EnemyTypes.GhostShip_Skeleton)},
        { "Skeleton Wizard Card", new ArchiItemCard(EnemyCodex.EnemyTypes.GhostShip_Wizard)},
        { "Hauntie Card", new ArchiItemCard(EnemyCodex.EnemyTypes.GhostShip_Hauntie)},
    };

    public static Dictionary<string, bool> CheckedLocations = new Dictionary<string, bool>
    {
        //NPC Checks
        { "Mrs Wourie", false },
        { "Grandpa Joe - Intro", false },
        { "Luke - After Collector's Exam", false },
        { "Robin - First Bow", false },
        { "Robin - 10K Points", false },
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
        { "Southern Fields West Chest", false },
        //Quest Checks
        { "Road to the City", false },
        { "The Collector's Exam", false },
        { "The Ancient Temple", false },
        //Card Checks
        { "Green Slime Card Drop", false },
        { "Red Slime Card Drop", false },
        { "Rabbi Card Drop", false },
        { "Mrs Bee Card Drop", false },
        { "Bloomo Card Drop", false },
        { "Boar Card Drop", false },
        { "Jumpkin Card Drop", false },
        { "Lantern Jack Card Drop", false },
        { "Scarecrow Card Drop", false },
        { "Halloweed Card Drop", false },
        { "Ghosty Card Drop", false  },
        { "Wisp Card Drop", false },
        { "Pecko Card Drop", false },
        { "Guardian Card Drop", false },
        { "Brawler Bot Card Drop", false },
        { "Blue Slime Card Drop", false },
        { "Frostling Rogue Card Drop", false },
        { "Frostling Scoundrel Card Drop", false },
        { "Yeti Card Drop", false },
        { "Gift Card Drop", false },
        { "Present Card Drop", false },
        { "Season Mage Card Drop", false },
        { "Season Knight Card Drop", false },
        { "Spinsect Card Drop", false },
        { "Shroomie Card Drop", false },
        { "Larvacid Card Drop", false },
        { "Toxic Tulip Card Drop", false },
        { "Thorn Worm Card Drop", false },
        { "Ancient Statue Card Drop", false },
        { "Plantae Hostilis Card Drop", false },
        { "Echo of Madness Card Drop", false },
        { "Monkey Card Drop", false },
        { "Cacute Card Drop", false },
        { "Sand Raven Card Drop", false },
        { "Orange Slime Card Drop", false },
        { "Solem Card Drop", false },
        { "Living Veggies Card Drop", false },
        { "Crabby Card Drop", false },
        { "Skeleton Warrior Card Drop", false },
        { "Skeleton Wizard Card Drop", false },
        { "Hauntie Card Drop", false },
    };
}

[HarmonyPatch(typeof(Game1))]
[HarmonyPatch(nameof(Game1._GameLoading_LoadLocalCharacter))]
public static class GameInstancePatch
{
    static bool Prefix(Game1 __instance)
    {
        Grindapelago.Game = __instance;
        return true;
    }
}