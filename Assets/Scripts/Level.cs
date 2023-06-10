using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Mind mind;
    public Body startingHost;

    private void Start()
    {
        mind.MigrateHost(startingHost);
    }
}
