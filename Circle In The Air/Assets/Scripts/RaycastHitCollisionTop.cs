using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHitCollisionTop : MonoBehaviour {

    public CheckForCollisionTop checkCollision;

    public LayerMask mask;

    public PlayerHandle player;

    private void FixedUpdate()
    {
        if(checkCollision.hitCollision)
        {
            Debug.DrawRay(transform.position, Vector2.down * 1, Color.red, 1);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1, mask);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Edge")
                {
                    Vector3 hitPos = hit.point;

                    player.SetPositionWhenHitCollisionTop(hitPos);
                }
            }
        }
    }

}
