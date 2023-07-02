using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Body target;
    public Body body;
    public List<NavMesh.Node> path = new List<NavMesh.Node>();
    public float pathingFrequency;

    private float nextPathing;

    private void Start()
    {
        nextPathing = Time.time;
    }

    public void Delegate()
    {
        if (SeesTarget())
        {
            body.controller.LookAt(target.transform.position);
            // move towards target
        }
        else
        {
            if (Time.time >= nextPathing)
            {
                // path
                nextPathing = Time.time + pathingFrequency;
            }
            // move in path
        }
    }

    public bool SeesTarget()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(body.transform.position, (target.transform.position - body.transform.position), Mathf.Infinity, LayerMask.GetMask("Hittable"));
        foreach (RaycastHit2D hit in hits)
        {
            Body bodyHit = (hit.collider.gameObject.GetComponent<Body>());
            if (bodyHit != null && bodyHit == target)
            {
                return true;
            }
        }
        return false;
    }

    public void SetTarget(Body target)
    {
        this.target = target;
    }
}
