using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitEndGame : MonoBehaviour
{
    [SerializeField] Button exit = default;

    private void Start()
    {
        exit.onClick.AddListener(EndGame);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
