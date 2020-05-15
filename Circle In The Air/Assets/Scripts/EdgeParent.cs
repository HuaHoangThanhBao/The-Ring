using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeParent : MonoBehaviour {

    public List<GameObject> edgePrefabs;

    PlayerHandle player;

    GameObject edgeClone;

    float startX = 0;

    private void Awake()
    {
        edgeClone = Resources.Load("Prefabs/Edge") as GameObject;
        player = FindObjectOfType<PlayerHandle>();
    }

    private void Start()
    {
        edgeClone = (GameObject)Instantiate(edgeClone, new Vector3(startX, 1, 0), Quaternion.identity);
        edgeClone.transform.parent = transform;
        edgePrefabs.Add(edgeClone);
        startX += 121;
    }

    float timeDestroy;
    bool startCountTime;
    int temp = 0;

    private void Update()
    {
        if (!player.variables.endGame)
        {
            if (player.variables.onEdgeTrigger)
            {
                startCountTime = true;

                if (temp == 0)
                {
                    edgeClone = (GameObject)Instantiate(edgeClone, new Vector3(startX, 1, 0), Quaternion.identity);
                    edgeClone.transform.parent = transform;
                    edgePrefabs.Add(edgeClone);
                    startX += 121;
                    temp++;
                }
            }

            if (startCountTime)
            {
                timeDestroy += Time.deltaTime;
                if (timeDestroy > 8)
                {
                    Destroy(transform.GetChild(0).gameObject);
                    timeDestroy = 0;
                    startCountTime = false;
                    temp = 0;
                }
            }
        }
    }
}
