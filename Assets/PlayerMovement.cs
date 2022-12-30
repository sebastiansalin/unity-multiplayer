using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class PlayerMovement : NetworkBehaviour
{
    public float speed = 2.0f;
    //public GameObject PlayerModel;

    // private void Start()
    // {
    //     PlayerModel.SetActive(false);
    // }

    private void Update() {
        
        if(hasAuthority){
                Movement();
        }

        // if(SceneManager.GetActiveScene().name == "Scene_SteamworksGame"){
        //     if(PlayerModel.activeSelf == false){
        //         PlayerModel.SetActive(true);
        //     }

        //     if(hasAuthority){
        //         Movement();
        //     }

        // }
    }
    public void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        

        Vector3 movement = new Vector3(horizontal, vertical);

        transform.position += movement * speed * Time.deltaTime;

    }
}
