using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    // Ctor ///////////////////////////////////////////////////////////////////////////////////////

    public Item (int ad, int def, int dge, int ls)
    {
        AD = ad;
        defense = def;
        dodge = dge;
        lifeSteal = ls;
    }

    // --------------------------------------------------------------------------------------------

    public static Item GenerateRandom(int currentLevel)
    {
        // AD formula (1-5 * level)
        int AD = Random.Range(1, 5) * currentLevel;
        // Defense formula (0-3 * level)
        int defense = Random.Range(0, 3) * currentLevel;
        // Dodge (0-5 * level, max 75)
        int dodge = Mathf.Min(Random.Range(0, 1) * currentLevel, 75);
        // Life steal (0-5 * level, no max, i guess they can heal for more than the damage they deal thats fine)
        int ls = Random.Range(0, 1) * currentLevel;

        return new Item(AD, defense, dodge, ls);
    }

    // Data ///////////////////////////////////////////////////////////////////////////////////////
    public int AD { get; private set; }
    public int defense { get; private set; }
    public int dodge { get; private set; }
    public int lifeSteal { get; private set; }
}
