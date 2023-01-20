using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class CameraController : NetworkBehaviour
{
    public GameObject cameraHolder;
    public Vector3 offset;

    // Activates the camera of a player. This makes it so that players only control their character's camera.
    public override void OnStartAuthority()
    {
        cameraHolder.SetActive(true);
    }

    public void Update()
    {
        if(SceneManager.GetActiveScene().name == "Scene_SteamworksGame"){
            cameraHolder.transform.position = transform.position + offset;
        }
    }
}
