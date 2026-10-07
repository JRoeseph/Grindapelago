///////////////////////////////////////////////////////////////////////////////
///
/// File: ArchiItem.cs
/// Revision: 2
/// Author: JRoeseph
/// Description: A general `ArchiItem` class that handles the collection and 
///     tracking of items to be recieved by the Archipelago server. Each type 
///     of Archipelago item (i.e. Grindea Item, Talent Orb, Warp location, 
///     etc.) has its own child of ArchiItem
/// 
///////////////////////////////////////////////////////////////////////////////
using SoG;

public interface ArchiItem
{
    void Collect();
}

public struct ArchiItemItem : ArchiItem
{
    public ItemCodex.ItemTypes Type;
    public ushort Amount;
    public ArchiItemItem(ItemCodex.ItemTypes inType, ushort inAmount)
    {
        Type = inType;
        Amount = inAmount;
    }

    public void Collect()
    {
        Grindapelago.Game._Item_PickUp(Type, Grindapelago.Game.xLocalPlayer, Amount, bSend: false);
    }
}

public struct ArchiItemGold : ArchiItem
{
    public ushort Amount;
    public ArchiItemGold(ushort inAmount)
    {
        Amount = inAmount;
    }

    public void Collect()
    {
        Grindapelago.Game._Money_AddToView(Grindapelago.Game.xLocalPlayer, Amount);
    }
}

public struct ArchiItemXP : ArchiItem
{
    public int Level;
    public ArchiItemXP(int inLevel)
    {
        Level = inLevel;
    }

    public void Collect()
    {
        Grindapelago.Game._Player_GrantEXPToPlayer(Grindapelago.Game.xLocalPlayer, Level, EnemyDescription.Category.Boss);
    }
}

public struct ArchiItemPoint : ArchiItem
{
    public Quests.SkillPointReward.SkillPointType Type;
    public ushort Amount;
    public ArchiItemPoint(Quests.SkillPointReward.SkillPointType inType, ushort inAmount)
    {
        Type = inType;
        Amount = inAmount;
    }

    public void Collect()
    {
        PlayerView xView = Grindapelago.Game.xLocalPlayer;
        if (Type == Quests.SkillPointReward.SkillPointType.Talent)
        {
            xView.xViewStats.iTalentPoints += Amount;
        }
        else if (Type == Quests.SkillPointReward.SkillPointType.Silver)
        {
            xView.xViewStats.iSkillPointsSilver += Amount;
        }
        else if (Type == Quests.SkillPointReward.SkillPointType.Gold)
        {
            xView.xViewStats.iSkillPointsGold += Amount;
        }
    }
}

public struct ArchiItemCard : ArchiItem
{
    public EnemyCodex.EnemyTypes Type;
    public ArchiItemCard(EnemyCodex.EnemyTypes inType)
    {
        Type = inType;
    }

    public void Collect()
    {
        PlayerView xView = Grindapelago.Game.xLocalPlayer;
        xView.xJournalInfo.henCardAlbum.Add(Type, false);
    }
}