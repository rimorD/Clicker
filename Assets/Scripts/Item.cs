using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    // Ctor ///////////////////////////////////////////////////////////////////////////////////////

    public Item (int ad, int def, int dge, int ls, ItemType type)
    {
        AD = ad;
        defense = def;
        dodge = dge;
        lifeSteal = ls;
        itemType = type;
    }

    // --------------------------------------------------------------------------------------------

    public static Item GenerateRandom(int currentLevel, ItemType type)
    {
        // Definitivamente hay que
        // AD formula (1-5 * level)
        int AD = Random.Range(1, 5) * currentLevel;
        // Defense formula (1-3 * level)
        int defense = Random.Range(1, 3) * currentLevel;
        // Dodge (0-5 * level, max 75)
        int dodge = Mathf.Min(Random.Range(0, 5) * currentLevel, 75);
        // Life steal (0-5 * level, no max, i guess they can heal for more than the damage they deal thats fine)
        int ls = Random.Range(0, 5) * currentLevel;

        return new Item(AD, defense, dodge, ls, type);
    }

    // Data ///////////////////////////////////////////////////////////////////////////////////////
    public int AD { get; private set; }
    public int defense { get; private set; }
    public int dodge { get; private set; }
    public int lifeSteal { get; private set; }

    public ItemType itemType { get; private set; }
    public enum ItemType
    {
        WEAPON = 1,
        ARMOR = 2,
        RING = 3
    }
}
