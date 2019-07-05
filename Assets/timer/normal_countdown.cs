using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class normal_countdown : MonoBehaviour
{
    [SerializeField]
    private Text textCountdown;
    public normal_timeScript normal_LimitTimeUI;

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
        normal_LimitTimeUI.gameObject.SetActive(true);

    }
}