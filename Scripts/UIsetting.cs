using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIsetting : MonoBehaviour
{
    public GameObject UI;
    private GameObject Cam;
    public bool isopenUI;
    private bool _open;
    private float activeDist = 1.8f;

    private void Start()
    {
        if(UI)
             UI.SetActive(isopenUI);
        
        while (!Cam) 
        {
            Cam = GameObject.FindWithTag("MainCamera");
        }
    }
    // Update is called once per frame
    void Update()
    {
        roteUI2();
        if(!isopenUI)
            if (UI)
                changeAct();
    }


    public void roteUI2()
    {
        transform.LookAt(Cam.transform);
    }
    public void roteUI()
    {
        Quaternion rote = UI.transform.rotation;
        rote.y = Cam.transform.rotation.y;
        UI.transform.rotation = rote;
        // Debug.Log(rote);
    }
    public void changeAct()
    {
        float o2cam = Vector3.Distance(this.transform.position,Cam.transform.position);
        if(o2cam < activeDist)
        {
            _open = true;
        }
        else
        {
            _open = false;
        }

        UI.SetActive(_open);
    }

    public void Btn()
    {
        Debug.Log("onclick");
    }

}
