using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseController : MonoBehaviour
{
    public GameObject shooterPrefab;
    public GameObject swordsmanPrefab;
    float swordmanSpawnRate;
    float shooterSpawnRate;
    float resourceRate;
    public int resources;
    int shooterCost;
    int swordmanCost;
    Resorces resorcesa;
    // Start is called before the first frame update
    void Start()
    {
        swordmanCost = 10;
        shooterCost = 5;
        swordmanSpawnRate = 3;
        shooterSpawnRate = 3;
        resources = 0;
        resourceRate = 0.5f;
        resorcesa = GameObject.Find("CoreLoop").GetComponent<Resorces>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (swordmanSpawnRate < 0 && resources > swordmanCost)
            {
                spawnUnit("Swordsman");
                swordmanSpawnRate = 3;
                resources -= swordmanCost;
            }
        }
        else if (Input.GetKey(KeyCode.W))
        {
            if (shooterSpawnRate < 0 && resources > shooterCost)
            {
                spawnUnit("Shooter");
                shooterSpawnRate = 3;
                resources -= shooterCost;
            }
        }
        if (resourceRate < 0 && resources < 50)
        {
            resourceRate = 0.5f;
            resources++;
            resorcesa.setResourse(resources);
        }
        shooterSpawnRate -= Time.deltaTime;
        swordmanSpawnRate -= Time.deltaTime;
        resourceRate -= Time.deltaTime;

    }
    void spawnUnit(string type)
    {
        switch (type)
        {
            case "Swordsman":
                GameObject swordsman = Instantiate(swordsmanPrefab, transform.position, Quaternion.identity);
                break;
            case "Shooter":
                GameObject shooter = Instantiate(shooterPrefab, transform.position, Quaternion.identity);
                break;
        }
    }
}
