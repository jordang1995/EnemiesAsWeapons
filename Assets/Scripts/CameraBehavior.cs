using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{

    public Transform follow;

    private void Update()
    {
        transform.position = new Vector3(follow.position.x , follow.position.y, transform.position.z);
    }
}
