using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D otherObject)
    {
        Destroy(otherObject.gameObject);
    }
}
