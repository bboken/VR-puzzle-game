using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnBool : QbtnType
{
    private Material btnTrue;
    private Material btnFalse;
    public bool startState;
    private bool beforeState;

    void Start()
    {
        base.Start();
        if (_sys)
        {
            btnTrue = _sys.GetTrueMater();
            btnFalse = _sys.GetFalseMater();
        }
        if (State)
            part.material = btnTrue;
        else
            part.material = btnFalse;

    }

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

    public override void restart()
    {
        State = startState;
    }
    public override void changeState()
    {
        State = !State;
    }
}
