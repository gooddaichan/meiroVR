using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour
{

    public void startbutton()
    { //自分の好きな関数名でok
        SceneManager.LoadScene("select");

    }
}