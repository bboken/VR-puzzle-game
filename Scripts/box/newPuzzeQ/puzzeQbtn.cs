using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzeQbtn : MonoBehaviour
{
    //public puzzeQbtn[] actbtn;
    public Renderer part;
    public bool startState;
    private bool State;
    private bool beforeState;
    private Material btnTrue;
    private Material btnFalse;
    public PuzzeQ _sys;
    private bool ff = false;

    // Start is called before the first frame update
    void Start()
    {
        if (_sys)
        {
            btnTrue = _sys.GetTrueMater();
            btnFalse = _sys.GetFalseMater();
        }
        restart();
        if (State)
            part.material = btnTrue;
        else
            part.material = btnFalse;


    }

    public void restart()
    {
        State = startState;
    }

    // Update is called once per frame
    void Update()
    {
        if (beforeState != State)
        {
            if (State)
            {
                part.material = btnTrue;
            }
            else
            {
                part.material = btnFalse;
            }
        }

        beforeState = State;
    }

    public void click()
    {
        Debug.Log(this.name);
        _sys.btnClick(this.name);
    }


    public bool getState()
    {
        return State;
    }

    public void changeState()
    {
        State = !State;
    }
}
