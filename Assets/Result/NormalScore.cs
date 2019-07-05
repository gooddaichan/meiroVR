using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NormalScore : MonoBehaviour
{

    // スコアを表示する
    public Text nscoreText;
    // ハイスコアを表示する
    public Text nhighScoreText;

    public Text ntextYourScore_ex;

    public Text ntextYourTime_ex;

    public Text ntextItem_ex;

    // ハイスコア
    private float nhighScore;

    // PlayerPrefsで保存するためのキー
    private string nhighScoreKey = "highScore";

    public float npoint = 0;

    public Text ntextRanking;
    string[] nScoreRanking = new string[10];
    private string[] ntemp = new string[10];
    private int nrowLength;
    private int nPlayScore;
    private int ncount;
    private int nGetScoreTime;
    private int nGetScoreStar;
    private int nResultScore;

    void Start()
    {
        if (normal_timeScript.Flagy == 1)
        {
            ReadScore();
            Debug.Log("Readscore");
            Debug.Log(nScoreRanking[0] + "\n" + nScoreRanking[1] + "\n" + nScoreRanking[2] + "\n" + nScoreRanking[3] + "\n" + nScoreRanking[4] + "\n" +
                     nScoreRanking[5] + "\n" + nScoreRanking[6] + "\n" + nScoreRanking[7] + "\n" + nScoreRanking[8] + "\n" + nScoreRanking[9]);

            nScoreRanking = Sort(nScoreRanking);
            Debug.Log("Sort");

            output(nScoreRanking);
            Debug.Log("output");

            WriteScore(nScoreRanking);
            Debug.Log("WriteScore");
            Debug.Log(nScoreRanking[0] + "\n" + nScoreRanking[1] + "\n" + nScoreRanking[2] + "\n" + nScoreRanking[3] + "\n" + nScoreRanking[4] + "\n" +
                    nScoreRanking[5] + "\n" + nScoreRanking[6] + "\n" + nScoreRanking[7] + "\n" + nScoreRanking[8] + "\n" + nScoreRanking[9]);
        }

        
    }
    void ReadScore()
    {
        /* TextAsset textasset = new TextAsset();//テキストファイルのデータを取得するインスタンスを作成
         textasset = Resources.Load("Ranking", typeof(TextAsset)) as TextAsset;//Resourcesフォルダから対象テキストを取得
         string TextLines = textasset.text;//テキスト全体をstring型で入れる変数を用意していれる
         */
        int i = 0;
        StreamReader sr = new StreamReader("Assets/Resources/NormalRanking.txt");
        while (sr.Peek() > -1)
        {
            Debug.Log(i);
            nScoreRanking[i] = sr.ReadLine();
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
        nrowLength = nScoreRanking.Length;
        Debug.Log("rowLength：" + nrowLength);

        sr.Close();


    }

    string[] Sort(string[] Score1)
    {
        //score計算するよここから
        nGetScoreTime = (int)(normal_timeScript.ScoreTime);




        if (normal_timeScript.ScoreTime == 0)
        {
            nGetScoreStar = 0;
        }
        else
        {
            nGetScoreStar = Item.GetStar_ex - 10;
        }

        nResultScore = (int)(nGetScoreTime * 0.7) + nGetScoreStar;
        //ResultScore = GetScoreStar;



        //ここまで

        // PlayScore = (int)expart_timeScript.ScoreTime;//プレイしたスコアを格納
        nPlayScore = nResultScore;
        Score1.CopyTo(ntemp, 0);//ランキング変動用配列

        if (nPlayScore < int.Parse(Score1[4]))//int.Paeseで配列の要素をintに変換
        {                                         //スコアが5位未満
            for (int c = 5; c < nrowLength; c++)
            {
                if (c < 9 && nPlayScore > int.Parse(Score1[c]))//スコア入れ替え処理
                {
                    Score1[c] = nPlayScore.ToString();//スコア更新
                    for (int t = c + 1; t < nrowLength; t++)//更新されたスコア以下のスコアを更新
                    {
                        Score1[t] = ntemp[t - 1];
                    }
                    break;
                }

                if (c == 9 && nPlayScore > int.Parse(Score1[c]))
                {
                    Score1[c] = nPlayScore.ToString();//スコア更新
                    break;
                }
            }
        }

        else //スコアが5位以上
        {
            for (int c = 0; c < nrowLength / 2; c++)
            {
                if (nPlayScore > int.Parse(Score1[c]))//スコア入れ替え処理
                {
                    Score1[c] = nPlayScore.ToString();//スコア更新
                    for (int t = c + 1; t < nrowLength; t++)//更新されたスコア以下のスコアを更新
                    {
                        Score1[t] = ntemp[t - 1];
                    }
                    break;
                }
            }
        }
        return (Score1);
    }

    void output(string[] nScore2)
    {
        string ranking;
        ntextRanking.fontSize = 10;

        ranking = nScore2[0] + "\n" + nScore2[1] + "\n" + nScore2[2] + "\n" + nScore2[3] + "\n" + nScore2[4] + "\n" +
                 nScore2[5] + "\n" + nScore2[6] + "\n" + nScore2[7] + "\n" + nScore2[8] + "\n" + nScore2[9];

     //   if(normal_timeScript.Flagy==1)
     //   {
            //テキスト出力
            ntextRanking.text = ranking;//ランキング
            ntextYourScore_ex.text = nResultScore.ToString(); //合わせたスコア
            Debug.Log(normal_timeScript.ScoreTime + "HHHHH");
            ntextYourTime_ex.text = normal_timeScript.ScoreTime.ToString("F0");//タイムのみ
                                                                             
     //   }

    }


    void WriteScore(string[] nScore3)
    {
        StreamWriter sw = new StreamWriter("Assets/Resources/NormalRanking.txt", false);
        for (int i = 0; i < nrowLength; i++)
        {
            sw.WriteLine(nScore3[i]);
            if (i == 9)
            {
                sw.Write(nScore3[i]);
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
