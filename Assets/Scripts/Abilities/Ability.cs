using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Ability : MonoBehaviour
{
    public float coolDown;
    public Body user;

    private float nextHitTime;

    private void Start()
    {
        user = gameObject.GetComponent<Body>();
        nextHitTime = Time.time + coolDown;
    }

    public void TryUseAbility(Vector3 position)
    {
        if (IsOnCoolDown()) return;
        nextHitTime = Time.time + coolDown;
        UseAbility(position);
    }

    public abstract void UseAbility(Vector3 position);

    public bool IsOnCoolDown()
    {
        return !(Time.time >= nextHitTime);
    }


   





















}
