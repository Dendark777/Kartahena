using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerSceneScr : MonoBehaviour
{
   
    void Start()
    {
        GameManager.IndexCurrnetScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void ReturnLastScene()
    {
        SceneManager.LoadScene(GameManager.IndexLastScene);
        GameManager.IndexLastScene = GameManager.IndexCurrnetScene;
    }

    public void CreateNextScene(int index)
    {
        SceneManager.LoadScene(index);
        GameManager.IndexLastScene = GameManager.IndexCurrnetScene;
    }
}
