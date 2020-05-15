using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginMove : MonoBehaviour {

    public enum BeginState
    {
        MoveDown,
        MoveUp
    }

    bool changeState;

    public bool endState = false;

    float time;
    float speed = 0.25f;
    float deltaTime = 0.9f;
    float timeChange = 0.9f;

    public BeginState beginMove;

    private void Update()
    {
        if (!endState)
        {
            HandleState();
            Ter();
        }
    }

    void HandleState()
    {
        time += Time.deltaTime;

        if (time < timeChange)
        {
            changeState = true;
        }
        else if (time >= timeChange && time < timeChange + deltaTime)
        {
            changeState = false;
        }
        else time = 0;
    }

    void Ter()
    {
        if (changeState)
        {
            beginMove = BeginState.MoveDown;

            this.transform.position = Vector3.Lerp(transform.position, new Vector3(0, -1, 0), Time.deltaTime * speed);
        }
        else
        {
            beginMove = BeginState.MoveUp;

            this.transform.position = Vector3.Lerp(transform.position, new Vector3(0, 3, 0), Time.deltaTime * speed);
        }
    }
}
