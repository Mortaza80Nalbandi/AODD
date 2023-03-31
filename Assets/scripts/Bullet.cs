using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damage ;
    // Start is called before the first frame update
    void Start()
    {
        damage = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void setDamage(float damage){
        this.damage = damage;
    }
    public float getDamage(){
        return damage;
    }
}
