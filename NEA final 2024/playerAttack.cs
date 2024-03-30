using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{

    public Animator anim; // the player animator
    public Transform attackPoint; // the point where the attack will be based from
    public float attackRange; // the radius of the attack circle
    public LayerMask enemyLayer; // enemy layer to detect colliso


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X)){
            Attack(); // attacks when input "X" is detected

        }
    }

    void Attack(){

        //set animation
        anim.SetTrigger("attack");//triggers attack animation
        //detect all enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);// creates a circle with attackPoint as center and attackRange as radius. collects all enemies in this circle into an array hitEnemies

        //attack all enemies
        foreach(Collider2D enemy in hitEnemies) // iterates once per enemy in hitEnemies
        {
            enemy.GetComponent<health>().TakeDamage(1);// takes health from the enemy
        }

    }
    
    void OnDrawGizmosSelected()
    {

        
        Gizmos.DrawWireSphere(attackPoint.position , attackRange);// is used to draw a circle showinf the attack circle
    }
}
