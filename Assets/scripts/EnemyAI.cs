using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    List<Enemy> enemies ;
    List<Tank> tanks ;
    List<EnemyArcher> enemyArchers ;
    List<swordsman> swordmans ;
    List<Shooter> shooters ;
    public GameObject enemyPrefab ;
    public GameObject tankPrefab ;
    public GameObject enemyArcherPrefab ;
    float spawnRate ;
    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<Enemy>();
        tanks = new List<Tank>();
        enemyArchers = new List<EnemyArcher>();
        swordmans = new List<swordsman>();
        shooters = new List<Shooter>();
        spawnRate=3;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnRate<0){
            if(enemies.Count<=5){
                spawnUnit("Enemy");
                spawnRate = 3;
            }else if(enemyArchers.Count<=5){
                spawnUnit("EnemyArcher");
                spawnRate=3;
            }else if(tanks.Count<=2){
                spawnUnit("Tank");
                spawnRate=3;
            }
            
        }
        spawnRate -= Time.deltaTime;
        
    }
    void spawnUnit(string type){
       switch(type){
        case "Enemy":
        GameObject enemy = Instantiate(enemyPrefab,transform.position,Quaternion.identity);
        enemies.Add(enemy.GetComponent<Enemy>());
        break;
        case "EnemyArcher":
        GameObject enemyArcher = Instantiate(enemyArcherPrefab,transform.position,Quaternion.identity);
        enemyArchers.Add(enemyArcher.GetComponent<EnemyArcher>());
        break;
        case "Tank":
        GameObject tank = Instantiate(tankPrefab,transform.position,Quaternion.identity);
        tanks.Add(tank.GetComponent<Tank>());
        break;
       }
    }
    
}
