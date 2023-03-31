using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float health;
    private float maxHealth = 1000;
    float attackrate;
    float healingRate;
    int damage;
    float speed = 0.06f;
    List<Enemy> enemies;
    List<Tank> tanks;
    List<EnemyArcher> enemyArchers;
    healthbar healthbarx;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        damage = 5;
        speed = 0.06f;
        attackrate = 1;
        healingRate = 1;
        enemies = new List<Enemy>();
        tanks = new List<Tank>();
        enemyArchers = new List<EnemyArcher>();
        healthbarx = transform.GetChild(1).gameObject.GetComponent<healthbar>();
        healthbarx.setHealth(health, 1000);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-1 * speed, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.F))
        {
            if (attackrate <= 0)
            {
                if (tanks.Count != 0)
                {

                    if (tanks[0].health <= 0)
                    {
                        tanks.RemoveAt(0);
                    }
                    else
                    {
                        tanks[0].damaged(damage);
                    }
                }
                else if (enemies.Count != 0)
                {

                    if (enemies[0].health <= 0)
                    {
                        enemies.RemoveAt(0);
                    }
                    else
                    {
                        enemies[0].damaged(damage);
                    }
                }
                else if (enemyArchers.Count != 0)
                {
                    if (enemyArchers[0].health <= 0)
                    {
                        enemyArchers.RemoveAt(0);
                    }
                    else
                    {
                        enemyArchers[0].damaged(damage);
                    }
                }
                attackrate = 1;
            }
        }
        attackrate -= Time.deltaTime;
        healingRate -= Time.deltaTime;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (health < 1000 && healingRate <= 0)
        {
            healingRate = 1;
            health += 2;
        }
    }
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "EnemySoldier")
        {
            enemies.Add(collider2D.gameObject.GetComponent<Enemy>());
        }
        else if (collider2D.gameObject.tag == "EnemyTank")
        {
            tanks.Add(collider2D.gameObject.GetComponent<Tank>());
        }
        else if (collider2D.gameObject.tag == "EnemyArcher")
        {
            enemyArchers.Add(collider2D.gameObject.transform.parent.gameObject.GetComponent<EnemyArcher>());
        }else if(collider2D.gameObject.tag == "Arrow"){
            damaged(collider2D.gameObject.GetComponent<Bullet>().getDamage());
            Destroy(collider2D.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "EnemySoldier")
        {
            enemies.Remove(collider2D.gameObject.GetComponent<Enemy>());
        }
        else if (collider2D.gameObject.tag == "EnemyTank")
        {
            tanks.Remove(collider2D.gameObject.GetComponent<Tank>());
        }
        else if (collider2D.gameObject.tag == "EnemyArcher")
        {
            enemyArchers.Remove(collider2D.gameObject.transform.parent.gameObject.GetComponent<EnemyArcher>());
        }
    }
    public void damaged(float damageReceived)
    {
        health -= damageReceived;
        healthbarx.setHealth(health, 1000);
    }
}
