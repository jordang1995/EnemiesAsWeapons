using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public enum AIState
    {
        Disabled, Enabled
    }

    public AIState state;
    private Controller controller;

    public void AttachController(Controller controller)
    {
        this.controller = controller;
    }

    // Sets the state of this ai automatically
    public void SetState()
    {
        state = AIState.Enabled;
    }

    public void SetState(AIState state)
    {
        this.state = state;
    }

}
