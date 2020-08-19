using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public event EventHandler OnHealthChanged;

    public int health;
    public int healthMax;
    public int attackRange;
    public float attackSpeed;
    public int attackDamage;


    public Character()
    {
        this.health=100;
        this.healthMax=100;
        this.attackRange=2;
        this.attackSpeed=5;
        this.attackDamage=10;
    }

    protected virtual void die()
    {
        // Empty
    }

    public int getHealth()
    {
        return this.health;
    }

    public float getHealthPercent()
    {
        return this.health/this.healthMax;
    }

    private void reduceHealth(int damageAmount)
    {
        this.health -= damageAmount;
        if(this.health<=0)
        {
            this.health=0;
            die();
        }
        if(OnHealthChanged!=null)
            OnHealthChanged(this, EventArgs.Empty);
    }

    public void restoreHealth(int healAmount)
    {
        this.health+=healAmount;
        if(this.health>this.healthMax)
        {
            this.health=this.healthMax;
        }

        if(OnHealthChanged!=null) 
            OnHealthChanged(this, EventArgs.Empty);
    }

    public void hit(int damageAmount)
    {
        reduceHealth(damageAmount);
        Debug.Log(health);
    }

    public bool isAlive()
    {
        if(this.health<=0)
            return false;

        return true;
    }
}
