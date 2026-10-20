using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_PlayerSokobanController : MonoBehaviour
{
    [SerializeField] private bool isPushing;
    [SerializeField] private bool canPush;
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D rg;
    [SerializeField] private float playerSpeed;
    [SerializeField] S_SokobanManager.Dir PushDir;
    [SerializeField] GameObject CurrentBlock;
    [SerializeField] List<GameObject> blockList;

    [SerializeField] private List<AnimationClip> AnimList;
    [SerializeField] private Animation anim;

    [SerializeField] private Animator animator;
    [SerializeField] private float CooldownPush;
    float timeStamp;

    private Vector3 velocity;

    PlayerInput input;

    private void FixedUpdate()
    {
        //rg.MovePosition(new Vector2(rg.position.x+(velocity.x*playerSpeed), rg.position.y + (velocity.y * playerSpeed)));
        //player.transform.position += velocity*playerSpeed;
        if (canPush)
        {
            rg.linearVelocity = new Vector2(velocity.x * playerSpeed, velocity.y * playerSpeed);
            if ((velocity.x != 0 && velocity.y == 0) || (velocity.x == 0 && velocity.y != 0))
            {
                if (velocity.x == 1)
                {
                    PushDir = S_SokobanManager.Dir.Right;
                }
                else if (velocity.x == -1)
                {
                    PushDir = S_SokobanManager.Dir.Left;
                }
                else if (velocity.y == 1)
                {
                    PushDir = S_SokobanManager.Dir.Up;
                }
                else if (velocity.y == -1)
                {
                    PushDir = S_SokobanManager.Dir.Down;
                }
            }
            else
            {
                PushDir = S_SokobanManager.Dir.None;
            }
        }
        if (timeStamp <= Time.time) { canPush = true; }



    }

    public void SetDirPush(S_SokobanManager.Dir PushDir_)
    {
        //PushDir = PushDir_;
    }

    public void SetCurrentBlock(GameObject CurrentBlock_)
    {
        CurrentBlock = CurrentBlock_;
    }

    public void SetBlockOnList(GameObject Block, S_SokobanManager.Dir dir)
    {
        switch (dir)
        {
            case S_SokobanManager.Dir.Up:
                blockList[0] = Block;
                break;
            case S_SokobanManager.Dir.Down:
                blockList[1] = Block;
                break;
            case S_SokobanManager.Dir.Right:
                blockList[2] = Block;
                break;
            case S_SokobanManager.Dir.Left:
                blockList[3] = Block;
                break;
        }
    }

    public void PlayAnimation(S_SokobanManager.Dir dir)
    {
        switch (dir)
        {
            case S_SokobanManager.Dir.None:
                anim.clip = AnimList[0];
                break;

            case S_SokobanManager.Dir.Up:
                anim.clip = AnimList[1];
                break;

            case S_SokobanManager.Dir.Down:
                anim.clip = AnimList[2];
                break;

            case S_SokobanManager.Dir.Right:
                anim.clip = AnimList[3];
                break;

            case S_SokobanManager.Dir.Left:
                anim.clip = AnimList[4];
                break;
        }
        //anim.Play(anim.clip.name);
        animator.Play("AN_Idle", 0);
    }
    public void OnPushAnimationStart()
    {
        //isPushing = true;
        //rg.simulated = false;
    }
    public void OnPushAnimationEnd() 
    {
        //isPushing = false;
        //canPush = false;
        //rg.simulated = true;
    }


    private void OnMove(InputValue value)
    {
        velocity = new Vector3(0,0,0);
        
            Vector2 inputVel = value.Get<Vector2>();
            velocity = new Vector3(inputVel.x, inputVel.y, player.transform.position.z);
       
    }

    private void OnPush(InputValue value)
    {
        
        if ((velocity.x != 0 && velocity.y == 0) || (velocity.x == 0 && velocity.y != 0))
        {
            
            if (velocity.x == 1 && PushDir == S_SokobanManager.Dir.Right)
            {
                CurrentBlock = blockList[2];
                if (CurrentBlock.GetComponent<S_SokobanBlock>().CheckAhead()) {
                    CurrentBlock.GetComponent<S_SokobanBlock>().PlayAnimation(PushDir);
                    timeStamp = Time.time + CooldownPush;
                    canPush = false;
                }
            }
            else if (velocity.x == -1 && PushDir == S_SokobanManager.Dir.Left)
            {
                CurrentBlock = blockList[3];
                if (CurrentBlock.GetComponent<S_SokobanBlock>().CheckAhead())
                {
                    CurrentBlock.GetComponent<S_SokobanBlock>().PlayAnimation(PushDir);
                    timeStamp = Time.time + CooldownPush;
                    canPush = false;
                }
            }
            else if (velocity.y == 1 && PushDir == S_SokobanManager.Dir.Up)
            {
                CurrentBlock = blockList[0];
                if (CurrentBlock.GetComponent<S_SokobanBlock>().CheckAhead())
                {
                    CurrentBlock.GetComponent<S_SokobanBlock>().PlayAnimation(PushDir);
                    timeStamp = Time.time + CooldownPush;
                    canPush = false;
                }
            }
            else if (velocity.y == -1 && PushDir == S_SokobanManager.Dir.Down)
            {
                CurrentBlock = blockList[1];
                if (CurrentBlock.GetComponent<S_SokobanBlock>().CheckAhead())
                {
                    CurrentBlock.GetComponent<S_SokobanBlock>().PlayAnimation(PushDir);
                    timeStamp = Time.time + CooldownPush;
                    canPush = false;
                }
            }
        }

    }
    
}
