using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Variables{

    public LayerMask mask; //chỉ có background
    [System.NonSerialized]
    public float distance = 1.7f;
    [System.NonSerialized]
    public bool onTriggerEnter;
    [System.NonSerialized]
    public bool onEdgeTrigger;

    [System.NonSerialized]
    public float force = 8;
    [System.NonSerialized]
    public float speed = 0.1f;
    [System.NonSerialized]
    public float instanceTopHit = 1.95f;
    [System.NonSerialized]
    public float instanceBottomHit = 2f;

    [System.NonSerialized]
    public bool startGame;
    [System.NonSerialized]
    public bool endGame;
    [System.NonSerialized]
    public bool foundHit;

    [System.NonSerialized]
    public float gravityScale = 2.2f;
}
