﻿using UnityEngine;
using System.Collections;

public class UrsaController : BearController
{
    private CameraController myCameraController;
                 //_jumpFinished = true;

    protected override void Start()
    {
        base.Start();

        myCameraController = Camera.main.GetComponent<CameraController>();
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Mouse0) && !jumped)
        {
            MakeNoise(false);
            jumpInitiated = true;
        }
        if (Input.GetKey(KeyCode.Mouse0) && !jumped && jumpInitiated)
        {
            isGrounded = false;
            Jump();
        }
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (!isGrounded)
                jumped = true;
            else
                jumped = false;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Swipe();
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            myAnimator.SetBool("calling", true);
            Call(0.5f, TalkBubbleTypes.LEFTARROW);
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft(MoveSpeed);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight(MoveSpeed);
        }
    }
}