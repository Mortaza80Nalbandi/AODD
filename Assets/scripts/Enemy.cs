using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    int damage;
    float speed = 0.01f;
    public string  action;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        damage = 5;
        action = "move";
    }

    // Update is called once per frame
    void Update()
    {
        if(action =="move"){
            transform.Translate (-1*speed, 0f, 0f);
        }else if(action =="attack"){
            
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
	{
         action = "attack";
	}
    public void damaged(int damageReceived){
        health-=damageReceived;
    }
}
