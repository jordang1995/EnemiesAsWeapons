using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public Body user;
    public float coolDown;

    private float nextHitTime;

    private void Start()
    {
        nextHitTime = Time.time + coolDown;
    }

    public void UseAbility(Vector3 position)
    {
        if (IsOnCoolDown()) return;
        nextHitTime = Time.time + coolDown;
        List<Body> bodiesHit = new List<Body>();
        AddHits(bodiesHit, position);
        if (bodiesHit.Count > 0)
        {
            HitBodies(bodiesHit);
        }
    }

    public bool IsOnCoolDown()
    {
        return !(Time.time >= nextHitTime);
    }

    public abstract void AddHits(List<Body> bodiesHit, Vector3 position);
    public abstract void HitBodies(List<Body> bodiesHit);
}
