using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Player player;
    void Start()
    {
        player = GetComponent<Player>();
    }

 
    void Update()
    {
        if(Input.GetButtonDown("Jump") && player.isGrounded) //spaceye basınca zıpla,ve isgrounded yanii yere bir kere degerse o zaman zıpla
        {                                                    //amacı sonsuz zıplamayı engellemek
            player.Jump();
            player.doubleCanJump = true;

        }
        else if(Input.GetButtonDown("Jump") && !player.isGrounded && player.doubleCanJump)
        {
            player.DoubleJump();
            player.doubleCanJump = false;
            
        }
        
    }
}
