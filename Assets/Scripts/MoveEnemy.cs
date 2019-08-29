 using System.Collections;
 using UnityEngine;
 
 /// <summary>
/// Move the enemy
/// </summary>
 public class MoveEnemy : MonoBehaviour
 {
    #region Variables
    private float movementDuration = 2.0f;
     private float waitBeforeMoving = 2.0f;
     private bool hasArrived = false;
     private Coroutine moveCoroutine = null;

     #endregion
 
    #region Methods
     /// <summary>
    /// Calculating random x and z for enemy to move
    /// </summary>
     private void Update()
     {
         if (!hasArrived)
         {
             hasArrived = true;
             float randX = Random.Range(-5.0f, 5.0f);
             float randZ = Random.Range(-5.0f, 5.0f);
             moveCoroutine = StartCoroutine(MoveToPoint(new Vector3(randX, 0.2f, randZ)));
         }
         if (Input.GetMouseButtonDown(0))
             StopMovement();
     }
 
    /// <summary>
    /// Moving enemy to a random point 
    /// </summary>
     private IEnumerator MoveToPoint(Vector3 targetPos)
     {
         float timer = 0.0f;
         Vector3 startPos = transform.position;
 
         while (timer < movementDuration)
         {
             timer += Time.deltaTime;
             float t = timer / movementDuration;
             t = t * t * t * (t * (6f * t - 15f) + 5f);
             transform.position = Vector3.Lerp(startPos, targetPos, t);
 
             yield return null;
         }
 
         yield return new WaitForSeconds(waitBeforeMoving);
         hasArrived = false;
     }
 
    /// <summary>
    /// On mouse left click, stop movement of the enemy
    /// </summary>
     private void StopMovement()
     {
         if (moveCoroutine != null)
             StopCoroutine(moveCoroutine);
     }
 
     #endregion
 }