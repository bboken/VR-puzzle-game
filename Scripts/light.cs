using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    public GameObject _light;
    public bool startstate;
    private bool isopen;
    private bool curstate ;
    public bool autoMod;
    // Start is called before the first frame update
    void Start()
    {
        isopen = startstate;
        _light.SetActive(isopen);
    }
    /*
    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player")
            if (autoMod)
                isopen = true;
    }
    void OnTriggerExit(Collider c)
    {
        if (c.tag == "Player")
            if (autoMod)
                isopen = false;
    }*/

    public void Switch(bool _stat)
    {
        if (autoMod)
            isopen = _stat;
    }

    // Update is called once per frame
    void Update()
    {
        if (curstate != isopen)
        {
            _light.SetActive(isopen);
            curstate = isopen;
        }
    }

    public void btnclick()
    {
        isopen = !isopen;
    }


}
