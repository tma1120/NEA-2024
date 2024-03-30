using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour 
{
    //Health
    [Header ("Health")]
    [SerializeField] private float startingHealth;//entity's starting health
    public float currentHealth;//entity's current health
    private Animator animator;//entity's animator

    //IFrames 
    [Header ("IFrames")]
    [SerializeField] private float iFramesDuration; //how long iframes last
    [SerializeField] private int numberFlashes;//number of flashes in iframes
    private SpriteRenderer spriteRend; //entity sprite renderer


    private void Awake() 
    {
        currentHealth = startingHealth;// set current health to starting health
        animator = GetComponent<Animator>();//get entitys animator
        spriteRend = GetComponent<SpriteRenderer>();//get entitys sprite renderer


    }

    public void TakeDamage(float _damage)// take damage method
    {
        currentHealth = Mathf.Clamp(currentHealth-=_damage, 0, startingHealth);//restricts current health between 0 and startinghealth

        if (currentHealth>0)
        {
            animator.SetTrigger("hurt");//if player not dead, play hurt animation
            StartCoroutine(Invulnerability());//start iFrames coroutine
        }
        else
        {
            animator.SetTrigger("dead");//if player dead, play death animation
        }
    }

    public void AddHealth(float _value)//add health 
    {
        currentHealth = Mathf.Clamp(currentHealth+=_value, 0, startingHealth);//adds health and restricts it between 0 and startingHealth
        Debug.Log("Healed");
    }


    private IEnumerator Invulnerability()
    {
        Debug.Log("start of iFrames");

        Physics2D.IgnoreLayerCollision(10,11,true); //now invulnerable ooooh cool innit
        for (int i = 0; i < numberFlashes; i++)
        {
            spriteRend.color = new Color(1,0,0,0.5f); //flash red "numberFlash" times, and transparency = 0.5
            Debug.Log("flash red");
            yield return new WaitForSeconds(iFramesDuration / (numberFlashes * 2));//wait
            spriteRend.color = Color.white; //set back to white
            yield return new WaitForSeconds(iFramesDuration / (numberFlashes * 2));//wait 
        }
        Physics2D.IgnoreLayerCollision(10,11,false); //not anymore though :(

        Debug.Log("end of iFrames");

    }

    void Despawn()
    {
        gameObject.SetActive(false);// remove the entity from the game
        Debug.Log("Dead"); //debug for testing purpose
    }

}
