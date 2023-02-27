using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseController : MonoBehaviour
{
    public GameObject shooterPrefab ;
    public GameObject swordsmanPrefab ;
    float spawnRate ;
    // Start is called before the first frame update
    void Start()
    {
        spawnRate=3;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnRate<0){
            if(Input.GetKey(KeyCode.Q)){
                spawnUnit("Swordsman");
                spawnRate = 3;
            }else if(Input.GetKey(KeyCode.W)){
                spawnUnit("Shooter");
                spawnRate=3;
            }
            
        }
        spawnRate -= Time.deltaTime;
        
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
