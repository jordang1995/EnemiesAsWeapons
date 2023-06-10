using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    void Update()
    {
        switch (Mind.mind.gameState)
        {
            case Mind.GameState.Paused:
                HandleInputPaused();
                break;

            case Mind.GameState.Running:
                HandleInputRunning();
                break;
        }
    }

    public void HandleInputRunning()
    {
        Mind.mind.host.controller.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        Mind.mind.host.controller.Move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));

        if (Input.GetMouseButtonDown(0))
        {
            Mind.mind.host.controller.UseAbility(1);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Mind.mind.host.controller.UseAbility(0);
        }
    }

    public void HandleInputPaused()
    {

    }
}
