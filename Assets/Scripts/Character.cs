﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    private float speed;

    public Animator animator;

    protected Vector2 direction;

    void Start()
    {

    }

    protected virtual void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime);

        if (direction.x != 0 || direction.y != 0)
        {
            AnimateMovement(direction);
        }
        else
        {
            animator.SetLayerWeight(1, 0);
        }
    }


    public void AnimateMovement(Vector2 direction)
    {
        animator.SetLayerWeight(1, 1);

        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
    }
}