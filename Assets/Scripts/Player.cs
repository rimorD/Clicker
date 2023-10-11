using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
    // Start is called before the first frame update
    void Start()
    {
        weapon = new Item(1, 0, 0, 0);
        armor = new Item(0, 1, 0, 0);
        ring = new Item(0, 0, 5, 0);

        currentHP = maxHP = MAX_HP;
        healthbar.value = healthbar.maxValue = MAX_HP;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //---------------------------------------------------------------------------------------------

    protected override void Die()
    {
        // Death animation
        // TODO: this sprites didnt come with death animation unfortunately

        // Get to end scene, there we will introduce our player name to save it in records
        SceneManager.LoadScene("EndGameScene");
    }

    // Data ///////////////////////////////////////////////////////////////////////////////////////
    private const int MAX_HP = 100; // Items could give the player more HP, but decided against it to make games shorter

    private Item weapon;
    private Item armor;
    private Item ring;

    protected override int AD { get => aD + weapon.AD + armor.AD + ring.AD;}
    protected override int Defense { get => defense + weapon.defense + armor.defense + ring.defense;}
    protected override int Dodge { get => dodge + weapon.dodge + armor.dodge + ring.dodge;}
    protected override int LifeSteal { get => lifeSteal + weapon.lifeSteal + armor.lifeSteal + ring.lifeSteal;}
}
