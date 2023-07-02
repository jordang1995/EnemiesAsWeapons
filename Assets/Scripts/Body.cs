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

    private void Update()
    {
        if (toggleAI)
        {
            ai.Delegate();
        }
    }

    public void UseAbility(int index, Vector3 position)
    {
        abilities[index].UseAbility(position);
    }

    public void Die()
    {
        Mind.mind.deadBodyEvent.Invoke(this);
        GameObject.Destroy(this.gameObject);
    }

    public void TakeDamage(float damage)
    {
        health = Mathf.Max(health - damage, 0);
        healthBar.transform.localScale = new Vector3(health / maxHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        if (health <= 0)
        {
            Die();
        }
    }
}
