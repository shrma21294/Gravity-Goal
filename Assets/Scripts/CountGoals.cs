using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Count number of goals
/// </summary>
public class CountGoals : MonoBehaviour
{
    #region Variables
    public Text countText;
    public GameObject goalText;

    private Rigidbody rb;
    private int count;

    #endregion

    #region Methods
    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        
    }

    /// <summary>
    /// The goal count increase if it hits the goal's collider and GOAL text is displayed
    /// </summary>
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ( "Block"))
        {
        	goalText.SetActive(true);
            count = count + 1;
            SetCountText ();
        }
    }

    /// <summary>
    /// The GOAL text is is set to false after the goal
    /// </summary>
    void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.CompareTag ( "Block"))
        {
        	goalText.SetActive(false);
        }
    }

    /// <summary>
    /// The goal count is set 
    /// </summary>
    void SetCountText ()
    {
        countText.text = count.ToString ();
    }

    #endregion
}
