using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    int health;
    int damage;
    float speed = 0.06f;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        damage = 5;
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
    }
}
