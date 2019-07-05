using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class easy_countdown : MonoBehaviour
{
    [SerializeField]
    private Text textCountdown;
   public easy_timeScript easy_LimitTimeUI;

    void Start()
    {
   
        //カウントダウン処理
        textCountdown.text = "";
        StartCoroutine(CountdownCoroutine());
    }

    IEnumerator CountdownCoroutine()
    {
        //「3...2...1...GO!」のように表示、その後は消す
        textCountdown.gameObject.SetActive(true);
          
        textCountdown.text = "     3";
        yield return new WaitForSeconds(1.0f);
          
        textCountdown.text = "     2";
        yield return new WaitForSeconds(1.0f);
          
        textCountdown.text = "     1";
        yield return new WaitForSeconds(1.0f);

        textCountdown.text = "START!";
        yield return new WaitForSeconds(1.0f);

        textCountdown.text = "";
        textCountdown.gameObject.SetActive(false);
        easy_LimitTimeUI.gameObject.SetActive(true);

    }
}