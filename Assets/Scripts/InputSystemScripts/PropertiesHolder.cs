using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PropertiesHolder : NetworkBehaviour
{

    public GameObject playerProperties;
    public override void OnStartAuthority()
    {
        playerProperties.SetActive(true);
    }
}
