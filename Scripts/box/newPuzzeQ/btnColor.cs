using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnColor : QbtnType
{
    private int indexNum;
    public int startNum = 0;
    private int beforeNum;
    private int ffnum;
    private Material[] Color = new Material[4];

    // Start is called before the first frame update
    public override void Start()
    {
        //Debug.Log("override");
        if (_sys)
        {
            for(int i = 0; i < Color.Length; i++)
                Color[i] = _sys.GetColor(i);
            ffnum = _sys.getffNum();
        }
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (beforeNum != indexNum)
        {
            part.material = Color[indexNum];
        }

        beforeNum = indexNum;
    }

    public override void restart()
    {
        indexNum = startNum;
        part.material = Color[indexNum];

        if (indexNum == ffnum)
            State = true;
        else
            State = false;
    }


    public override void changeState()
    {
        indexNum++;
        indexNum %= 4;

        if (indexNum == ffnum)
            State = true;
        else
            State = false;
    }
}
