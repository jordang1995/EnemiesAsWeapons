using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public Controller controller;
    public bool toggleAI;
    private AI ai;
    public float moveSpeed;

    private void Start()
    {
        ai = gameObject.GetComponent<AI>();
        controller.AttachToBody(this);
    }

    public void UseBasicAttack()
    {

    }

    public void UseMigrateHost()
    {
        Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D[] hits = Physics2D.CircleCastAll(position, 0.0625f, Vector2.zero);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                Mind.mind.MigrateHost(hit.collider.gameObject.GetComponent<Body>());
                break;
            }
        }
    }

    public void UseAbility(int index)
    {
        Debug.Log(this + " used Ability " + index);
        switch (index)
        {
            case 0:
                UseMigrateHost();
                break;
            case 1:
                UseBasicAttack();
                break;
            case 2:
                break;
            case 4:
                break;
            default:
                break;
        }
    }
}
