///////////////////////////////////////////////////////////////////////////////
///
/// File: LocationDictionaries.cs
/// Author: JRoeseph
/// Description: Data that maps events, quests, etc. to their given location
///     names.
/// 
///////////////////////////////////////////////////////////////////////////////
using Quests;
using SoG;
using System.Collections.Generic;

public static class LocationDictionaries
{
    public static Dictionary<FlagCodex.FlagID, string> EventDictionary = new Dictionary<FlagCodex.FlagID, string>()
    {
        { FlagCodex.FlagID._Chest_00001_WoodenShield, "Startington Cave Chest" },
        { FlagCodex.FlagID._Event_GetSlimeCubeFromLuke, "Luke - After Collector's Exam" },
    };

    public static Dictionary<string, string> DialogueDictionary = new Dictionary<string, string>()
        {
            { "{c=goodnews}Congratulations!{/} You got your {c=item}sword{/} back!", "Mrs Wourie" },
            { "Then you should know that no adventure is complete without a bow! Here, take this.", "Robin - First Bow" },
            { "Woah?! [BOWSCORE] points?! That's amazing. Here, take this!", "Robin - 10K Points" },
        };

    public static Dictionary<CutsceneLibrary.CutsceneID, string> CutsceneDictionary = new Dictionary<CutsceneLibrary.CutsceneID, string>()
        {
            { CutsceneLibrary.CutsceneID.FirstTest, "Grandpa Joe - Intro"},
            { CutsceneLibrary.CutsceneID._MainStory_Trials_YouAreCollector, "Collector's Exam Completed"},
        };

    public static Dictionary<FlagCodex.FlagID, string> BasicChestDictionary = new Dictionary<FlagCodex.FlagID, string>()
        {
            { FlagCodex.FlagID._Chest_00011_ClaymoreInWaitingRoom, "Center Arena Waiting Room Chest"},
            { FlagCodex.FlagID._Chest_00010_IronSwordInWaitingRoom, "Left Arena Waiting Room Chest"},
            { FlagCodex.FlagID._Chest_00004_Staff, "Right Arena Waiting Room Chest"},
            { FlagCodex.FlagID._Chest_00005_PillarMountainBot, "Lower Pillar Mountains Chest"},
            { FlagCodex.FlagID._Chest_00003_ToyWand, "Upper Pillar Mountains Chest"},
            { FlagCodex.FlagID._Chest_00013_SouthFieldsWestChest, "Southern Fields West Chest"},
            { FlagCodex.FlagID._Chest_00002_Socks, "Middle Pillar Mountains Cave Chest"},
        };

    public static Dictionary<QuestCodex.QuestID, string> QuestDictionary = new Dictionary<QuestCodex.QuestID, string>()
        {
            { QuestCodex.QuestID._MainQuest_FirstVillage_GearUp, "Road to the City" },
            { QuestCodex.QuestID._MainQuest_EvergrindCity_TheCollectorsExam, "The Collector's Exam" },
            { QuestCodex.QuestID._MainQuest_SkyTemple_GetToSkyTemple, "The Ancient Temple" },
        };

    public static Dictionary<EnemyCodex.EnemyTypes, string> CardDictionary = new Dictionary<EnemyCodex.EnemyTypes, string>()
        {
            { EnemyCodex.EnemyTypes.GreenSlime, "Green Slime Card Drop"},
            { EnemyCodex.EnemyTypes.RedSlime, "Red Slime Card Drop"},
            { EnemyCodex.EnemyTypes.Rabbi, "Rabbi Card Drop"},
            { EnemyCodex.EnemyTypes.Bee, "Mrs Bee Card Drop"},
            { EnemyCodex.EnemyTypes.Blomma, "Bloomo Card Drop"},
            { EnemyCodex.EnemyTypes.Boar, "Boar Card Drop"},
            { EnemyCodex.EnemyTypes.Pumpkin, "Jumpkin Card Drop"},
            { EnemyCodex.EnemyTypes.PyroPumpkin, "Lantern Jack Card Drop"},
            { EnemyCodex.EnemyTypes.Scarecrow, "Scarecrow Card Drop"},
            { EnemyCodex.EnemyTypes.Halloweed, "Halloweed Card Drop"},
            { EnemyCodex.EnemyTypes.Ghosty, "Ghosty Card Drop"},
            { EnemyCodex.EnemyTypes.Wisp, "Wisp Card Drop"},
            { EnemyCodex.EnemyTypes.Pecko, "Pecko Card Drop"},
            { EnemyCodex.EnemyTypes.Guardian, "Guardian Card Drop"},
            { EnemyCodex.EnemyTypes.BrawlerBot, "Brawler Bot Card Drop"},
            { EnemyCodex.EnemyTypes.BlueSlime, "Blue Slime Card"},
            { EnemyCodex.EnemyTypes.FrostlingRogue, "Frostling Rogue Card Drop"},
            { EnemyCodex.EnemyTypes.FrostlingScoundrel, "Frostling Scoundrel Card Drop"},
            { EnemyCodex.EnemyTypes.Yeti, "Yeti Card Drop"},
            { EnemyCodex.EnemyTypes.GiftBoxMelee, "Gift Card Drop"},
            { EnemyCodex.EnemyTypes.GiftBoxRanged, "Present Card Drop"},
            { EnemyCodex.EnemyTypes.SeasonMage_CardEntry, "Season Mage Card Drop"},
            { EnemyCodex.EnemyTypes.SeasonKnight_CardEntry, "Season Knight Card Drop"},
            { EnemyCodex.EnemyTypes.MtBloom_CrystalBeetle, "Spinsect Card Drop"},
            { EnemyCodex.EnemyTypes.MtBloom_Shroom, "Shroomie Car Dropd"},
            { EnemyCodex.EnemyTypes.MtBloom_Larva, "Larvacid Card Drop"},
            { EnemyCodex.EnemyTypes.MtBloom_PoisonFlower, "Toxic Tulip Car Dropd"},
            { EnemyCodex.EnemyTypes.TimeTemple_Worm, "Thorn Worm Card Drop"},
            { EnemyCodex.EnemyTypes.TimeTemple_Statue, "Ancient Statue Card Drop"},
            { EnemyCodex.EnemyTypes.TimeTemple_Moss, "Plantae Hostilis Card Drop"},
            { EnemyCodex.EnemyTypes.TimeTemple_Echo, "Echo of Madness Card Drop"},
            { EnemyCodex.EnemyTypes.TimeTemple_Monkey, "Monkey Card Drop"},
            { EnemyCodex.EnemyTypes.Desert_Cacute, "Cacute Card Drop"},
            { EnemyCodex.EnemyTypes.Desert_Bird, "Sand Raven Card Drop"},
            { EnemyCodex.EnemyTypes.Desert_OrangeSlime, "Orange Slime Card Drop"},
            { EnemyCodex.EnemyTypes.Desert_Solem, "Solem Card Drop"},
            { EnemyCodex.EnemyTypes.Desert_VegetableCardEntry, "Living Veggies Card Drop"},
            { EnemyCodex.EnemyTypes.GhostShip_Crabby, "Crabby Card Drop"},
            { EnemyCodex.EnemyTypes.GhostShip_Skeleton, "Skeleton Warrior Card Drop"},
            { EnemyCodex.EnemyTypes.GhostShip_Wizard, "Skeleton Wizard Card Drop"},
            { EnemyCodex.EnemyTypes.GhostShip_Hauntie, "Hauntie Card Drop"},
        };

    public static Dictionary<string, string> VanillaLocationDictionary = new Dictionary<string, string>
        {
            //NPC Checks
            { "Mrs Wourie", "Wooden Sword" },
            { "Grandpa Joe - Intro", "Stick" },
            { "Luke - After Collector's Exam", "Green Slime Cube" },
            { "Robin - First Bow", "Wooden Bow" },
            { "Robin - 10K Points", "Quiver" },
            //Cutscene Checks
            { "Collector's Exam Completed", "Strawboater" },
            //Chest Checks
            { "Startington Cave Chest", "Wooden Shield" },
            { "Upper Pillar Mountains Chest", "Toy Wand" },
            { "Middle Pillar Mountains Cave Chest", "Sandals" },
            { "Lower Pillar Mountains Chest", "200g" },
            { "Left Arena Waiting Room Chest", "Iron Sword" },
            { "Center Arena Waiting Room Chest", "Claymore" },
            { "Right Arena Waiting Room Chest", "Staff" },
            { "Southern Fields West Chest", "Adventure Shirt" },
            //Quest Checks
            { "Road to the City", "Level 4 Boss XP Reward" },
            { "The Collector's Exam", "Talent Orb" },
            { "The Ancient Temple", "Talent Orb" },
            //Card Checks
            { "Green Slime Card Drop", "Green Slime Card" },
            { "Red Slime Card Drop", "Red Slime Card" },
            { "Rabbi Card Drop", "Rabbi Card" },
            { "Mrs Bee Card Drop", "Mrs Bee Card" },
            { "Bloomo Card Drop", "Bloomo Card" },
            { "Boar Card Drop", "Boar Card" },
            { "Jumpkin Card Drop", "Jumpkin Card" },
            { "Lantern Jack Card Drop", "Lantern Jack Card" },
            { "Scarecrow Card Drop", "Scarecrow Card" },
            { "Halloweed Card Drop", "Halloweed Card" },
            { "Ghosty Card Drop", "Ghosty Card" },
            { "Wisp Card Drop", "Wisp Card" },
            { "Pecko Card Drop", "Pecko Card" },
            { "Guardian Card Drop", "Guardian Card" },
            { "Brawler Bot Card Drop", "Brawler Bot Card" },
            { "Blue Slime Card Drop", "Blue Slime Card" },
            { "Frostling Rogue Card Drop", "Frostling Rogue Card" },
            { "Frostling Scoundrel Card Drop", "Frostling Scoundrel Card" },
            { "Yeti Card Drop", "Yeti Card" },
            { "Gift Card Drop", "Gift Card" },
            { "Present Card Drop", "Present Card" },
            { "Season Mage Card Drop", "Season Mage Card" },
            { "Season Knight Card Drop", "Season Knight Card" },
            { "Spinsect Card Drop", "Spinsect Card" },
            { "Shroomie Card Drop", "Shroomie Card" },
            { "Larvacid Card Drop", "Larvacid Card" },
            { "Toxic Tulip Card Drop", "Toxic Tulip Card" },
            { "Thorn Worm Card Drop", "Thorn Worm Card" },
            { "Ancient Statue Card Drop", "Ancient Statue Card" },
            { "Plantae Hostilis Card Drop", "Plantae Hostilis Card" },
            { "Echo of Madness Card Drop", "Echo of Madness Card" },
            { "Monkey Card Drop", "Monkey Card" },
            { "Cacute Card Drop", "Cacute Card" },
            { "Sand Raven Card Drop", "Sand Raven Card" },
            { "Orange Slime Card Drop", "Orange Slime Card" },
            { "Solem Card Drop", "Solem Card" },
            { "Living Veggies Card Drop", "Living Veggies Card" },
            { "Crabby Card Drop", "Crabby Card" },
            { "Skeleton Warrior Card Drop", "Skeleton Warrior Card" },
            { "Skeleton Wizard Card Drop", "Skeleton Wizard Card" },
            { "Hauntie Card Drop", "Hauntie Card" },
        };
}