using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    enum moveType { Controller, Teleport}

    [SerializeField]
    moveType _type = moveType.Controller;

    [SerializeField]
    private GameObject teleport;
    [SerializeField]
    private GameObject controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        change();
    }

    public int Changewalk(int m)
    {
        if (m == 0)
            _type = moveType.Controller;
        else if (m == 1)
            _type = moveType.Teleport;

        return getMoveType();
    }

    public int getMoveType()
    {
        if (_type == moveType.Controller)
            return 0;
        else if (_type == moveType.Teleport)
            return 1;
        else
            return -1;
    }

    private void change()
    {

        if (_type == moveType.Controller)
        {
            controller.SetActive(true);
            teleport.SetActive(false);
        }
        else if (_type == moveType.Teleport)
        {
            controller.SetActive(false);
            teleport.SetActive(true);
        }
    }
}
