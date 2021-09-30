using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzeQ : PuzzeBase
{
    [Header("btn Setting")]
    //public GameObject[] btn;
    public int ffnum;
    public int x, y;
    public QbtnType[][] _pQbtn;
    public GameObject light;
    public Material btnTrue;
    public Material btnFalse;
    public Material[] btnColor;
    public bool demo;

   [Header("system Setting")]
    public Material complete;
    public Material uncomplete;
    enum ChangeMode { Agrid, Tline }
    [SerializeField]
    ChangeMode _type = ChangeMode.Agrid;
    
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        Transform[] allChildren = GetComponentsInChildren<Transform>();
        List<GameObject> childObjects = new List<GameObject>();
        foreach (Transform child in allChildren)
        {
            if (child.tag == "Qbtn")
                childObjects.Add(child.gameObject);
        }

        light.GetComponent<Renderer>().material = uncomplete;

        _pQbtn = new QbtnType[x][];
        for (int i = 0; i < _pQbtn.Length; i++)
        {
            _pQbtn[i] = new QbtnType[y];
        }
        for (int i = 0; i < childObjects.Count; i++)
        {
            string[] s = (childObjects[i].name).Split('-');

            _pQbtn[int.Parse(s[0])][int.Parse(s[1])] = childObjects[i].GetComponent<QbtnType>();

            // Debug.Log("name : "+s[0]+" , "+s[1]);
        }
        /*
        for(int i = 0; i < _pQbtn.Length; i++)
        {
            for(int j = 0; j < _pQbtn[i].Length; j++)
            {
                Debug.Log("num : " + i + " , " + j + "   "+_pQbtn[i][j].name);
            }
        }*/

    }

    public void btnClick(string name)
    {
        //Debug.Log(this.name);
        string[] s = (name).Split('-');
        int x = int.Parse(s[0]);
        int y = int.Parse(s[1]);
        if (!ff)
        {
            if (_type == ChangeMode.Agrid)
            {
                for (int i = 0; i < _pQbtn.Length; i++)
                {
                    for (int j = 0; j < _pQbtn[i].Length; j++)
                    {
                        if (Mathf.Abs(x - i) <= 1)
                        {
                            if (Mathf.Abs(y - j) <= 1)
                            {
                                Debug.Log(i + " : " + j + "//abs :" + Mathf.Abs(x - i) + " , " + Mathf.Abs(y - j));
                                if (Mathf.Abs(x - i) != Mathf.Abs(y - j))
                                {
                                    _pQbtn[i][j].changeState();
                                }
                                if ((Mathf.Abs(x - i) + Mathf.Abs(y - j)) == 0)
                                {
                                    _pQbtn[i][j].changeState();
                                }
                            }
                        }
                    }

                }
            }
            else if (_type == ChangeMode.Tline)
            {
                _pQbtn[x][y].changeState();
                for (int i = 0; i < _pQbtn.Length; i++)
                {//垂直
                    if (i != x)
                    {
                        _pQbtn[i][y].changeState();

                    }
                }
                for (int j = 0; j < _pQbtn.Length; j++)
                {//水平
                    if (j != y)
                    {
                        _pQbtn[x][j].changeState();
                    }
                }

            }
            checkff();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (demo)
        {
            ffAct();
        }
    }

    public void checkff()
    {
       // Debug.Log("check");
        bool _check = true;
        for (int i = 0; i < _pQbtn.Length; i++)
        {
            for (int j = 0; j < _pQbtn.Length; j++)
            {
                if (!_pQbtn[i][j].getState())
                {
                    _check = false;
                    break;
                }
            }
            if (!_check)
                break;
        }
        if (_check)
        {
            ffAct();
        }
    }

    public void ffAct()
    {
        ff = true;
        light.GetComponent<Renderer>().material = complete;
    }
    

    public Material GetTrueMater()
    {
        return btnTrue;
    }

    public Material GetFalseMater()
    {
        return btnFalse;
    }

    public Material GetColor(int i)
    {
        return btnColor[i];
    }

    public void Restart()
    {
        if (!ff)
        {
            for (int i = 0; i < _pQbtn.Length; i++)
            {
                for (int j = 0; j < _pQbtn[i].Length; j++)
                {
                    _pQbtn[i][j].restart();
                }
            }
        }
    }
    public int getffNum()
    {
        return ffnum;
    }
}
