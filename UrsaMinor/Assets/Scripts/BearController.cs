﻿using UnityEngine;
using System.Collections;

public class BearController : MovementController
{
    public GameObject TalkBubblePoint;
    public float FullJumpSpeed,
                 JumpVelocity;
    protected bool jumped;

    protected bool isGrounded
    {
        get
        {
            return _isGrounded;
        }
        set
        {
            if (value != _isGrounded)
            {
                _isGrounded = value;
            }
        }
    }
    private bool _isGrounded;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected virtual void Jump()
    {
        if (_myRigidbody.velocity.y < FullJumpSpeed)
        {
            MoveUp(JumpVelocity);
        }
        else
            jumped = true;
    }

    //This needs to be made better
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    public virtual void Call(float duration, TalkBubbleTypes currentType)
    {
        GameObject talkBubbleObject = new GameObject();
        switch (currentType)
        {
            case TalkBubbleTypes.ANGRY:
                talkBubbleObject = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/AngryTalkBubble"), TalkBubblePoint.transform.position, Quaternion.identity);
                break;
            case TalkBubbleTypes.LEFTARROW:
                talkBubbleObject = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/LeftArrowTalkBubble"), TalkBubblePoint.transform.position, Quaternion.identity);
                break;
            case TalkBubbleTypes.RIGHTARROW:
                talkBubbleObject = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/RightArrowTalkBubble"), TalkBubblePoint.transform.position, Quaternion.identity);
                break;
            default:
                Debug.LogWarning("That talk bubble type either doesn't exist or hasn't been set up yet.");
                break;
        }
        TalkBubble talkBubble = talkBubbleObject.GetComponent<TalkBubble>();
        talkBubble.Duration = duration;
    }
}