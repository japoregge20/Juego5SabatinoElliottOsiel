using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    

    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }

    public void Win()
    {
        SceneManager.LoadScene(3);
    }
}
