using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int health;
    int damage;
    float speed = 0.06f;
    // Start is called before the first frame update
    void Start()
    {
        health = 100000;
        damage = 5;
        speed = 0.06f;
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKey(KeyCode.D))
        {
           transform.Translate (speed, 0f, 0f); 
        }else if (Input.GetKey(KeyCode.A))
        {
           transform.Translate (-1*speed, 0f, 0f); 
        }
        else if (Input.GetKey(KeyCode.F))
        {
           damage++;
        }
        if(health<=0){
            Destroy(gameObject);
        }
    }
    public void damaged(int damageReceived){
        health-=damageReceived;
    }
}
