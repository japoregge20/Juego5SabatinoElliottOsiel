using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Button openMenu = default;
    [SerializeField] Button closeMenu = default;
    [SerializeField] Button exit = default;
    //[SerializeField] Button backToMenu = default;
    [SerializeField] Button nextPage = default;
    [SerializeField] Button lastPage = default;

    [SerializeField] GameObject menu = default;

    [SerializeField] GameObject[] pages = default;

    private int currentPage = 0;

    private void Start()
    {
        openMenu.onClick.AddListener(OpenMenu);
        closeMenu.onClick.AddListener(CloseMenu);
        nextPage.onClick.AddListener(NextPage);
        lastPage.onClick.AddListener(LastPage);
        exit.onClick.AddListener(ExitGame);
        //backToMenu.onClick.AddListener(BackToMenu);
    }

    public void OpenMenu()
    {
        menu.SetActive(true);
        openMenu.gameObject.SetActive(false);
        pages[currentPage].SetActive(true);
        lastPage.gameObject.SetActive(false);
        closeMenu.gameObject.SetActive(true);
    }

    public void CloseMenu()
    {
        closeMenu.gameObject.SetActive(false);
        menu.SetActive(false);
        openMenu.gameObject.SetActive(true);
        currentPage = 0;
    }

    public void BackToMenu()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void NextPage()
    {
        if(currentPage + 1 <= pages.Length)
        {
            lastPage.gameObject.SetActive(true);

            pages[currentPage].SetActive(false);

            currentPage++;

            pages[currentPage].SetActive(true);

            if(currentPage + 2 > pages.Length)
            {
                nextPage.gameObject.SetActive(false);
            }
        }

    }

    public void LastPage()
    {
        if (currentPage - 1 >= 0)
        {
            nextPage.gameObject.SetActive(true);

            pages[currentPage].SetActive(false);

            currentPage--;

            pages[currentPage].SetActive(true);

            if (currentPage - 1 < 0)
            {
                lastPage.gameObject.SetActive(false);
            }
        }
    }
}
