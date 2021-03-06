using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public Ability ability;

    float cooldownTime;
    float activeTime;

    enum AbilityState
    {
        Ready,
        Active,
        Cooldown
    }
    AbilityState state = AbilityState.Ready;

    public PlayerBehaviour pb;

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case AbilityState.Ready:
                if (pb.useDash)
                {
                    if (ability == null)
                        break;
                    ability.Activate(gameObject);
                    state = AbilityState.Active;
                    activeTime = ability.activeTime;
                }
                break;

            case AbilityState.Active:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.Cooldown;
                    cooldownTime = ability.cooldownTime;
                    pb.useDash = false;
                }
                break;

            case AbilityState.Cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.Ready;
                }
                break;

        }
        
    }
}
