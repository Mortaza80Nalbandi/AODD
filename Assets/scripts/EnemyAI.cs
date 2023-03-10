using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    int enemies ;
    int tanks ;
    int enemyArchers ;
    public GameObject enemyPrefab ;
    public GameObject tankPrefab ;
    public GameObject enemyArcherPrefab ;
    float spawnRate ;
    // Start is called before the first frame update
    void Start()
    {
        enemies = 0;
        tanks = 0;
        enemyArchers = 0;
        spawnRate=3;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnRate<0){
            if(enemies<=5){
                spawnUnit("Enemy");
                spawnRate = 3;
            }else if(enemyArchers<=5){
                spawnUnit("EnemyArcher");
                spawnRate=3;
            }else if(tanks<=2){
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
        enemies++;
        break;
        case "EnemyArcher":
        GameObject enemyArcher = Instantiate(enemyArcherPrefab,transform.position,Quaternion.identity);
        enemyArchers++;
        break;
        case "Tank":
        GameObject tank = Instantiate(tankPrefab,transform.position,Quaternion.identity);
        tanks++;
        break;
       }
    }
    public void killedenemy(){
        enemies--;
    }
    public void killedTank(){
        tanks--;
    }
    public void killedarcher(){
        enemyArchers--;
    }
}
