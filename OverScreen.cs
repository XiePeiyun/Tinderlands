using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class OverScreen : MonoBehaviour
{
    public GameObject startScreen;
    public void Yesclick()
    {
        SceneManager.LoadScene(0);
    }
    
    public void NoClick()
    {
        SceneManager.LoadScene(1);
        //startScreen.SetActive(true);
        //this.gameObject.SetActive(false);
    }

}
