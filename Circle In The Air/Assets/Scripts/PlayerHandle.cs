using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerHandle : MonoBehaviour {

    Animator anim;

    Rigidbody2D rb;

    BeginMove beginMove;
    CheckForCollisionTop checkCollisionTop;
    CheckForCollisionBottom checkCollisionBottom;
    ScoreHandler scoreHandler;

    public InputManager inputs;

    public Variables variables;

    GameObject errorCircle;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        errorCircle = GameObject.Find("Error Circle");
        checkCollisionBottom = FindObjectOfType<CheckForCollisionBottom>();
        checkCollisionTop = FindObjectOfType<CheckForCollisionTop>();
        scoreHandler = FindObjectOfType<ScoreHandler>();
        beginMove = FindObjectOfType<BeginMove>();
    }

    private void Start()
    {
        Time.timeScale = 1;
        errorCircle.SetActive(false);
        variables.endGame = false;
    }

    private void Update()
    {
        if (!variables.endGame)
        {
            KeyType();
            InputManager();

            RayForTrigger();
        }
    }

    public void RayForTrigger()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, variables.distance, variables.mask);
        if (hit.collider != null)
        {
            if (hit.transform.tag == "Background")
                variables.onTriggerEnter = true;
        }
        else variables.onTriggerEnter = false;

        if (hit.collider != null)
        {
            if (hit.transform.tag == "Edge")
                variables.onEdgeTrigger = true;
        }
        else variables.onEdgeTrigger = false;
    }

    void KeyType()
    {
        inputs.keyDown = Input.GetMouseButtonDown(0);

        HandleRigibody();
    }

    void HandleRigibody()
    {
        if (inputs.keyDown)
        {
            rb.velocity = Vector2.up * variables.force;
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = variables.gravityScale;
        }
    }

    void InputManager()
    {
        if (inputs.keyDown)
        {
            variables.startGame = true;
            beginMove.endState = true;
        }

        if (variables.startGame)
        {
            this.transform.Translate(Vector3.right * variables.speed);
        }
    }

    public void SetPositionWhenHitCollisionTop(Vector3 hitPos)
    {
        if (checkCollisionTop.hitCollision)
        {
            transform.position = hitPos - new Vector3(0, variables.instanceTopHit, 0);

            rb.simulated = false;
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
            SetErrorCircle();

            variables.startGame = false;
            variables.endGame = true;
        }
    }

    public void SetPositionWhenHitCollisionBottom(Vector3 hitPos)
    {
        if (checkCollisionBottom.hitCollision)
        {
            transform.position = hitPos + new Vector3(0, variables.instanceBottomHit, 0);


            rb.simulated = false;
            rb.isKinematic = true;
            SetErrorCircle();

            variables.startGame = false;
            variables.endGame = true;
        }
    }

    void PlayingAudio()
    {
        AudioManager.PlaySound("Error");
    }

    public void SetErrorCircle()
    {
        anim.SetBool("Error", true);
    }

    public void SetActive()
    {
        this.gameObject.SetActive(false);
    }

    public void SetUI()
    {
        scoreHandler.UISetActive();
    }
}
