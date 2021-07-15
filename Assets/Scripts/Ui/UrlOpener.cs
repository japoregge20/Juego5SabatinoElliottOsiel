using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrlOpener : MonoBehaviour
{
    [SerializeField] string url = default;

    public void OpenUrl()
    {
        Application.OpenURL(url);
    }
}
