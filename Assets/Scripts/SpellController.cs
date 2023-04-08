using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    //dash
    [Range(0, 10f)] [SerializeField] private float CoolDownDash = 2f;
    public float currCooldownDash;

    public bool canDash = true;
    private void Awake()
    {
        currCooldownDash = CoolDownDash;
    }
    public void dash()
    {
        currCooldownDash = CoolDownDash;
        canDash = false;
    }
    public bool getCanDash()
    {
        return canDash;
    }
    private void FixedUpdate()
    {
        if (!canDash)
        {
            currCooldownDash -= Time.fixedDeltaTime;
        }       
        if (currCooldownDash <= 0.01f)
        {
            canDash = true;
        }
    }
}
