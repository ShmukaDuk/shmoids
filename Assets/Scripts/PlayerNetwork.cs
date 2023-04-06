using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    public CharacterController2D controller;
    float horizontal_move = 0;
    float vertical_move = 0;
    private void Update()
    {
        if (!IsOwner) return;
        horizontal_move = Input.GetAxisRaw("Horizontal");
        vertical_move = Input.GetAxisRaw("Vertical");
    }
    private  void FixedUpdate()
    {
        if (!IsOwner) return;
        controller.Move(horizontal_move * Time.fixedDeltaTime, vertical_move * Time.fixedDeltaTime, false);
    }
}
