using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class CheckForCollisionTop : MonoBehaviour {

    public bool hitCollision;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Edge")
        {
            hitCollision = true;
        }
        else hitCollision = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Edge")
        {
            hitCollision = true;
        }
    }
}
