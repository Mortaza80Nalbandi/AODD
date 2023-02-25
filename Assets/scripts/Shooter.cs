using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    float attackrate ;
    public int health;
    int damage;
    float speed;
    public string  action;
    List<Enemy> enemies ;
    List<Tank> tanks ;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        damage = 10;
        speed = 0.03f;
        attackrate = 1;
        enemies = new List<Enemy>();
        tanks = new List<Tank>();
        action = "move";
    }

    // Update is called once per frame
    void Update()
    {
        if(action =="move"){
            transform.Translate (speed, 0f, 0f); 
	    }else if(action =="attack"){
            if(attackrate <= 0){
                if(tanks.Count != 0){
                    tanks[0].damaged(damage);
                    if(tanks[0].health<=0){
                        tanks.RemoveAt(0);
                    }
                }else if(enemies.Count != 0){
                    enemies[0].damaged(damage);
                    if(enemies[0].health<=0){
                        enemies.RemoveAt(0);
                    }
                }else{
                    action = "move";
                }
                attackrate = 1; 
            }
            attackrate -= Time.deltaTime;
        }
        if(health<=0){
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collider2D)
	{
        if(collider2D.gameObject.tag =="EnemySoldier"){
            enemies.Add(collider2D.gameObject.GetComponent<Enemy>());
            action = "attack";
        }else if(collider2D.gameObject.tag =="EnemyTank"){
            tanks.Add(collider2D.gameObject.GetComponent<Tank>());
            action = "attack";      
        } 
	}
    public void damaged(int damageReceived){
        health-=damageReceived;
    }
}
