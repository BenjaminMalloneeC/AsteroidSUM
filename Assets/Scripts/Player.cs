using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform tf;
    public float turnSpeed = 175f;
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 6f;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.player = this.gameObject;
        tf = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            tf.Rotate(0, 0, turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            tf.Rotate(0, 0, -turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //tf.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.Self);
            tf.position += tf.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position,transform.rotation);
        bullet.GetComponent<Bullet>().bulletSpeed = bulletSpeed;
        Destroy(bullet, 2);
    }

   void OnCollisionEnter2D(Collision2D otherObject)
    {
        //If the player runs into something, they should die
        Die();
    }

    void Die()
    {
        //TODO: Write death code here
        Destroy(this.gameObject);
    }

    void OnDestroy()
    {
        GameManager.instance.player = null;
    }
}
