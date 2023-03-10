using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    private int score;
    private int lastPrintedScore;
    string dificality;
    int killedEnemies;
    int killedTanks;
    int killedEnemyArchers;
    int killedAllies;
    string commands;
    // Start is called before the first frame update
    void Start()
    {
        dificality = "easy";
        score = 0;
        killedAllies = 0;
        killedEnemies = 0;
        commands = "\n press A and D to move\n";
        commands+="press F to attack when close range\n";
        commands+="press Q for swordman and W for Shooter";
        GameObject.Find("Score").GetComponent<Text>().text = "Score : "+ score.ToString () + commands; 

    }

    // Update is called once per frame
    void Update()
    {
        
            if(score !=lastPrintedScore){
                GameObject.Find("Score").GetComponent<Text>().text = "Score : "+ score.ToString ()+commands ; 

            }
        
    }
    public void increaseScore(int s){
        score+=s;
    }
    
}
