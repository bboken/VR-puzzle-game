using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightBtn : MonoBehaviour
{
    public light[] _light;
    
    public void Click()
    {
        for (int i = 0; i < _light.Length; i++)
            _light[i].btnclick();
    }
}
