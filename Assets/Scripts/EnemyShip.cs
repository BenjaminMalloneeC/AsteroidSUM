using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    private Vector3 targetPosition;
    public float rotationSpeed;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = GameManager.instance.player.transform.position;
        Vector3 directionToLook = targetPosition - transform.position;
        transform.up = directionToLook;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(transform.forward, transform.right), rotationSpeed * Time.deltaTime);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        //Debug.Log("Collided with something");
        Debug.Log(otherObject.gameObject.name);
        if (otherObject.gameObject == GameManager.instance.player || otherObject.gameObject.name == "Bullet(Clone)")
        {
            //Debug.Log("Ran into player game object");
            //This is what happens if the player hits an asteroid.
            Destroy(this.gameObject);

            Destroy(otherObject.gameObject);
        }
    }
}
