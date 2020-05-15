using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParent : MonoBehaviour {

    public List<GameObject> backgroundPrefabs;

    PlayerHandle player;

    GameObject background;
    GameObject backgroundOrigin;

    float startX = -10.5f;

    int order = 2;

    private void Awake()
    {
        player = FindObjectOfType<PlayerHandle>();
        background = Resources.Load("Prefabs/Background") as GameObject;
        backgroundOrigin = Resources.Load("Prefabs/Background Origin") as GameObject;
    }


    private void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            background = (GameObject)Instantiate(background, new Vector3(startX, 0, 0), Quaternion.identity);
            background.transform.parent = transform;
            startX += 10.5f;
            backgroundPrefabs.Add(background);
        }

        backgroundOrigin = (GameObject)Instantiate(backgroundOrigin, new Vector3(startX, 0, 0), Quaternion.identity);
        backgroundOrigin.transform.parent = transform;
        backgroundPrefabs.Add(backgroundOrigin);
        startX += 10.5f;
    }

    int temp = 0;

    private void Update()
    {
        if (player.variables.onTriggerEnter)
        {
            if (temp == 0)
            {
                backgroundOrigin = (GameObject)Instantiate(backgroundOrigin, new Vector3(startX, 0, 0), Quaternion.identity);
                backgroundOrigin.transform.parent = transform;
                backgroundPrefabs.Add(backgroundOrigin);

                DestroyClone(transform.GetChild(0).gameObject);
                
                startX += 10.5f;

                temp++;
            }
        }
        else temp = 0;
    }

    public void DestroyClone(GameObject clone)
    {
        Destroy(clone.gameObject);
    }
}
