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
    // Start is called before the first frame update
    void Start()
    {
        dificality = "easy";
        score = 0;
        killedAllies = 0;
        killedEnemies = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
            if(score !=lastPrintedScore){
                GameObject.Find("Score").GetComponent<Text>().text = "Score : "+ score.ToString (); 

            }
        
    }
    public void increaseScore(int s){
        score+=s;
    }
    
}
