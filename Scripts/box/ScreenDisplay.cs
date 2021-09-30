using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ScreenDisplay : PuzzeBase
{
    
    public Text[] _text = new Text[4];
    private int MaxNum;
    private int wordCount;
    public string _idolword;
    private string word;


    [SerializeField]
    private string password;
    public DoorLockSystem _sys;
    public Image _check;
    public Color idol;
    public Color correct;
    public AudioClip eff;
    public AudioClip failEff;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        MaxNum = password.Length;
        wordCount = 0;
        //_text.text = _idolword;
        _check.color = idol;
    }


    public void addWord(string w)
    {
        if (!ff)
        {
            if (!acting)
            {
                playEff();
                if (wordCount < MaxNum)
                {
                    _text[wordCount].text = w;
                    word = word + w;
                    // _text.text = word;
                    wordCount++;
                    Debug.Log(w + " : word Count " + wordCount);
                }

                if (wordCount == MaxNum)
                {
                    StartCoroutine(passwordAct());
                }
            }
        }
    }
    public void cleanWord()
    {
        if (!ff)
        {
            if (!acting)
            {
                playEff();
                clean();
            }
        }
    }

    private void clean()
    {
        playEff();
        wordCount = 0;
        word = "";
        for (int i = 0; i < _text.Length; i++)
            _text[i].text = "";
       // _text.text = word;
        Debug.Log("clean");
    }

    public void removeWord()
    {
        if (!ff)
        {
            if (!acting)
            {
                playEff();
                if (wordCount > 0)
                {
                    word = word.Remove(wordCount - 1);
                    _text[wordCount-1].text = "";
                    Debug.Log(word);
                   // _text.text = word;
                    wordCount--;
                    Debug.Log("remove");
                }
            }
        }
    }

    private void playEff()
    {
        if (eff)
        {
            _as.PlayOneShot(eff);
        }
    }


    IEnumerator passwordAct()
    {
        Debug.Log("in act");
        acting = true;
        yield return new WaitForSeconds(1);
        Debug.Log("act");
        if (password.Equals(word))
        {
            playSuccess();
            _check.color = correct;
            ff = true;
            Debug.Log(ff);
        }
        else
        {
            if (failEff)
            {
                _as.PlayOneShot(failEff);
            }
            ff = false;
            Debug.Log(ff);
            clean();
        }
        acting = false;
    }

}
