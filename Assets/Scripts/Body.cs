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
    public float maxHealth;
    public float health;
    public Transform healthBar;
    public Transform SpriteTransform;

    private void Start()
    {
        ai = gameObject.GetComponent<AI>();
        controller.AttachToBody(this);
        health = maxHealth;
    }

    public void UseAbility(int index)
    {
        Debug.Log(this + " used Ability " + index);
        abilities[index].UseAbility();
    }

    public void TakeDamage(int damage)
    {
        health = Mathf.Max(health - damage, 0);
        healthBar.transform.localScale = new Vector3(health / maxHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        Debug.Log(this + " has " + health + " health.");
    }
}
