using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using System;

public class expart_timeScript : MonoBehaviour
{
    GameObject limitTimeUI;

    //public UnityEngine.UI.Text scoreLabel;
    //public GameObject winnerLabelObject;
    public float time = 121.0f;
    public static float ScoreTime = 0;
    public static int Flagy = 0;
    public static float exResultScore;

    public static int exGetScoreStar;
    public Text extextRanking;
    string[] exScoreRanking = new string[5];
    private string[] extemp = new string[5];
    private int exrowLength;
    private int exPlayScore;
    private int excount;
    private int exGetScoreTime;
    public static string ranking;
    public static int[] scoreler=new int[10];

    IEnumerator sleep()
    {

        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Result");

    }

    // Use this for initialization
    void Start()
    {
        this.limitTimeUI = GameObject.Find("expart_LimitTimeUI");
        scoreler[1] = PlayerPrefs.GetInt(1 + "_SCORE", 0);
        scoreler[2] = PlayerPrefs.GetInt(2 + "_SCORE", 0);
        scoreler[3] = PlayerPrefs.GetInt(3 + "_SCORE", 0);
        scoreler[4] = PlayerPrefs.GetInt(4 + "_SCORE", 0);
        scoreler[5] = PlayerPrefs.GetInt(5 + "_SCORE", 0);
        scoreler[6] = PlayerPrefs.GetInt(6 + "_SCORE", 0);
        scoreler[7] = PlayerPrefs.GetInt(7 + "_SCORE", 0);
        scoreler[8] = PlayerPrefs.GetInt(8 + "_SCORE", 0);
        scoreler[9] = PlayerPrefs.GetInt(9 + "_SCORE", 0);
    }

    void Update() {

        // 毎フレーム毎に残り時間を減らす
        this.time -= Time.deltaTime;

        int flag = 0;

    

        if (this.time<1)
        {
            this.limitTimeUI.GetComponent<Text>().text = "GAMEOVER";

            Flagy = 1;

            exResultScore = 0;
            StartCoroutine("sleep");

        }
        else
               {
            // timeを文字列に変換したものをテキストに表示する
            // ToStringのF1とは、小数点以下1桁までという意味 
            this.limitTimeUI.GetComponent<Text>().text = this.time.ToString("F0");
               }

        int count = GameObject.FindGameObjectsWithTag("Item").Length;
        //scoreLabel.text = count.ToString();
        if (count == 0)
        {

            //winnerLabelObject.SetActive(true);
            //gameObject.SetActive(false);
            flag = 1;
            if (flag==1)
            {
                this.limitTimeUI.GetComponent<Text>().text = "GAMECLEAR";
                ScoreTime = time + 3.0f;
                Flagy = 1;

               scoreler[0] = (int)(ScoreTime * 0.7) + exGetScoreStar;
                //Debug.Log(ScoreTime * 0.7);
                Array.Sort(scoreler);

                PlayerPrefs.SetInt("1_SCORE", scoreler[0]);
                PlayerPrefs.SetInt("2_SCORE", scoreler[1]);
                PlayerPrefs.SetInt("3_SCORE", scoreler[2]);
                PlayerPrefs.SetInt("4_SCORE", scoreler[3]);
                PlayerPrefs.SetInt("5_SCORE", scoreler[4]);
                PlayerPrefs.SetInt("6_SCORE", scoreler[5]);
                PlayerPrefs.SetInt("7_SCORE", scoreler[6]);
                PlayerPrefs.SetInt("8_SCORE", scoreler[7]);
                PlayerPrefs.SetInt("9_SCORE", scoreler[8]);
                //PlayerPrefs.DeleteKey("0_SCORE");
                //PlayerPrefs.DeleteKey("1_SCORE");
                //PlayerPrefs.DeleteKey("2_SCORE");
                //PlayerPrefs.DeleteKey("3_SCORE");
                //PlayerPrefs.DeleteKey("4_SCORE");
                //PlayerPrefs.DeleteKey("6_SCORE");
                //PlayerPrefs.DeleteKey("7_SCORE");
                //PlayerPrefs.DeleteKey("8_SCORE");
                //PlayerPrefs.DeleteKey("9_SCORE");




                PlayerPrefs.Save();


                exGetScoreStar = Item.GetStar_ex - 10;
                exResultScore = (int)(ScoreTime * 0.7) + exGetScoreStar;

                StartCoroutine("sleep");
            }
          
        }

    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}