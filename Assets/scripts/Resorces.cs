using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Resorces : MonoBehaviour
{
    private int resource;

    // Start is called before the first frame update
    void Start()
    {
        resource = 0;

        GameObject.Find("Resorces").GetComponent<Text>().text = "Resources : "+ resource.ToString (); 

    }

    // Update is called once per frame
    void Update()
    {
        
             GameObject.Find("Resorces").GetComponent<Text>().text = "Resources : "+ resource.ToString (); 
    }
    public void setResourse(int s){
        resource = s;
    }
    
}
