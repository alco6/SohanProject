using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCursor : MonoBehaviour
{
    public GameObject cursor;
    public GameObject[] targets; 
    Vector3 worldPosition;
    public GameObject GOSelected;

    public event Action<int> onSelectedItem;



    // Start is called before the first frame update
    void Start()
    {
        //Set Cursor to not be visible
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
         CursorPosToWorldPos();
         CheckCursorPosition();
    }


    void CursorPosToWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        cursor.transform.position = new Vector3(worldPosition.x, worldPosition.y, 0);

    }

    void CheckCursorPosition()
    {
        foreach (GameObject targetgo in targets)
        {
            if ((targetgo.transform.position - cursor.transform.position).magnitude < 3.0f)
            {

                targetgo.GetComponent<Target>().Inside();
                if (targetgo.GetComponent<Target>().currentState == Target.State.Commited)
                {
                    //Debug.Log("bravooo!! " + targetgo);
                    GOSelected = targetgo;
                    DontDestroyOnLoad(GOSelected);
                    GOSelected.transform.position = new Vector3(0, 0, 0);
                    GOSelected.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                    
                    onSelectedItem(1);
                    //Debug.Log("targetgo.GetInstanceID()" + targetgo.GetInstanceID());
                }
            }
            else
            {
                if (targetgo.GetComponent<Target>().currentState != Target.State.Unselected)
                {
                    targetgo.GetComponent<Target>().Outside();
                }
            }
        }
    }



    




}
