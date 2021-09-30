using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_Auto : MonoBehaviour
{
    // Start is called before the first frame update
    public light[] _light;
    private bool stat = false;

    void OnTriggerStay(Collider c)
    {
        if (c.tag == "Player")
        {
            Debug.Log("trigger  "+ stat);
            if (!stat)
            {
                stat = true;
                for (int l = 0; l < _light.Length; l++)
                {
                    _light[l].Switch(true);
                }
            }
        }
               
    }
    
    void OnTriggerExit(Collider c)
    {
        if (c.tag == "Player")
            stat = false;
            for (int l = 0; l < _light.Length; l++)
            {
                _light[l].Switch(false);
            }
    }
  
}
