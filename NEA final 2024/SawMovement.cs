using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMovement : MonoBehaviour
{
    public float startX; // saw starting x-coord
    public float endX; // saw ending x- coord
    public float y;//saw y-coord
    public float speed = 2.0f; //saw speed

    void Start()
    {
        StartCoroutine(MoveSaw());//starts the saw's movement coroutines
    }

    IEnumerator MoveSaw()
    {
        while (true)
        {
            float pingPongValue = Mathf.PingPong(Time.time * speed, 1.0f);//finds an oscilating value for the saw 
            float newX = Mathf.Lerp(startX, endX, pingPongValue);//creates new x-coord, smoothed out using mathf.lerp
            Vector3 newPosition = new Vector3(newX, y, transform.position.z);   //creates new position vector for saw
            transform.position = newPosition; // changes saw position

            yield return null;//calls next fram 
        }
    }
}