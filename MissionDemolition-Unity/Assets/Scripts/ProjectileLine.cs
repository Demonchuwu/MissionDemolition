/***
 * Created by: Cristian Misla
 * Date Created: 2/16/2022
 * 
 * 
 * Last Edited by: Cristian Misla
 * Last Edited: 2/16/2022
 * Description: Create line behind projectile
 ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLine : MonoBehaviour
{
    /*** VARIABLES ***/
    static public ProjectileLine S; //Singleton 

    [Header("Set in Inspector")]
    public float minDist = 0.1f;

    private LineRenderer line;
    private GameObject _poi;
    private List<Vector3> points;


    private void Awake()
    {
        S = this; //Sets the singleton
        line = GetComponent<LineRenderer>(); //reference to lineRenderer
        line.enabled = false; //diable LineRender
        points = new List<Vector3>(); //new list


    }//end Awake()
    public GameObject poi
    {
        get { return (_poi);  }
        set { _poi = value; 
                if(_poi != null)
            {
                line.enabled = false;
                points = new List<Vector3>();
                AddPoint();
            }//end if
        }//end set
    }//end GameObject poi

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
