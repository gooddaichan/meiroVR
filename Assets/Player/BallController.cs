using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
    public float Speed;
    //public float amountOfRotation;
   


    
    void Start(){
    }

    void Update(){
        Vector3 tmp = GameObject.Find("Plane").transform.position;
        if (Input.GetButton("Up"))
        {
            transform.position += new Vector3(0,0,-Speed);

        }
        if (Input.GetButton("Down"))
        {
            transform.position -= new Vector3(0, 0, -Speed);
        }
        /*
        if (Input.GetButton("Left"))
        {
            transform.Rotate(Vector3.up, -amountOfRotation);
        }
        if (Input.GetButton("Right"))
        {
            transform.Rotate(Vector3.up, amountOfRotation);
        }
        */
        

    }
}
