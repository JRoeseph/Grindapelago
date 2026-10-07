///////////////////////////////////////////////////////////////////////////////
///
/// File: LocationDictionaries.cs
/// Revision: 1
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
            { EnemyCodex.EnemyTypes.GreenSlime, "Green Slime Card"},
            { EnemyCodex.EnemyTypes.RedSlime, "Red Slime Card"},
            { EnemyCodex.EnemyTypes.Rabbi, "Rabbi Card"},
            { EnemyCodex.EnemyTypes.Bee, "Mrs Bee Card"},
            { EnemyCodex.EnemyTypes.Blomma, "Bloomo Card"},
            { EnemyCodex.EnemyTypes.Boar, "Boar Card"},
            { EnemyCodex.EnemyTypes.Pumpkin, "Jumpkin Card"},
            { EnemyCodex.EnemyTypes.PyroPumpkin, "Lantern Jack Card"},
            { EnemyCodex.EnemyTypes.Scarecrow, "Scarecrow Card"},
            { EnemyCodex.EnemyTypes.Halloweed, "Halloweed Card"},
            { EnemyCodex.EnemyTypes.Ghosty, "Ghosty Card"},
            { EnemyCodex.EnemyTypes.Wisp, "Wisp Card"},
            { EnemyCodex.EnemyTypes.Pecko, "Pecko Card"},
            { EnemyCodex.EnemyTypes.Guardian, "Guardian Card"},
            { EnemyCodex.EnemyTypes.BrawlerBot, "Brawler Bot Card"},
            { EnemyCodex.EnemyTypes.BlueSlime, "Blue Slime Card"},
            { EnemyCodex.EnemyTypes.FrostlingRogue, "Frostling Rogue Card"},
            { EnemyCodex.EnemyTypes.FrostlingScoundrel, "Frostling Scoundrel Card"},
            { EnemyCodex.EnemyTypes.Yeti, "Yeti Card"},
            { EnemyCodex.EnemyTypes.GiftBoxMelee, "Gift Card"},
            { EnemyCodex.EnemyTypes.GiftBoxRanged, "Present Card"},
            { EnemyCodex.EnemyTypes.SeasonMage_CardEntry, "Season Mage Card"},
            { EnemyCodex.EnemyTypes.SeasonKnight_CardEntry, "Season Knight Card"},
            { EnemyCodex.EnemyTypes.MtBloom_CrystalBeetle, "Spinsect Card"},
            { EnemyCodex.EnemyTypes.MtBloom_Shroom, "Shroomie Card"},
            { EnemyCodex.EnemyTypes.MtBloom_Larva, "Larvacid Card"},
            { EnemyCodex.EnemyTypes.MtBloom_PoisonFlower, "Toxic Tulip Card"},
            { EnemyCodex.EnemyTypes.TimeTemple_Worm, "Thorn Worm Card"},
            { EnemyCodex.EnemyTypes.TimeTemple_Statue, "Ancient Statue Card"},
            { EnemyCodex.EnemyTypes.TimeTemple_Moss, "Plantae Hostilis Card"},
            { EnemyCodex.EnemyTypes.TimeTemple_Echo, "Echo of Madness Card"},
            { EnemyCodex.EnemyTypes.TimeTemple_Monkey, "Monkey Card"},
            { EnemyCodex.EnemyTypes.Desert_Cacute, "Cacute Card"},
            { EnemyCodex.EnemyTypes.Desert_Bird, "Sand Raven Card"},
            { EnemyCodex.EnemyTypes.Desert_OrangeSlime, "Orange Slime Card"},
            { EnemyCodex.EnemyTypes.Desert_Solem, "Solem Card"},
            { EnemyCodex.EnemyTypes.Desert_VegetableCardEntry, "Living Veggies Card"},
            { EnemyCodex.EnemyTypes.GhostShip_Crabby, "Crabby Card"},
            { EnemyCodex.EnemyTypes.GhostShip_Skeleton, "Skeleton Warrior Card"},
            { EnemyCodex.EnemyTypes.GhostShip_Wizard, "Skeleton Wizard Card"},
            { EnemyCodex.EnemyTypes.GhostShip_Hauntie, "Hauntie Card"},
        };

    public static Dictionary<string, ArchiItem> VanillaItemDictionary = new Dictionary<string, ArchiItem>
        {
            //NPC Checks
            { "Mrs Wourie", new ArchiItemItem(ItemCodex.ItemTypes._OneHanded_WoodenSword, 1) },
            { "Grandpa Joe - Intro", new ArchiItemItem(ItemCodex.ItemTypes._TwoHanded_Stick, 1) },
            { "Luke - After Collector's Exam" , new ArchiItemItem(ItemCodex.ItemTypes._Misc_SlimeCube, 1) },
            { "Robin - First Bow" , new ArchiItemItem(ItemCodex.ItemTypes._Bow_WoodenBow, 1) },
            { "Robin - 10K Points" , new ArchiItemItem(ItemCodex.ItemTypes._KeyItem_Quiver, 1) },
            //Cutscene Checks
            { "Collector's Exam Completed", new ArchiItemItem(ItemCodex.ItemTypes._Hat_Strawboater, 1) },
            //Chest Checks
            { "Startington Cave Chest", new ArchiItemItem(ItemCodex.ItemTypes._Shield_WoodenShield, 1) },
            { "Upper Pillar Mountains Chest", new ArchiItemItem(ItemCodex.ItemTypes._OneHanded_ToyWand, 1) },
            { "Middle Pillar Mountains Cave Chest", new ArchiItemItem(ItemCodex.ItemTypes._Shoes_Sandals, 1) },
            { "Lower Pillar Mountains Chest", new ArchiItemGold(200) },
            { "Left Arena Waiting Room Chest", new ArchiItemItem(ItemCodex.ItemTypes._OneHanded_IronSword, 1) },
            { "Center Arena Waiting Room Chest", new ArchiItemItem(ItemCodex.ItemTypes._TwoHanded_Claymore, 1) },
            { "Right Arena Waiting Room Chest", new ArchiItemItem(ItemCodex.ItemTypes._TwoHanded_Staff, 1) },
            { "Southern Fields West Chest", new ArchiItemItem(ItemCodex.ItemTypes._Armor_AdventureShirt, 1) },
            //Quest Checks
            { "Road to the City", new ArchiItemXP(4) },
            { "The Collector's Exam", new ArchiItemPoint(SkillPointReward.SkillPointType.Talent, 1) },
            { "The Ancient Temple", new ArchiItemPoint(SkillPointReward.SkillPointType.Talent, 1) },
            //Card Checks
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
}