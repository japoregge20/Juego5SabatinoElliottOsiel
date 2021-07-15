using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampSlider : MonoBehaviour
{
    //[SerializeField] Slider slider;
    [SerializeField] float inclinacion = 180f;

    private void Update()
    {
        //Vector3 sliderPos = Camera.main.WorldToScreenPoint(this.transform.position);

        transform.LookAt(Camera.main.transform);
        transform.Rotate(0f, 0f, 0f);
        
    }
}
