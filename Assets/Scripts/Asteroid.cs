using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.enemyList.Add(this.gameObject);
    }

    private void OnDestroy()
    {
        GameManager.instance.enemyList.Remove(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        Debug.Log("Collided with something");
        Debug.Log(otherObject.gameObject.name);
        if (otherObject.gameObject == GameManager.instance.player)
        {
            Debug.Log("Ran into player game object");
            //This is what happens if the player hits an asteroid.
        }
    }

    private void OnCollisionExit2D(Collision2D otherObject)
    {
        Debug.Log("I stopped colliding");
    }

    private void OnCollisionStay2D(Collision2D otherOBject)
    {
        Debug.Log("I'm Still colliding with something");
    }
}
