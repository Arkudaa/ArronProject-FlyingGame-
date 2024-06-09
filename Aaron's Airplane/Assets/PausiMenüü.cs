using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausiMenüü : MonoBehaviour
{
    public GameObject paneel;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            KäivitaPaneeliNähtavus();
        }
    }


    public void KäivitaPaneeliNähtavus()
    { 

        paneel.SetActive(!paneel.activeSelf);


        if (paneel.activeSelf)
        {
            SeiskaMäng();
        }
         else
        {
            JätkaMäng();
        }
    }
        
     private void SeiskaMäng()
     {
        Time.timeScale = 0;
     }


     private void JätkaMäng()
     {
        Time.timeScale = 1;
     }
    
}
