using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{

    public void PlayScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

}
