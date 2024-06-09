using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kuul : MonoBehaviour
{
    public float kiirus = 10f;


    public void LaunchTowardsPlayer(float lifetime)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            GetComponent<Rigidbody>().velocity = direction * kiirus;
            Destroy(gameObject, lifetime);
        }
    }
}
