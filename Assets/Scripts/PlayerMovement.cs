using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

// Controls player movement such that player inputs only control their own character.
public class PlayerMovement : NetworkBehaviour
{
    public float speed = 2.0f;

    private void Update()
    {
        if(hasAuthority)
        {
            Movement();
        }
    }
    public void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        

        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);

        transform.position += movement * speed * Time.deltaTime;

    }
}
