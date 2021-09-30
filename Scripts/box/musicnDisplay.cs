using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class musicnDisplay : PuzzeBase
{

    public AudioClip[] P;
    public AudioClip[] K;
    public AudioClip[] T;
    public float delayTime = 1.5f;

    [SerializeField]
    private int[] password = { 0,0,0};
    private int[] ans = { 0, 0, 0 };
    public DoorLockSystem _sys;
    public Image[] _check;
    public Color idol;
    public Color correct;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        for (int i = 0;i<_check.Length;i++)
            _check[i].color = idol;
    }

    void checkcorrect()
    {
        if (!ff)
        {
            for(int x = 0; x < password.Length; x ++)
            {
                if (ans[x] != password[x])
                {
                    return;
                }
            }
            ff = true;
            playSuccess();
        }
    }
    private int count;
    public void playAns()
    {
        Debug.Log("ans");
        if (!acting)
        {
            count = 0;
            StartCoroutine(playsong());
        }
    }

    IEnumerator playsong()
    {
        Debug.Log("in act");
        acting = true;
        Debug.Log("act");
        //playsong
        
        count++;
        if (count == 1)
        {
            if(P[password[count - 1]])
            _as.PlayOneShot(P[password[count - 1]]);
        }else if (count == 2)
        {
            if (K[password[count - 1]])
                _as.PlayOneShot(K[password[count - 1]]);
        }
        else if(count == 3)
        {
            if (T[password[count - 1]])
                _as.PlayOneShot(T[password[count - 1]]);
        }
        yield return new WaitForSeconds(delayTime);
        //replay
        if (count < password.Length)
            StartCoroutine(playsong());
        //end
        else
        {
            acting = false;
            Debug.Log("outact");
        }
    }


    public AudioClip getSong(int _base, int number)
    {
        if (!ff)
        {
            ans[_base] = number;
            if (ans[_base] == password[_base])
                _check[_base].color = correct;
            else
                _check[_base].color = idol;

            checkcorrect();
            Debug.Log(ans[_base]+"  :  "+ password[_base]+"  =  "+   ans[_base].Equals(password[_base]));

            if (_base == 0)
            {
                return P[number];
            }
            else if (_base == 1)
            {
                return K[number];
            }
            else if (_base == 2)
            {
                return T[number];
            }
            else
                return null;
        }
        else
            return null;
    }

}


