using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : Character
{
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();

        // Get current level
        int level = PlayerPrefs.GetInt("Level", 1); 

        // Set stats
        maxHP = currentHP = MAX_HP_PER_LEVEL * level;
        aD = AD_PER_LEVEL * level;
        defense = DEFENSE_PER_LEVEL * level;
        dodge = DODGE_PER_LEVEL * level;
        lifeSteal = LIFESTEAL_PER_LEVEL * level;
        AttackSpeed = Mathf.Max((float)(10 - (level * 0.25)), 0.25f); // Max attack speed is 4 per second (ouch)

        // Do the only thing he knows to do
        StartCoroutine("BossAttackCoroutine");
    }

    // Update is called once per frame
    void Update()
    {
    }

    // On mouse down, get attacked by the player
    void OnMouseDown()
    {
        asrc.PlayOneShot(playerAttack);
        player.Attack(this);
    }

    //---------------------------------------------------------------------------------------------

    protected override void Die()
    {
        // Victory animation
        // TODO

        // Get to loot scene
        SceneManager.LoadScene("LootScene");
    }

    //---------------------------------------------------------------------------------------------

    IEnumerator BossAttackCoroutine()
    {
        // Wait a determined number of seconds and attack the player
        yield return new WaitForSeconds(AttackSpeed);
        asrc.PlayOneShot(bossAttack);
        Attack(player);
    }

    // Data ///////////////////////////////////////////////////////////////////////////////////////
    private float AttackSpeed;
    public Character player;

    private const int MAX_HP_PER_LEVEL = 25;
    private const int AD_PER_LEVEL = 2;
    private const int DEFENSE_PER_LEVEL = 1;
    private const int DODGE_PER_LEVEL = 3;
    private const int LIFESTEAL_PER_LEVEL = 1;

    // Sound
    public AudioClip playerAttack;
    public AudioClip bossAttack;
    public AudioSource asrc;
}
