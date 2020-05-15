using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHitCollisionBottom : MonoBehaviour {

    public CheckForCollisionBottom checkCollision;

    public LayerMask mask;

    public PlayerHandle player;

    private void FixedUpdate()
    {
        if (checkCollision.hitCollision)
        {
            Debug.DrawRay(transform.position, Vector2.up * 1f, Color.red, 1f);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 1f, mask);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Edge")
                {
                    Vector3 hitPos = hit.point;

                    player.SetPositionWhenHitCollisionBottom(hitPos);
                }
            }
        }
    }
}
