using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //---------------------------------------------------------------------------------------------
    // Returns amount of damage done
    public virtual int ReceiveDamage(int amount)
    {
        // Check if we dodge the attack
        if (Random.Range(1, 100) <= this.Dodge)
            return 0;

        // No dodge, substract armor modifier if any
        amount -= this.Defense;
        if (amount < 0)
            amount = 0;

        // Substract amount from HP
        this.currentHP -= amount;
        healthbar.value -= amount;

        // If less than 0 die (overriden by character)
        if(this.currentHP <= 0)
        {
            Die();
        }

        return amount;
    }

    //---------------------------------------------------------------------------------------------
    // Allow each descendant to override die behaviour
    protected abstract void Die();

    //---------------------------------------------------------------------------------------------

    public int Attack(Character objective)
    {
        // Attack animation
        StartCoroutine("AttackAnimation");

        // Calculate damage
        int damageDone = objective.ReceiveDamage(AD);

        // Check if any healing
        if(LifeSteal > 0 && damageDone > 0)
        {
            int healing = Mathf.RoundToInt(damageDone * (LifeSteal / 100));
            this.currentHP = Mathf.Min(maxHP, currentHP + healing);
        }

        return damageDone;
    }
    //---------------------------------------------------------------------------------------------

    public IEnumerator AttackAnimation()
    {
        animator.SetBool("Attacking", true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Attacking", false);

    }

    // Data ///////////////////////////////////////////////////////////////////////////////////////
    protected int currentHP;
    protected int maxHP;
    protected int aD;
    protected int defense;
    protected int dodge;
    protected int lifeSteal;

    protected virtual int AD { get => aD; }
    protected virtual int Defense { get => defense; }
    protected virtual int Dodge { get => dodge; }
    protected virtual int LifeSteal { get => lifeSteal; }

    [SerializeField] protected Slider healthbar;
    [SerializeField] protected Animator animator;
}
