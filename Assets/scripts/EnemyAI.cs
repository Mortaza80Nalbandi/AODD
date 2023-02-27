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
    
    float spawnRate ;
    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<Enemy>();
        tanks = new List<Tank>();
        enemyArchers = new List<EnemyArcher>();
        swordmans = new List<swordsman>();
        shooters = new List<Shooter>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnRate<0){
            if(enemies.Count<=10){
                spawnUnit("Enemy");
            }else if(enemyArchers.Count<=5){
                spawnUnit("EnemyArcher");
            }else if(tanks.Count<=2){
                spawnUnit("Tank");
            }
        }
        
    }
    void spawnUnit(string type){
       int x=0;
    }
    
}
