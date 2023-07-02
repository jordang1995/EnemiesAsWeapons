using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Body target;
    public Body body;
    public NavMesh navmesh;

    public float timer;

    private void Update()
    {
        timer -= Time.deltaTime;
        Debug.Log(timer);
        if (timer > 0)
        {
            return;
        }
        else
        {
            timer = 1f;
        }
        if (target == null)
        {
            return;
        }
        //navmesh.DrawPath(navmesh.GetPath(navmesh.GetClosestNode(body.transform.position), navmesh.GetClosestNode(target.transform.position)));
    }

    public void SetTarget(Body target)
    {
        this.target = target;
    }
}
