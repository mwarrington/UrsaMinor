﻿using UnityEngine;
using System.Collections;

public class NPCController : BearController
{
    protected NPCStates currentState
    {
        get
        {
            return _currentState;
        }
        set
        {
            if (value != _currentState)
            {
                _lastState = _currentState;
                
                switch(value)
                {
                    case NPCStates.IDLE:
                        break;
                    case NPCStates.PATROL:
                        break;
                    case NPCStates.CALL:
                        Invoke("FinishCall", _currentDuration);
                        break;
                    case NPCStates.RUNAWAY:
                        break;
                }
                _currentState = value;
            }
        }
    }
    private NPCStates _currentState = NPCStates.PATROL;
    private NPCStates _lastState = NPCStates.IDLE;

    public GameObject EdgeChecker;
    private float _currentDuration;
    private bool _movingRight = true;

    protected override void Update()
    {
        base.Update();

        NPCBehavior();
    }

    private void NPCBehavior()
    {
        switch(currentState)
        {
            case NPCStates.IDLE:
                Debug.Log("Nothing");
                break;
            case NPCStates.PATROL:
                if(_movingRight)
                {
                    MoveRight(MoveSpeed);
                }
                else
                {
                    MoveLeft(MoveSpeed);   
                }
                Collider2D obstacle = Physics2D.OverlapCircle(new Vector2(EdgeChecker.transform.position.x, EdgeChecker.transform.position.y), 0.1f);
                if (obstacle)
                {
                    if(obstacle.tag == "Wall")
                    {
                        _movingRight = !_movingRight;
                    }
                }
                break;
            case NPCStates.CALL:
                
                break;
            case NPCStates.RUNAWAY:
                Debug.Log("Retreat!");
                break;
            default:
                Debug.LogWarning("That stated doesn't exist in this context.");
                break;
        }
    }

    private void FinishCall()
    {
        currentState = _lastState;
    }

    public override void Call(float duration, TalkBubbleTypes currentType)
    {
        base.Call(duration, currentType);
        _currentDuration = duration;
        currentState = NPCStates.CALL;
    }
}