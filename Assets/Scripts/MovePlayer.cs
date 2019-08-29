using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Move Player
/// </summary>
public class MovePlayer : MonoBehaviour
{
     #region Variables
     Vector3 playerMovementH;
     Vector3 playerMovementV;
     Rigidbody playerRB;
     float moveSpeed =1.0f;
     Animation movePlayer;

     #endregion

     #region Methods
     
     private void Awake()
     {
          playerRB = GetComponent<Rigidbody>();
          movePlayer = GetComponent<Animation>();
     }

     /// <summary>
     /// Get user keyborad input to moce the player - use awsd keys or arrow keys on the keyboard
     /// </summary>
     void Update ()
     {
          float h = Input.GetAxisRaw("Horizontal"); // left and right
          float v = Input.GetAxisRaw("Vertical"); //up and down

          if(h>0f){
               movePlayer.CrossFade("walk_right");
               playerMovementH.Set(0f, 0f, h);
               playerMovementH = playerMovementH * moveSpeed * Time.deltaTime;
               playerRB.MovePosition(transform.position + playerMovementH);
          }
          if(h<0f){
               movePlayer.CrossFade("walk_left");
               playerMovementH.Set(0f, 0f, h);
               playerMovementH = playerMovementH * moveSpeed * Time.deltaTime;
               playerRB.MovePosition(transform.position + playerMovementH);
          }
          if(v>0f || v<0){
               movePlayer.CrossFade("walk");
               playerMovementV.Set(-v, 0f, 0f);
               playerMovementV = playerMovementV * moveSpeed * Time.deltaTime;
               playerRB.MovePosition(transform.position + playerMovementV);
          }
          if(Input.GetKeyDown("space")){     //turn around the player by 180 degrees by hitting the spacebar
               transform.Rotate(0, 180, 0);
          }
          
     }

     #endregion
     
}
