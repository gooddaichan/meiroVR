using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{

    // スコアを表示する
    public Text exscoreText;
    // ハイスコアを表示する
    public Text exhighScoreText;

    public Text extextYourScore_ex;

    public Text extextYourTime_ex;

    public Text extextItem_ex;

    // ハイスコア
    private float exhighScore;

    // PlayerPrefsで保存するためのキー
    private string exhighScoreKey = "highScore";

    public float expoint = 0;

    public Text extextRanking;
    string[] exScoreRanking = new string[10];
    private string[] extemp = new string[10];
    private int exrowLength;
    private int exPlayScore;
    private int excount;
    private int exGetScoreTime;
    private int exGetScoreStar;
    private int exResultScore;
    public static string ranking;

    void Start () {
        if (expart_timeScript.Flagy == 1)
        {
            ReadScore();
            Debug.Log("Readscore");
            Debug.Log(exScoreRanking[0] + "\n" + exScoreRanking[1] + "\n" + exScoreRanking[2] + "\n" + exScoreRanking[3] + "\n" + exScoreRanking[4] + "\n" +
                     exScoreRanking[5] + "\n" + exScoreRanking[6] + "\n" + exScoreRanking[7] + "\n" + exScoreRanking[8] + "\n" + exScoreRanking[9]);

            exScoreRanking = Sort(exScoreRanking);
            Debug.Log("Sort");

            output(exScoreRanking);
            Debug.Log("output");

            WriteScore(exScoreRanking);
            Debug.Log("WriteScore");
            Debug.Log(exScoreRanking[0] + "\n" + exScoreRanking[1] + "\n" + exScoreRanking[2] + "\n" + exScoreRanking[3] + "\n" + exScoreRanking[4] + "\n" +
                    exScoreRanking[5] + "\n" + exScoreRanking[6] + "\n" + exScoreRanking[7] + "\n" + exScoreRanking[8] + "\n" + exScoreRanking[9]);

        }

    }

    void Update()
    {
       // extextYourTime_ex.text = expart_timeScript.ScoreTime.ToString("F0");//タイムのみ
       // extextYourScore_ex.text = expart_timeScript.exResultScore.ToString();

    }

    void ReadScore()
    {
        /* TextAsset textasset = new TextAsset();//テキストファイルのデータを取得するインスタンスを作成
         textasset = Resources.Load("Ranking", typeof(TextAsset)) as TextAsset;//Resourcesフォルダから対象テキストを取得
         string TextLines = textasset.text;//テキスト全体をstring型で入れる変数を用意していれる
         */
        int i = 0;
        StreamReader sr = new StreamReader("Assets/Resources/EX_Ranking.txt");
        while (sr.Peek() > -1)
        {
            Debug.Log(i);
            exScoreRanking[i] = sr.ReadLine();
            if (i == 9)
            {
                break;
            }
            else
            {
                i = i + 1;
            }
        }
        //Splitで一行づつを代入した1次配列を作成
        //行数を取得
        exrowLength = exScoreRanking.Length;
        Debug.Log("rowLength：" + exrowLength);

        sr.Close();


    }

    string[] Sort(string[] Score1)
    {
        /*
        //score計算するよここから
        exGetScoreTime = (int)(expart_timeScript.ScoreTime);



        if (expart_timeScript.ScoreTime == 0)
        {
            exGetScoreStar = 0;
        }
        else
        {
            exGetScoreStar = Item.GetStar_ex-10;
        }
        
        exResultScore = (int)(exGetScoreTime*0.7) + exGetScoreStar;
        //ResultScore = GetScoreStar;

    */

        //ここまで

        // PlayScore = (int)expart_timeScript.ScoreTime;//プレイしたスコアを格納
        exPlayScore = exResultScore;
        Score1.CopyTo(extemp, 0);//ランキング変動用配列

        if (exPlayScore < int.Parse(Score1[4]))//int.Paeseで配列の要素をintに変換
        {                                         //スコアが5位未満
            for (int c = 5; c < exrowLength; c++)
            {
                if (c < 9 && exPlayScore > int.Parse(Score1[c]))//スコア入れ替え処理
                {
                    Score1[c] = exPlayScore.ToString();//スコア更新
                    for (int t = c + 1; t < exrowLength; t++)//更新されたスコア以下のスコアを更新
                    {
                        Score1[t] = extemp[t - 1];
                    }
                    break;
                }

                if (c == 9 && exPlayScore > int.Parse(Score1[c]))
                {
                    Score1[c] = exPlayScore.ToString();//スコア更新
                    break;
                }
            }
        }

        else //スコアが5位以上
        {
            for (int c = 0; c < exrowLength / 2; c++)
            {
                if (exPlayScore > int.Parse(Score1[c]))//スコア入れ替え処理
                {
                    Score1[c] = exPlayScore.ToString();//スコア更新
                    for (int t = c + 1; t < exrowLength; t++)//更新されたスコア以下のスコアを更新
                    {
                        Score1[t] = extemp[t - 1];
                    }
                    break;
                }
            }
        }
        return (Score1);
    }

    void output(string[] exScore2)
    {
        //string ranking;
        extextRanking.fontSize = 10;

        ranking = exScore2[0] + "\n" + exScore2[1] + "\n" + exScore2[2] + "\n" + exScore2[3] + "\n" + exScore2[4] + "\n" +
                 exScore2[5] + "\n" + exScore2[6] + "\n" + exScore2[7] + "\n" + exScore2[8] + "\n" + exScore2[9];


        //テキスト出力
        //if (expart_timeScript.Flagy == 1)
        //{

            //extextRanking.text = ranking;//ランキング
            //extextYourScore_ex.text = exResultScore.ToString(); //合わせたスコア//0だった
                                                               
          //  Debug.Log(expart_timeScript.ScoreTime);
             //extextYourTime_ex.text = expart_timeScript.ScoreTime.ToString("F0");//タイムのみ
                                                                               
       // }
    }


    void WriteScore(string[] exScore3)
    {
        StreamWriter sw = new StreamWriter("Assets/Resources/EX_Ranking.txt", false);
        for (int i = 0; i < exrowLength; i++)
        {
            sw.WriteLine(exScore3[i]);
            if (i == 9)
            {
                sw.Write(exScore3[i]);
            }
        }
        sw.Flush();
        sw.Close();
    }



    

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
}
