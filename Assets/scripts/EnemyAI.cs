using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    int killedEnemies ;
    int KilledTanks ;
    int killedEnemyArchers ;
    public GameObject enemyPrefab ;
    public GameObject tankPrefab ;
    public GameObject enemyArcherPrefab ;
    float enemySpawnRate ;
    float archerSpawnRate ;
    float tankSpawnRate ;
    float baseEnemySpawnRate =3 ;
    float baseArcherSpawnRate = 6;
    float baseTankSpawnRate = 30;
    int maxEnemies=5;
    int maxArchers = 5;
    int maxTanks=2;
    int enemies;
    int tanks;
    int enemyArchers;
    // Start is called before the first frame update
    void Start()
    {
        killedEnemies = 0;
        killedEnemyArchers = 0;
        KilledTanks = 0;
        enemySpawnRate= baseEnemySpawnRate;
        archerSpawnRate= baseArcherSpawnRate;
        tankSpawnRate= baseTankSpawnRate ;
        enemies=0;
        enemyArchers=0;
        tanks=0;
    }

    // Update is called once per frame
    void Update()
    {  
        if(enemies<=maxEnemies){
            if(enemySpawnRate<0){
                spawnUnit("Enemy");
                enemies++;
                enemySpawnRate = baseEnemySpawnRate;
                
            }
        }
        if(enemyArchers<=maxArchers){
            if(archerSpawnRate<0){
                spawnUnit("EnemyArcher");
                enemyArchers++;
                archerSpawnRate=baseArcherSpawnRate;
            }
        }
        if(tanks<=maxTanks){
            if(tankSpawnRate<0){
                spawnUnit("Tank");
                tanks++;
                tankSpawnRate=baseTankSpawnRate;
            }
        }    
        enemySpawnRate -= Time.deltaTime;
        archerSpawnRate -= Time.deltaTime;
        tankSpawnRate -= Time.deltaTime;
        dificaltyCalculater();
        
    }
    void spawnUnit(string type){
       switch(type){
        case "Enemy":
        GameObject enemy = Instantiate(enemyPrefab,transform.position,Quaternion.identity);
        break;
        case "EnemyArcher":
        GameObject enemyArcher = Instantiate(enemyArcherPrefab,transform.position,Quaternion.identity);
        break;
        case "Tank":
        GameObject tank = Instantiate(tankPrefab,transform.position,Quaternion.identity);
        break;
       }
    }
    public void enemyDied(){
        killedEnemies++;
        enemies--;
    }
    public void archerDied(){
        killedEnemyArchers++;
        enemyArchers--;
    }
    public void tankDied(){
        KilledTanks++;
        tanks--;
    }
    private void dificaltyCalculater(){
        if(killedEnemies>=10 &&killedEnemyArchers>=5 && KilledTanks>=2){
            baseEnemySpawnRate*=9;
            baseEnemySpawnRate/=10;
            baseArcherSpawnRate*=9;
            baseArcherSpawnRate/=10;
            baseTankSpawnRate*=9;
            baseTankSpawnRate/=10;
        }
    }
}
