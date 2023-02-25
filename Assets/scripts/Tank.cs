using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    float attackrate = 1;
    public int health;
    int damage;
    float speed = 0.01f;
    public string  action;
    List<swordsman> swordmans ;
    List<Shooter> shooters ;
    bool shooterSighted;
    Character character;
    // Start is called before the first frame update
    void Start()
    {
        health = 500;
        damage = 20;
        swordmans = new List<swordsman>();
        character=null;
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
                } else {
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
        if(collider2D.gameObject.tag == "Ally" ){
            swordmans.Add(collider2D.gameObject.GetComponent<swordsman>());
            action = "attack";
        }else if(collider2D.gameObject.tag == "Player" ){
            character = collider2D.gameObject.GetComponent<Character>();
            action = "attack";
        } else if(collider2D.gameObject.name == "Shooter" ){
                shooterSighted= true;
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
