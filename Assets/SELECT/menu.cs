using UnityEngine;
using UnityEngine.UI; // UIコンポーネントの使用

public class menu : MonoBehaviour
{
    Button easy;
    Button normal;
    Button hard;
    Button expart;
    Button start;

    void Start()
    {
        // ボタンコンポーネントの取得
       
        easy = GameObject.Find("/Canvas/Button1").GetComponent<Button>();
        normal = GameObject.Find("/Canvas/Button2").GetComponent<Button>();
        hard = GameObject.Find("/Canvas/Button3").GetComponent<Button>();
        expart = GameObject.Find("/Canvas/Button4").GetComponent<Button>();


        // 最初に選択状態にしたいボタンの設定
        easy.Select();
    }
    
   void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}