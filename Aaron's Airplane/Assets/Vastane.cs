using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vastane : MonoBehaviour
{
    public GameObject tulistatavaKordus; // Ese mida tulistada
    public float tuvastusRaadius = 5f; // Raadius kus m�ngijat tuvastada
    public float viivitusEnneTulistamist = 2f; // Viivitus enne tulistamist
    public float tulistatuIga = 3f; // Kui kaua tulistatav elab
    public Color tuvastusAlaV�rv = Color.red; // Tuvastus ala v�rv
    public float tulistamisVahe = 5f; // Pisem aeg tulistamise vahel
    private float viimaseLasuAeg = -Mathf.Infinity; // J�lgib aega viimasest lasust


    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, tuvastusRaadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player") && Time.time >= viimaseLasuAeg + tulistamisVahe)
            {
                Invoke("ShootProjectile", viivitusEnneTulistamist);
                viimaseLasuAeg = Time.time;
                break; // Kinnitab, et me ei tulistaks mitu eset samal ajal
            }
        }
    }


    void ShootProjectile()
    {
        GameObject projectile = Instantiate(tulistatavaKordus, transform.position, Quaternion.identity);
        projectile.GetComponent<Kuul>().LaunchTowardsPlayer(tulistatuIga);
    }


    // See funktsioon loob n�gemis abi meile
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, tuvastusRaadius);
    }
}

