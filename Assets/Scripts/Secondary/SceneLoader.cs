using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMap()
    {
        SceneManager.LoadScene((int)SceneList.AR_MAP_SCENE);
    }

    public void LoadSecondary()
    {
        SceneManager.LoadScene((int)SceneList.SECONDARY_SCENE);
    }
}
