using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiikuvEse : MonoBehaviour
{
    public float kiirus = 5f;
    public float vahemaa = 3f;
    private Vector3 alustusKoht;
    public bool vertikaalneLiikumine = false;
    public bool diagonaalneLiikumine = false;


    private void Start()
    {
        alustusKoht = transform.position;
    }

    void Update()
    {
        Vector3 offset = Vector3.zero;


        if (diagonaalneLiikumine)
        {
            offset += (Vector3.right + Vector3.up).normalized;
        }
        else
        {
            if (diagonaalneLiikumine)
            {
                offset += Vector3.up;
            }
            else
            {
                offset += Vector3.right;
            }



        }


        offset *= Mathf.Sin(Time.time * kiirus) * vahemaa;
        transform.position = alustusKoht + offset;



    }

}










