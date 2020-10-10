using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject cursor;
    public GameObject[] targets; 
    Vector3 worldPosition;
    public GameObject GOSelected;

    static int SceneNumber;

    // Start is called before the first frame update
    void Start()
    {
        //Set Cursor to not be visible
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneNumber == 0)
        {
            CursorPosToWorldPos();
            CheckCursorPosition();
        }
        else
        {
            StartCoroutine(WaitAndNextCoroutine());
        }

    }


    IEnumerator WaitAndNextCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        ChangeScene(0); 
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
                    ChangeScene(1);

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



    void ChangeScene(int scenenumber)
    {
        SceneManager.LoadScene(scenenumber);
        SceneNumber = scenenumber;
    }




}
