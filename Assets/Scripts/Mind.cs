using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mind : MonoBehaviour
{
    public Body host;

    public void MigrateHost(Body newHost)
    {
        if (host != null)
        {
            host.SetAIState();
        }
        host = newHost;
        gameObject.transform.SetParent(host.gameObject.transform);
        host.SetAIState(AI.AIState.Disabled);
    }
}
