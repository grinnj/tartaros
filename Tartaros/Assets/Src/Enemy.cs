using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public int CollisionDamage;
    private float NextAttack;

    public Enemy()
    {
        CollisionDamage=100;
    }

    protected override void die()
    {
        Destroy(this.gameObject);
    }

    public void Update()
    {
        AttackPlayer();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Player.GetPlayer().hit(CollisionDamage);
        }
    }

    public void AttackPlayer()
    {
        Vector3 distance = Player.GetPlayer().transform.position - transform.position;
        if (distance.sqrMagnitude < attackRange &&
            Time.time > NextAttack)
        {
            NextAttack = Time.time + attackSpeed;
            Player.GetPlayer().hit(attackDamage);
        }
    }
}
