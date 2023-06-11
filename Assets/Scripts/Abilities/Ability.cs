using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public Body user;

    public void UseAbility()
    {
        List<Body> bodiesHit = new List<Body>();
        AddHits(bodiesHit);
        if (bodiesHit.Count > 0)
        {
            HitBodies(bodiesHit);
        }
    }

    public abstract void AddHits(List<Body> bodiesHit);
    public abstract void HitBodies(List<Body> bodiesHit);
}
