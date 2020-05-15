using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour {

    public Transform player;

    float speed = 10;

    private void Update()
    {
        Vector3 newPos = new Vector3 (player.transform.position.x, 0, -10);

        transform.position = Vector3.Lerp(transform.position, newPos, Time.fixedDeltaTime * speed);
    }
}
