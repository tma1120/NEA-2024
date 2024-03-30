using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol")]
    [SerializeField] private Transform leftEdge; // left edge of enemy patrolling
    [SerializeField] private Transform rightEdge;// right edge of enemy patrolling

    [Header("Enemy")]
    [SerializeField] public Transform enemy; //enemy transform 
    
    [Header("Movement")]
    [SerializeField] private float speed;// enemy speed
    [SerializeField] private float idleDuration;//enemy idle duration
    private float idleTimer;// used to time the idle time of enemy
    private Vector3 initialScale;// the scale of the enemy at the start
    private bool movingLeft;
    
    [Header("Animating :)")]
    public Animator anim; // enemy animator


    private void Awake()
    {
        initialScale = enemy.localScale;// sets the initialscale 
    }
//-------------------------------------------------
    private void MoveInDirection(int _direction)
    {
        anim.SetBool("Moving", true);// set animator to moving

        enemy.localScale = new Vector3(Mathf.Abs(initialScale.x) * _direction, initialScale.y, initialScale.z);// enemy x-axis flipped to show facing correct direction

        enemy.position = new Vector3(enemy.position.x + (Time.deltaTime * _direction * speed), enemy.position.y, enemy.position.z);// moves the enemy
    }


    private void Update()
    {
        if (movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)// if enemy is to the right of the left edge
            {
                MoveInDirection(-1);//continue moving to the left
            }
            else
            {
                changeDirection();//stop and change directions
            }
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)// if enemy to the left of the right edge
            {
                MoveInDirection(1);//continue moving to the right
            }
            else
            {
                changeDirection();//stop and change directions
            }
        }
    }

    private void changeDirection()
    {
        anim.SetBool("Moving", false);//stop moving

        idleTimer += Time.deltaTime;//add to idle timer

        if (idleTimer>=idleDuration)//if idleTimer is the idle duration
        {
            movingLeft = !movingLeft;//switch direction
            idleTimer = 0;//reset the timer
        }

        
    }
    
}