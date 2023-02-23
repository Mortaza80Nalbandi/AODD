using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordsman : MonoBehaviour
{
    public int health;
    int damage;
    float speed = 0.01f;
    public string  action;
    
    // Start is called before the first frame update
    void Start()
    {
        action = "move";
    }

    // Update is called once per frame
    void Update()
    {
        if(action =="move"){
            transform.Translate (speed, 0f, 0f); 
	    }else if(action =="attack"){
            
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
	{
         action = "attack";
	}
    public void damaged(int damageReceived){
        health-=damageReceived;
    }
}
