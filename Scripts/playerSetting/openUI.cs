using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openUI : MonoBehaviour
{

    public GameObject[] UI;
    private GameObject Cam;
    private int index;
    private int curindex;
    // Start is called before the first frame update
    void Start()
    {
        curindex = 0;
        index = -1;
        while (!Cam)
        {
            Cam = GameObject.FindWithTag("MainCamera");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("index : "+index +" , cur : "+curindex);
        if (index != curindex) {
            if (UI[0])
            {
                for (int i = 0; i < UI.Length; i++)
                {
                    if (i == curindex)
                        UI[i].SetActive(true);
                    else
                        UI[i].SetActive(false);
                }
            }
        }
        index = curindex;
    }

    public void open(int page)
    {
        curindex = page;
    }
}
