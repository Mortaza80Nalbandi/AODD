using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordsman : MonoBehaviour
{
    float attackrate = 1;
    public int health;
    int damage;
    float speed = 0.01f;
    public string  action;
    List<Enemy> enemies ;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        damage = 30;
        enemies = new List<Enemy>();
        action = "move";
    }

    // Update is called once per frame
    void Update()
    {
        if(action =="move"){
            transform.Translate (speed, 0f, 0f); 
	    }else if(action =="attack"){
            if(attackrate <= 0){
                enemies[0].damaged(damage);
                if(enemies[0].health<=0){
                    Destroy(enemies[0].gameObject);
                    enemies.RemoveAt(0);
                }
                if(enemies.Count == 0){
                    action = "move";
                }
                attackrate = 1;
            }
            attackrate -= Time.deltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D collider2D)
	{
        if(collider2D.gameObject.tag == "Enemy"){
            enemies.Add(collider2D.gameObject.GetComponent<Enemy>());
            action = "attack";
        }
	}
    public void damaged(int damageReceived){
        health-=damageReceived;
    }
}
