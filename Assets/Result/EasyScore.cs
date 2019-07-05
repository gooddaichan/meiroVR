using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EasyScore : MonoBehaviour
{

    // スコアを表示する
    public Text scoreText;
    // ハイスコアを表示する
    public Text highScoreText;

    public Text textYourScore_ex;

    public Text textYourTime_ex;

    public Text textItem_ex;

    // ハイスコア
    private float highScore;

    // PlayerPrefsで保存するためのキー
    private string highScoreKey = "highScore";

    public float point = 0;

    public Text textRanking;
    string[] ScoreRanking = new string[10];
    private string[] temp = new string[10];
    private int rowLength;
    private int PlayScore;
    private int count;
    private int GetScoreTime;
    private int GetScoreStar;
    private int ResultScore;

    void Start()
    {
        if (easy_timeScript.Flagy == 1)
        {
            ReadScore();
            Debug.Log("Readscore");
            Debug.Log(ScoreRanking[0] + "\n" + ScoreRanking[1] + "\n" + ScoreRanking[2] + "\n" + ScoreRanking[3] + "\n" + ScoreRanking[4] + "\n" +
                     ScoreRanking[5] + "\n" + ScoreRanking[6] + "\n" + ScoreRanking[7] + "\n" + ScoreRanking[8] + "\n" + ScoreRanking[9]);

            ScoreRanking = Sort(ScoreRanking);
            Debug.Log("Sort");

            output(ScoreRanking);
            Debug.Log("output");

            WriteScore(ScoreRanking);
            Debug.Log("WriteScore");
            Debug.Log(ScoreRanking[0] + "\n" + ScoreRanking[1] + "\n" + ScoreRanking[2] + "\n" + ScoreRanking[3] + "\n" + ScoreRanking[4] + "\n" +
                    ScoreRanking[5] + "\n" + ScoreRanking[6] + "\n" + ScoreRanking[7] + "\n" + ScoreRanking[8] + "\n" + ScoreRanking[9]);
        }

        
    }
    void ReadScore()
    {
        /* TextAsset textasset = new TextAsset();//テキストファイルのデータを取得するインスタンスを作成
         textasset = Resources.Load("Ranking", typeof(TextAsset)) as TextAsset;//Resourcesフォルダから対象テキストを取得
         string TextLines = textasset.text;//テキスト全体をstring型で入れる変数を用意していれる
         */
        int i = 0;
        StreamReader sr = new StreamReader("Assets/Resources/EasyRanking.txt");
        while (sr.Peek() > -1)
        {
            Debug.Log(i);
            ScoreRanking[i] = sr.ReadLine();
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
        rowLength = ScoreRanking.Length;
        Debug.Log("rowLength：" + rowLength);

        sr.Close();


    }

    string[] Sort(string[] Score1)
    {
        //score計算するよここから
        GetScoreTime = (int)(easy_timeScript.ScoreTime);




        if (easy_timeScript.ScoreTime == 0)
        {
            GetScoreStar = 0;
        }
        else
        {
            GetScoreStar = Item.GetStar_ex - 10;
        }

        ResultScore = (int)(GetScoreTime * 0.7) + GetScoreStar;
        //ResultScore = GetScoreStar;



        //ここまで

        // PlayScore = (int)expart_timeScript.ScoreTime;//プレイしたスコアを格納
        PlayScore = ResultScore;
        Score1.CopyTo(temp, 0);//ランキング変動用配列

        if (PlayScore < int.Parse(Score1[4]))//int.Paeseで配列の要素をintに変換
        {                                         //スコアが5位未満
            for (int c = 5; c < rowLength; c++)
            {
                if (c < 9 && PlayScore > int.Parse(Score1[c]))//スコア入れ替え処理
                {
                    Score1[c] = PlayScore.ToString();//スコア更新
                    for (int t = c + 1; t < rowLength; t++)//更新されたスコア以下のスコアを更新
                    {
                        Score1[t] = temp[t - 1];
                    }
                    break;
                }

                if (c == 9 && PlayScore > int.Parse(Score1[c]))
                {
                    Score1[c] = PlayScore.ToString();//スコア更新
                    break;
                }
            }
        }

        else //スコアが5位以上
        {
            for (int c = 0; c < rowLength / 2; c++)
            {
                if (PlayScore > int.Parse(Score1[c]))//スコア入れ替え処理
                {
                    Score1[c] = PlayScore.ToString();//スコア更新
                    for (int t = c + 1; t < rowLength; t++)//更新されたスコア以下のスコアを更新
                    {
                        Score1[t] = temp[t - 1];
                    }
                    break;
                }
            }
        }
        return (Score1);
    }

    void output(string[] Score2)
    {
        string ranking;
        textRanking.fontSize = 10;

        ranking = Score2[0] + "\n" + Score2[1] + "\n" + Score2[2] + "\n" + Score2[3] + "\n" + Score2[4] + "\n" +
                 Score2[5] + "\n" + Score2[6] + "\n" + Score2[7] + "\n" + Score2[8] + "\n" + Score2[9];

      //  if (easy_timeScript.Flagy==1)
      //  {
            //テキスト出力
            textRanking.text = ranking;//ランキング
            textYourScore_ex.text = ResultScore.ToString(); //合わせたスコア                                         
            textYourTime_ex.text = easy_timeScript.ScoreTime.ToString("F0");//タイムのみ
                                                                            
      //  }

    }


    void WriteScore(string[] Score3)
    {
        StreamWriter sw = new StreamWriter("Assets/Resources/EasyRanking.txt", false);
        for (int i = 0; i < rowLength; i++)
        {
            sw.WriteLine(Score3[i]);
            if (i == 9)
            {
                sw.Write(Score3[i]);
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
