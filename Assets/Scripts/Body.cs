using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public Controller controller;
    public bool toggleAI;
    private AI ai;
    public float moveSpeed;
    public List<Ability> abilities;

    private void Start()
    {
        ai = gameObject.GetComponent<AI>();
        controller.AttachToBody(this);
    }

    public void UseAbility(int index)
    {
        Debug.Log(this + " used Ability " + index);
        abilities[index].UseAbility();
    }
}
