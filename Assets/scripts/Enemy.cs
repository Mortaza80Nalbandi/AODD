using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float attackrate = 1;
    public int health;
    int damage;
    float speed = 0.01f;
    public string  action;
    List<swordsman> swordmans ;
    List<Shooter> shooters ;
    Character character;
    bool shooterSighted;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        damage = 5;
        swordmans = new List<swordsman>();
        shooters = new List<Shooter>();
        action = "move";
    }

    // Update is called once per frame
    void Update()
    {
                if(action =="move"){
            transform.Translate (-1*speed, 0f, 0f);
        }else if(action =="attack"){
            if(attackrate <= 0){
                if(character != null){
                    character.damaged(damage);
                    if(character.health<=0){
                        Destroy(character.gameObject);
                    }
                }else if(swordmans.Count != 0){
                    swordmans[0].damaged(damage);
                    if(swordmans[0].health<=0){
                        Destroy(swordmans[0].gameObject);
                        swordmans.RemoveAt(0);
                    }
                }else if(shooters.Count != 0){
                    shooters[0].damaged(damage);
                    if(shooters[0].health<=0){
                        Destroy(shooters[0].gameObject);
                        shooters.RemoveAt(0);
                    }
                } else {
                    action = "move";
                }
                attackrate = 1;
            }
            attackrate -= Time.deltaTime;
        }

    }
    void OnTriggerEnter2D(Collider2D collider2D)
	{
        if(collider2D.gameObject.tag == "Ally" ){
            if(collider2D.gameObject.name == "Ally" ){
                swordmans.Add(collider2D.gameObject.GetComponent<swordsman>());
                action = "attack";
            }else if(collider2D.gameObject.name == "Player" ){
                character = collider2D.gameObject.GetComponent<Character>();
                action = "attack";
            }else if(collider2D.gameObject.name == "Shooter" ){

                shooterSighted= true;
            }
        }
        
	}
    void OnTriggerExit2D(Collider2D collider2D){
        if(collider2D.gameObject.name == "Shooter" && shooterSighted ){
                shooters.Add(collider2D.gameObject.GetComponent<Shooter>());
                action = "attack";
            }
    }
    public void damaged(int damageReceived){
        health-=damageReceived;
    }
}
