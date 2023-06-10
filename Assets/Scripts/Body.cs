using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public bool toggleAI;
    public Controller controller;
    private AI ai;

    private void Start()
    {
        ai = gameObject.GetComponent<AI>();
        if (ai != null)
        {
            ai.AttachController(controller);
        }
    }

    // Sets the state of its ai automatically
    public void SetAIState()
    {
        ai.SetState();
    }

    public void SetAIState(AI.AIState state)
    {
        ai.SetState(state);
    }
}
