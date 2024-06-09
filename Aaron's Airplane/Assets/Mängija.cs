using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mängija : MonoBehaviour
{
    public float FlySpeed = 5;
    public float YawAmount = 125;
    public int score;
    public AudioSource Waypoint;
    public Text ScoreText;

    private float Yaw;

    void Start()
    {
        ScoreText.GetComponent<Text>();
        ScoreText.text = "" + score;
    }

   
    void Update() 
    {
        transform.position += transform.forward * FlySpeed * Time.deltaTime;


        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        // yaw, pitch, roll
        Yaw += horizontalInput * YawAmount * Time.deltaTime;
        float pitch = Mathf.Lerp(0, 20, Mathf.Abs(verticalInput)) * Mathf.Sign(verticalInput);
        float roll = Mathf.Lerp(0, 20, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);


        // apply rotation
        transform.localRotation = Quaternion.Euler(Vector3.up * Yaw + Vector3.right * pitch + Vector3.forward * roll);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Score")
        {
            Destroy(other.gameObject, 0.1f); //destroys the waypoint in 0.1 second
            Waypoint.Play(); //plays the sound effect
            score++; //updates the score system by adding 1
            ScoreText.text = "" + score; //updates the HUD


            if (score == 5)
            {
                Application.LoadLevel("level2");
            }


        }


        if (other.gameObject.tag == "Surm")
        {
            Application.LoadLevel(Application.loadedLevel);
        }

    }
}
