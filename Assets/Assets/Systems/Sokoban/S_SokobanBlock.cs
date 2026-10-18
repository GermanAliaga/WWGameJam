using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S_SokobanBlock : MonoBehaviour
{
    [SerializeField] private BoxCollider2D col;
    [SerializeField] private List<AnimationClip> AnimList;
    [SerializeField] private Animation anim;
    [SerializeField] private S_SokobanManager.Dir PushDir;
    [SerializeField] private List<S_BlockCollider> BlockCol;
    [SerializeField] private Animator animator;

    public void PlayAnimation(S_SokobanManager.Dir dir)
    {
        switch (dir)
        {
            case S_SokobanManager.Dir.None:
                anim.clip = AnimList[0];
                animator.SetInteger("Horizontal", 0);
                animator.SetInteger("Vertical", 0);
                animator.SetBool("canPush", false);
                break;

            case S_SokobanManager.Dir.Up:
                anim.clip = AnimList[1];
                animator.SetInteger("Horizontal", 0);
                animator.SetInteger("Vertical", 1);
                animator.SetBool("canPush", true);
                break;

            case S_SokobanManager.Dir.Down:
                anim.clip = AnimList[2];
                animator.SetInteger("Horizontal", 0);
                animator.SetInteger("Vertical", -1);
                animator.SetBool("canPush", true);
                break;

            case S_SokobanManager.Dir.Right:
                anim.clip = AnimList[3];
                animator.SetInteger("Horizontal", 1);
                animator.SetInteger("Vertical", 0);
                animator.SetBool("canPush", true);
                break;

            case S_SokobanManager.Dir.Left:
                anim.clip = AnimList[4];
                animator.SetInteger("Horizontal", -1);
                animator.SetInteger("Vertical", 0);
                animator.SetBool("canPush", true);
                break;
        }
        //anim.Play();
    }

    public void SetPushDirAnim(S_SokobanManager.Dir dir)
    {
        PushDir = dir;
        switch (PushDir)
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
    }
    public bool CheckAhead()
    {
        bool value = false;
        if(PushDir != S_SokobanManager.Dir.None)
        {
            switch (PushDir)
            {
                case S_SokobanManager.Dir.Up:
                    if (!BlockCol[0].willOverlap)
                    {
                        value = true;
                    }
                    else { Debug.Log("Up bloqued"); }
                    break;

                case S_SokobanManager.Dir.Down:
                    if (!BlockCol[1].willOverlap)
                    {
                        value = true;
                    }
                    else { Debug.Log("Down bloqued"); }
                    break;

                case S_SokobanManager.Dir.Right:
                    if (!BlockCol[2].willOverlap)
                    {
                        value = true;
                    }
                    else { Debug.Log("Right bloqued"); }
                    break;

                case S_SokobanManager.Dir.Left:
                    if (!BlockCol[3].willOverlap)
                    {
                        value = true;
                    }
                    else { Debug.Log("Left bloqued"); }
                    break;
            }
        }
        return value;
    }

    public void OnPushAnimationStart()
    {
        //col.enabled = false;
    }
    public void OnPushAnimationEnd()
    {
        //col.enabled = true;
        animator.SetInteger("Horizontal", 0);
        animator.SetInteger("Vertical", 0);
        animator.SetBool("canPush", false);
    }
}
