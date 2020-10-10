using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject cursor;
 
    public GameObject[] targets; 

    Vector3 worldPosition; 
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        //Debug.Log("mouse position  : " + worldPosition.x + " , " + worldPosition.y);

        mousePos.z = 0;//Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        cursor.transform.position = new Vector3( worldPosition.x, worldPosition.y,0)  ;
        //Debug.Log("mouse position on scene : "+ worldPosition.x + " , " + worldPosition.y );  

        foreach (GameObject targetgo in targets)
        { 
            if ((targetgo.transform.position - cursor.transform.position).magnitude < 1.0f)
            {
                targetgo.GetComponent<Target>().TargetSelected();
            }
            else
            {
                if (targetgo.GetComponent<Target>().ObjectSelected)
                {
                    targetgo.GetComponent<Target>().TargetUnselected();

                }
            }
            
            

        }



    }

 


}
