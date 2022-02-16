/***
 * Created by: Cristian Misla
 * Date Created: 2/8/2022
 * 
 * 
 * Last Edited by: Cristian Misla
 * Last Edited: 2/15/2022
 * Description: Control for Sling Shot
 ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    /*** VARIABLES ***/
    [Header("Set in Inspector")]
    public GameObject prefabProjectile;
    public float velocityMultipler = 8f;

    [Header("Set Dynamically")]
    public GameObject launchPoint;
    public Vector3 launchPos; //Launch position of projectile 
    public GameObject projectile; //Instance of Projectile
    public bool aimingMode; //Is player aiming or not
    public Rigidbody projectileRB; //Rigidbody of Projectile



    private void Awake()
    {
        Transform launchPointTrans = transform.Find("LaunchPoint");//find child object
        
        launchPoint = launchPointTrans.gameObject;//the game object of child object
        launchPoint.SetActive(false);//disabled game object
        launchPos = launchPointTrans.position;
    }//end Awake()

    private void Update()
    {
        if (!aimingMode) return;

        //Get the current mouse pos in 2d screen coordinates
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 mouseDelta = mousePos3D - launchPos; //pixel amount of change between the mouse3d and launchPos

        //Limit mouseDelta to slingshot collider radius
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;

        if(mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize(); //Sets the vector to the same direction but length is 1.0
            mouseDelta *= maxMagnitude;
        }//end if(mouseDelta.magnitude > maxMagnitude)

        //move projectile to this new pos
        Vector3 ProjPos = launchPos + mouseDelta;
        projectile.transform.position = ProjPos;

        if(Input.GetMouseButtonUp(0))
        {
            aimingMode = false;
            projectileRB.isKinematic = false;
            projectileRB.velocity = -mouseDelta * velocityMultipler;
            FollowCam.POI = projectile;
            projectile = null; //forget the last instance
        }

    }//end Update()


    private void OnMouseEnter()
    {
        //print("Slingshot: OnMouseEnter");
        launchPoint.SetActive(true);//enabled game object
    }//end OnMouseEnter()

    private void OnMouseExit()
    {
        //print("Slingshot: OnMouseExit");
        launchPoint.SetActive(false);//disabled game object
    }//end OnMouseExit()

    private void OnMouseDown()
    {
        aimingMode = true;
        projectile = Instantiate(prefabProjectile) as GameObject;
        projectile.transform.position = launchPos;
        projectileRB = projectile.GetComponent<Rigidbody>();
        projectileRB.isKinematic = true;
    }//end OnMouseDown()

}
