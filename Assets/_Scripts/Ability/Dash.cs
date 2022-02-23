using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability")]
public class Dash : Ability
{
    public float dashVelocity;

    public override void Activate(GameObject parent)
    {
        PlayerBehaviour movement = parent.GetComponent<PlayerBehaviour>();
        Rigidbody rigibody = parent.GetComponent<Rigidbody>();

        rigibody.velocity = movement.moveDirection.normalized * dashVelocity;
    }
}
