using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public UnityEngine.UI.Text scoreLabel;

    public static int count;
    public void Update()
    
    {

        //int 
        count = GameObject.FindGameObjectsWithTag("Star").Length;
        Debug.Log(count);
        //scoreLabel.text = count.ToString();
        
    }
}
