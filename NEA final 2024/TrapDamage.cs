using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
   public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if(collision.tag == "Player") //commented out so traps hurt all entities
        //{
            collision.GetComponent<health>().TakeDamage(damage);//if collisions detetced between trap and enemy, take damage
        // }
    }


}
