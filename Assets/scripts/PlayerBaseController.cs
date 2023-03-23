using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseController : MonoBehaviour
{
    public GameObject shooterPrefab ;
    public GameObject swordsmanPrefab ;
    float swordmanSpawnRate ;
    float shooterSpawnRate ;
    int resources;
    // Start is called before the first frame update
    void Start()
    {
        swordmanSpawnRate=3;
        shooterSpawnRate = 3;
        resources = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Q)){
            if(swordmanSpawnRate<0){
                spawnUnit("Swordsman");
                swordmanSpawnRate = 3;
            }
        }else if(Input.GetKey(KeyCode.W)){
            if(shooterSpawnRate<0){
                spawnUnit("Shooter");
                shooterSpawnRate=3;
            }
        }
            
        shooterSpawnRate -= Time.deltaTime;
        swordmanSpawnRate -= Time.deltaTime;
        
    }
    void spawnUnit(string type){
       switch(type){
        case "Swordsman":
        GameObject swordsman = Instantiate(swordsmanPrefab,transform.position,Quaternion.identity);
        break;
        case "Shooter":
        GameObject shooter = Instantiate(shooterPrefab,transform.position,Quaternion.identity);
        break;
       }
    }
}
