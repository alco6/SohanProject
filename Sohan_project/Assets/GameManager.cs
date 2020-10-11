using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    static int SceneNumber;
    public GameObject cursorGO;

    static int countPlays=0;

    public Vector3 position1;
    public Vector3 position2;



    // Start is called before the first frame update
    void Start()
    {
        cursorGO.GetComponent<ManagerCursor>().onSelectedItem += WinnerSelectedGO;
        
        //Load Prefabs as GameObjects
        GameObject[] allMaps = Resources.LoadAll<GameObject>("Prefabs");
        //Generate 2 random numbers that will be the indexes of the selected GOs
        Tuple<int, int> indexes= Generate2Randoms(allMaps.Length -1);
        //Instantiate the GOs 
       // Instantiate(allMaps[indexes.Item1], position1, Quaternion.identity);
       // Instantiate(allMaps[indexes.Item2], position2, Quaternion.identity);
        //Place them in the right position

        Debug.Log("Statick" + countPlays); 
    }



    public Tuple<int, int> Generate2Randoms(int len)
    {
        int a;
        int b;
        a = UnityEngine.Random.Range(0, len);
        b = UnityEngine.Random.Range(0, len );
        while (a == b)
        {
            b = UnityEngine.Random.Range(0, len);
        }
        Tuple<int,int> tupleout= new Tuple<int,int> (a,b);
        Debug.Log("a  " + a + "b " + b); 
        return tupleout; 
    }


    private void WinnerSelectedGO(int id)
    {
        ChangeScene(1);
        countPlays++;
    }


    // Update is called once per frame
     void Update()
    {
  

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }


    public void QuitGame()
    {
        // save any game data here
        #if UNITY_EDITOR
                // Application.Quit() does not work in the editor so
                // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                 Application.Quit();
        #endif
    }



    void ChangeScene(int scenenumber)
    {
        SceneManager.LoadScene(scenenumber);
        SceneNumber = scenenumber;
    }
}
