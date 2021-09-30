using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QbtnType : MonoBehaviour
{
    //public puzzeQbtn[] actbtn;
    protected Renderer part;
    protected bool State;
    public PuzzeQ _sys;
    protected bool ff = false;

    public virtual void  Start()
    {
        // Debug.Log("type");
        part = this.gameObject.transform.GetChild(0).GetComponent<Renderer>();
        restart();
    }

    public void click()
    {
        _sys.btnClick(this.name);
    }

    public abstract void restart();

    public bool getState()
    {
        return State;
    }


    public abstract void changeState();
}
