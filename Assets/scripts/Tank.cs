using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    float attackrate;
    public float health;
    private float maxHealth = 500;
    int damage;
    float speed;
    public string action;
    List<swordsman> swordmans;
    List<Shooter> shooters;
    Character character;
    Score score;
    bool baseSighted;
    healthbar healthbarx;
    EnemyAI enemyAI;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        damage = 30;
        speed = 0.01f;
        attackrate = 2;
        swordmans = new List<swordsman>();
        shooters = new List<Shooter>();
        character = null;
        action = "move";
        score = GameObject.Find("CoreLoop").GetComponent<Score>();
        healthbarx = transform.GetChild(0).gameObject.GetComponent<healthbar>();
        enemyAI = GameObject.Find("EnemyBase").GetComponent<EnemyAI>();
        healthbarx.setHealth(health, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (action == "move")
        {
            transform.Translate(-1 * speed, 0f, 0f);
        }
        else if (action == "attack")
        {
            if (attackrate <= 0)
            {
                if (character != null)
                {

                    if (character.health <= 0)
                    {
                        character = null;
                    }
                    else
                    {
                        character.damaged(damage);
                    }
                }
                else if (swordmans.Count != 0)
                {

                    if (swordmans[0].health <= 0)
                    {
                        swordmans.RemoveAt(0);
                    }
                    else
                    {
                        swordmans[0].damaged(damage);
                    }
                }
                else if (shooters.Count != 0)
                {

                    if (shooters[0].health <= 0)
                    {
                        shooters.RemoveAt(0);
                    }
                    else
                    {
                        shooters[0].damaged(damage);
                    }
                }
                else if (baseSighted)
                {
                    action = "stop";
                }
                else
                {
                    action = "move";
                }
                attackrate = 1;
            }
            attackrate -= Time.deltaTime;
        }
        if (health <= 0)
        {
            score.increaseScore(20);
            enemyAI.tankDied();
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "AllySoldier")
        {
            swordmans.Add(collider2D.gameObject.GetComponent<swordsman>());
            action = "attack";
        }
        else if (collider2D.gameObject.tag == "Player")
        {
            character = collider2D.gameObject.GetComponent<Character>();
            action = "attack";
        }
        else if (collider2D.gameObject.tag == "AllyShooter")
        {
            shooters.Add(collider2D.gameObject.transform.parent.gameObject.GetComponent<Shooter>());
            action = "attack";
        }
        else if (collider2D.gameObject.tag == "MainBase")
        {
            transform.Translate(speed, 0f, 0f);
            baseSighted = true;
            action = "stop";
        }
    }
    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player")
        {
            character = null;
        }
    }
    public void damaged(int damageReceived)
    {
        health -= damageReceived;
        healthbarx.setHealth(health, maxHealth);
    }
    public float getHealth()
    {
        return health;
    }
}
