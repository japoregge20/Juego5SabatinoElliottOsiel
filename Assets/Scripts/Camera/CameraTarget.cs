using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{

    public void ChangeCamera(Transform valueLocal)
    {
        this.transform.SetParent(valueLocal, false);
    }
}
