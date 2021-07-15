using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    [SerializeField] Button btnStart = default;
    [SerializeField] Sprite buttonOn = default;
    [SerializeField] Image imgStart = default;
    //[SerializeField] Sprite buttonOff = default;

    private void Start()
    {
        btnStart.onClick.AddListener(PressButton);
    }

    public void PressButton()
    {
        //btnStart.image.sprite = buttonOn;
        imgStart.sprite = buttonOn;

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(1);
    }
}
