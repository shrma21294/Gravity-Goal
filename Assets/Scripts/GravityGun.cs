using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gravity Gun
/// </summary>
public class GravityGun : MonoBehaviour
{
    #region Variables
    public Camera cam;
    public float interactDist; //distance between hold position and the object

    public Transform holdPos; //Positon at which object is set in front of the gravity gun
    public float attractSpeed;

    public float minThrowForce;
    public float maxThrowForce;
    private float throwForce;

    private GameObject objectIHave; //object at hold position
    private Rigidbody objectRB; //rigidbody connected to the object

    private Vector3 rotateVector = Vector3.one;

    private bool hasObject = false; //check object at hold position 

    Animation fightPos;

    public GameObject gravityGun1;
    public GameObject gravityGun2;

    AudioSource shoot; // Shoot sound effect 

    #endregion

    #region Methods
    /// <summary>
    /// Use this for initialization
    /// </summary>
    private void Start()
    {
        throwForce = minThrowForce;
        fightPos = GetComponent<Animation>();
        shoot = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Checking for input from the user at every frame
    /// </summary>
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !hasObject)
        {
            DoRay();
        }

        if (Input.GetMouseButton(1) && hasObject)
        {
            throwForce += 0.1f;
        }

        if (Input.GetMouseButtonUp(1) && hasObject)
        {
            ShootObj();
        }

        if(Input.GetKeyDown(KeyCode.G) && hasObject)
        {
            DropObj();
        }

        if (hasObject)
        {
            RotateObj();

            if(CheckDist() >= 1f)
            {
                MoveObjToPos();
            }
        }



    }

    /// <summary>
    /// Calculation of rotation vector
    /// </summary>
    private void CalculateRotVector()
    {
        float x = Random.Range(-0.5f, 0.5f);
        float y = Random.Range(-0.5f, 0.5f);
        float z = Random.Range(-0.5f, 0.5f);

        rotateVector = new Vector3(x, y, z);
    }

    /// <summary>
    /// Rotating the object from the center
    /// </summary>
    private void RotateObj()
    {
        objectIHave.transform.Rotate(rotateVector);
    }

    /// <summary>
    /// Calculating distance between object and hold position
    /// </summary>
    public float CheckDist()
    {
        float dist = Vector3.Distance(objectIHave.transform.position, holdPos.transform.position);
        return dist;
    }

    /// <summary>
    /// Moving the object to the hold positon
    /// </summary>
    private void MoveObjToPos()
    {
        objectIHave.transform.position = Vector3.Lerp(objectIHave.transform.position, holdPos.position, attractSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Droping the object
    /// </summary>
    private void DropObj()
    {
        objectRB.constraints = RigidbodyConstraints.None;
        objectIHave.transform.parent = null;
        objectIHave = null;
        hasObject = false;
    }

    /// <summary>
    /// Shooting the object
    /// </summary>
    private void ShootObj()
    {
        shoot.Play();
        throwForce = Mathf.Clamp(throwForce, minThrowForce, maxThrowForce);
        objectRB.AddForce(cam.transform.forward * throwForce, ForceMode.Impulse);
        throwForce = minThrowForce;
        DropObj();
        if(gravityGun1)
            gravityGun1.SetActive(false);
        if(gravityGun2)    
            gravityGun2.SetActive(false);
        fightPos.CrossFade("idle");
    }

    /// <summary>
    /// Casting ray to get the object in the scene, setting it's parent as hold position
    /// </summary>
    private void DoRay()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDist))
        {
            if (hit.collider.CompareTag("Block"))
            {
                fightPos.CrossFade("idle_fight");
                int changeGun = Random.Range(0,2);
                if(changeGun == 0){
                    gravityGun1.SetActive(true);
                    }else{
                        gravityGun2.SetActive(true);
                    }
                
                objectIHave = hit.collider.gameObject;
                objectIHave.transform.SetParent(holdPos);
                objectIHave.transform.position = holdPos.position; 

                objectRB = objectIHave.GetComponent<Rigidbody>();
                objectRB.constraints = RigidbodyConstraints.FreezeAll;

                hasObject = true;

                CalculateRotVector();
            }
        }

    }

    #endregion

}