using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    static int SceneNumber;
    public GameObject cursorGO;


    // Start is called before the first frame update
    void Start()
    {
        cursorGO.GetComponent<ManagerCursor>().onSelectedItem += WinnerSelectedGO;


        GameObject[] allMaps = Resources.LoadAll("Graphics/TARGETS/prefabs/") as GameObject[];
        Debug.Log("all prefabs " + allMaps.Length);

    }

    private void WinnerSelectedGO(int id)
    {
        Debug.Log("bravoo!");
        ChangeScene(1);

    }


    // Update is called once per frame
     void Update()
    {
        if (SceneNumber == 1)
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
    void ChangeScene(int scenenumber)
    {
        SceneManager.LoadScene(scenenumber);
        SceneNumber = scenenumber;
    }
}
