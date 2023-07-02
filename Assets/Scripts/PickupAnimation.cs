using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAnimation : MonoBehaviour
{
    public float speed;
    public float min;
    public float max;

    private bool up;
    private float offset;
    private float start;

    private void Start()
    {
        up = true;
        offset = 0;
        start = transform.position.y;
    }

    private void Update()
    {
        if (up)
        {
            offset += speed * Time.deltaTime;
        }
        else
        {
            offset -= speed * Time.deltaTime;
        }
        if (offset >= max)
        {
            up = false;
        }
        else if (offset <= min)
        {
            up = true;
        }

        gameObject.transform.position = new Vector3(gameObject.transform.position.x, start + offset, gameObject.transform.position.z);
    }
}
