using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class hard_timeScript : MonoBehaviour
{
    GameObject limitTimeUI;

    //public UnityEngine.UI.Text scoreLabel;
    //public GameObject winnerLabelObject;
    public float time = 121.0f;
    public static float ScoreTime = 0;
    public static int Flagy = 0;

    // Use this for initialization
    void Start()
    {
        this.limitTimeUI = GameObject.Find("hard_LimitTimeUI");

    }

    IEnumerator sleep()
    {

        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Result");

    }

    void Update()
    {

        // 毎フレーム毎に残り時間を減らす
        this.time -= Time.deltaTime;

        int flag = 0;

        if (this.time < 1)
        {
            this.limitTimeUI.GetComponent<Text>().text = "GAMEOVER";
            Flagy = 1;
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
            if (flag == 1)
            {
                this.limitTimeUI.GetComponent<Text>().text = "GAMECLEAR";
                ScoreTime = time + 3.0f;
                Flagy = 1;
                StartCoroutine("sleep");
            }
           // time = 0.0f;


        }

    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}