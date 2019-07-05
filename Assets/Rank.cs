using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Rank : MonoBehaviour {

    GameObject time1;
    //GameObject Rank1;
    GameObject score1;
    GameObject scoreler1;
    GameObject scoreler2;
    GameObject scoreler3;
    GameObject scoreler4;

    // Use this for initialization
    void Start () {
        //this.time1 = GameObject.Find("textYourTimeEx");
        //this.score1 = GameObject.Find("textYourScoreEx");

        this.scoreler1 = GameObject.Find("textYourTimeEx");
        this.scoreler2 = GameObject.Find("textYourScoreEx"); 
        this.scoreler3 = GameObject.Find("textRankingEx"); 
        //this.scoreler4 = GameObject.Find();


    }

    // Update is called once per frame
    void Update()
    {
        //this.time1.GetComponent<Text>().text = expart_timeScript.ScoreTime.ToString();
        //this.time1.GetComponent<Text>().text = expart_timeScript.exResultScore.ToString();

        this.scoreler1.GetComponent<Text>().text = expart_timeScript.scoreler[0].ToString();
        this.scoreler2.GetComponent<Text>().text = expart_timeScript.scoreler[2].ToString();
        this.scoreler3.GetComponent<Text>().text = expart_timeScript.scoreler[3].ToString();
        
        
    }
}
