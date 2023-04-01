using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    float attackrate;
    public float health;
    private float maxHealth = 100;
    int damage;
    float speed;
    public string action;
    List<Enemy> enemies;
    List<Tank> tanks;
    List<EnemyArcher> enemyArchers;
    bool baseSighted;
    healthbar healthbarx;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        damage = 30;
        speed = 0.03f;
        attackrate = 1;
        enemies = new List<Enemy>();
        tanks = new List<Tank>();
        enemyArchers = new List<EnemyArcher>();
        action = "move";
        healthbarx = transform.GetChild(0).gameObject.GetComponent<healthbar>();
        healthbarx.setHealth(health, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (action == "move")
        {
            transform.Translate(speed, 0f, 0f);
        }
        else if (action == "attack")
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
                        GameObject bullet = Instantiate(bulletPrefab,transform.position,Quaternion.identity);
                        bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right*600);
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
                        GameObject bullet = Instantiate(bulletPrefab,transform.position,Quaternion.identity);
                        bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right*600);
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
                        GameObject bullet = Instantiate(bulletPrefab,transform.position,Quaternion.identity);
                        bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right*600);
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
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "EnemySoldier")
        {
            enemies.Add(collider2D.gameObject.GetComponent<Enemy>());
            action = "attack";
        }
        else if (collider2D.gameObject.tag == "EnemyTank")
        {
            tanks.Add(collider2D.gameObject.GetComponent<Tank>());
            action = "attack";
        }
        else if (collider2D.gameObject.tag == "EnemyArcher")
        {
            enemyArchers.Add(collider2D.gameObject.transform.parent.gameObject.GetComponent<EnemyArcher>());
            action = "attack";
        }
        else if (collider2D.gameObject.tag == "EnemyBase")
        {
            transform.Translate(-1 * speed, 0f, 0f);
            baseSighted = true;
            action = "stop";
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
        healthbarx.setHealth(health, 100);
    }
    public float getHealth()
    {
        return health;
    }
}
