using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public bool ObjectSelected = false; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TargetSelected()
    {
        Material mate=gameObject.GetComponent<Renderer>().material; 
        mate.color = new Color(0.5f, 1, 1); //C#
        ObjectSelected = true; 
    }

    public void TargetUnselected()
    {
        Material mate = gameObject.GetComponent<Renderer>().material;
        mate.color = new Color(0, 0, 0); //C#
        ObjectSelected = false;

    }
}
