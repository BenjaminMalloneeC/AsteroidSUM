using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Vector3 directionToMove;
    private Vector3 targetPosition;
    public float moveSpeed;
    private void Start()
    {
        GameManager.instance.enemyList.Add(this.gameObject);

        directionToMove = GameManager.instance.player.transform.position - transform.position;
        directionToMove.Normalize();

        targetPosition = GameManager.instance.player.transform.position;
    }

    private void Update()
    {
        //Used to go to starting position
        transform.position += directionToMove * moveSpeed * Time.deltaTime;

        //Used for heat seeking
        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        //Move a percent every update
        //transform.position = Vector3.Lerp(transform.position, targetPosition, 0.01f);
    }

    private void OnDestroy()
    {
        GameManager.instance.enemyList.Remove(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        //Debug.Log("Collided with something");
        Debug.Log(otherObject.gameObject.name);
        if (otherObject.gameObject == GameManager.instance.player ||  otherObject.gameObject.name == "Bullet(Clone)")
        {
            //Debug.Log("Ran into player game object");
            //This is what happens if the player hits an asteroid.
            Destroy(this.gameObject);

            Destroy(otherObject.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D otherObject)
    {
        //Debug.Log("I stopped colliding");
    }

    private void OnCollisionStay2D(Collision2D otherOBject)
    {
        //Debug.Log("I'm Still colliding with something");
    }
}
