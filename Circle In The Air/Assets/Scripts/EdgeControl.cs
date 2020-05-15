using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeControl : MonoBehaviour {

    public List<GameObject> edgePrefabs;

    GameObject edgeFirst;

    int number = 0;
    int count = 0;

    private void Awake()
    {
        edgeFirst = GameObject.Find("Edge First(Clone)");
    }

    private void Start()
    {
        edgePrefabs.Add(edgeFirst);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (count == 0)
        {
            GameObject backgroundClone = Instantiate(edgePrefabs[number], new Vector3(edgePrefabs[number].transform.position.x + 121, 1, 0), Quaternion.identity);

            backgroundClone.transform.parent = transform.parent;

            edgePrefabs.Add(backgroundClone);

            number++;

            count++;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        count = 0;
    }
}
