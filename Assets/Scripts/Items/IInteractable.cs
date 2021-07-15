using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable 
{
    void Apply();

    void OneUse();

    int CurrentUsos();
}
