using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthCollectible : MonoBehaviour
{
  public float healthValue = 1f; // value of health collectibe

  private void OnTriggerEnter2D(Collider2D collision)
  {

    if(collision.tag == "Player")//if collision with player dettected:
    {
        collision.GetComponent<health>().AddHealth(healthValue);//addHealth to player of value healthValue
        gameObject.SetActive(false);//removing health collectible from game
    }

  }

}
