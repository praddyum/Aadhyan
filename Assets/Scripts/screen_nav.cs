using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class screen_nav : MonoBehaviour
{
    public void NextScreen(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void PriScreen(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
    public void Sec_Back(){
        SceneManager.LoadScene(1);
    }
    public void Load_Sec(){
        SceneManager.LoadScene(4);
    }
    public void Load_credits(){
        SceneManager.LoadScene(6);
    }
    public void Load_home(){
        SceneManager.LoadScene(0);
    }
    
    public void website()
    {
        Application.OpenURL("https://praddyum.me");
    }

    public void linked_prad()
    {
        Application.OpenURL("https://in.linkedin.com/in/praddyum");
    }
    
    public void linked_ani()
    {
        Application.OpenURL("https://www.linkedin.com/in/anirbandas52134/");
    }
    
}
