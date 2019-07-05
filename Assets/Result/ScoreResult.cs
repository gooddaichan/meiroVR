using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UI関連クラスを使用できるようにする
using UnityEngine.UI;

public class ScoreResult : MonoBehaviour
{
    // UIオブジェクト"Text Score"のTextコンポーネントを格納する変数
    //public Text textScore;
    // UIオブジェクト"Text ResultScore"Textコンポーネントを格納する変数
    public Text textResultScore;
    // ゲーム終了フラグ
    public bool isPlaying = true;

    // ゲーム実行中の繰り返し処理
    void Update()
    {
        // "textResultScore"に格納されたTextコンポーネントの"text"フィールドにスコアを代入
        //（スクリプト"Manager"の変数"score"を文字列として参照）
        //textResultScore.text = expart_timeScript.ScoreTime.ToString();
    }
}
