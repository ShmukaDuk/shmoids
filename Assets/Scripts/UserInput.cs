using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public CharacterController2D controller;
    // Start is called before the first frame update
    float horizontal_move = 0;
    float vertical_move = 0;

    // Update is called once per frame
    void Update()
    {
        horizontal_move = Input.GetAxisRaw("Horizontal");
        vertical_move = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        controller.Move(horizontal_move * Time.fixedDeltaTime, vertical_move * Time.fixedDeltaTime, false);
    }
}
