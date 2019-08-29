using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Change color of objects in the scene
/// </summary>
public class Block : MonoBehaviour
{
	#region Variables
    private MeshRenderer myRend;

    #endregion

    /// <summary>
	/// Setting random color to objects to be picked in the scene
	/// </summary>
    private void Start()
    {
        myRend = GetComponent<MeshRenderer>();
        myRend.material.color = Random.ColorHSV();
    }
}