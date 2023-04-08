using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    public Animator animator;
    public CharacterController2D controller;
    Vector2 movement;

    private void Update()
    {
        if (!IsOwner) return;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        //dash
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(controller.Dash());
        }

    }
    private void FixedUpdate()
    {
        if (!IsOwner) return;
        controller.Move(movement.x * 30 * Time.fixedDeltaTime, movement.y * 30 * Time.fixedDeltaTime);
    }
}
