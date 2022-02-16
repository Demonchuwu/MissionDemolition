/***
 * Created by: Cristian Misla
 * Date Created: 2/16/2022
 * 
 * 
 * Last Edited by: Cristian Misla
 * Last Edited: 2/16/2022
 * Description: Put Rigidbody to sleep
 ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] //adds a rigidbody
public class RigidbodySleep : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null) rb.Sleep(); //if there isnt a rigibody, it does nothing.

    }//end Start()

    
}
