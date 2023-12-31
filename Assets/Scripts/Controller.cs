using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Body body;

    public void AttachToBody(Body body)
    {
        this.body = body;
    }

    public void Move(Vector3 direction)
    {
        body.transform.position = body.transform.position += direction.normalized * Time.deltaTime * body.moveSpeed;
    }

    public void UseAbility(int index, Vector3 position)
    {
        body.UseAbility(index, position);
    }

    public void LookAt(Vector3 point)
    {
        LookTo(point - this.body.transform.position);
    }

    public void LookTo(Vector2 direction)
    {
        body.SpriteTransform.rotation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90, Vector3.forward);
    }

}
