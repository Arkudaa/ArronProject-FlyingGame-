using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SulgeNupp : MonoBehaviour
{
   public void  Sulge()
    {
        #if UNITY_STANDALONE
            Application.Quit();
        #endif

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif

    }
}
