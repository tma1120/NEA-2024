using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [Header ("Attack Parameters")]
    [SerializeField] private float attackCooldown;//enemy attack cooldown
    [SerializeField] private float range;//enemy range
    [SerializeField] private int damage;//enemy damage

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;//how far the collider is shifted forward
    [SerializeField] private BoxCollider2D boxCollider;//box collider

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;//player layer

    [Header("Others")]
    public Animator anim;//enemy animator
    public health playerHealth;//enemy


    private void Update()
    {
        cooldownTimer += Time.deltaTime;//starts a cooldown for the attack

        //Attack only when player in sight
        if (PlayerInSight())
        {

            if (cooldownTimer >= attackCooldown)
            {
                anim.SetBool("Moving",false);//if cooldown is complete, then stop moving and attack
                cooldownTimer = 0;//
                anim.SetTrigger("meleeAttack");//sets attack animation for enemy
            }
        }

        
    }

    private bool PlayerInSight()//checking if enemy in sight
    {
        RaycastHit2D hit = 
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);//creates a box in front of enemy

        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<health>();//if player is detetced in that box, subtract health

        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));// used to draw the same box as earlier, this one visible for debugging
    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
        
            playerHealth.TakeDamage(damage);//if player seen, the attack
    }
}