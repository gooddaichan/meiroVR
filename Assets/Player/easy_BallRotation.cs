using System.Collections;
using UnityEngine;

public class easy_BallRotation : MonoBehaviour
{
    public float amountOfRotation;
    float y;
    GameObject playball;
    Rigidbody rb;

	// Use this for initialization
	void Start () {

        playball = GameObject.Find("playball");
        rb = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
        rb.centerOfMass = this.transform.position;
        Transform myTrasnform = this.transform;

        if (Input.GetButton("Left"))
        {
            rb.transform.Rotate(new Vector3(0, 1, 0));
            //transform.Rotate(Vector3.up, -amountOfRotation);
            Debug.Log(amountOfRotation);
        }
        if(Input.GetButton("Right"))
        {
            Debug.Log(rb.centerOfMass);
            Debug.Log(this.transform.position);

            rb.transform.Rotate(new Vector3(0, -1, 0));
            Debug.Log(amountOfRotation);
        }
        
		
	}
}
