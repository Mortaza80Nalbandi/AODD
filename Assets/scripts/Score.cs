using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    private int score;
    private int lastPrintedScore;

    string commands;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;

        commands = "\n press A and D to move\n";
        commands+="press F to attack when close range\n";
        commands+="press Q for swordman(10R) and W for Shooter(5R)";
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
