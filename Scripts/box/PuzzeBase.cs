using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PuzzeBase : MonoBehaviour
{
    protected bool ff;
    protected bool acting;
    protected AudioSource _as;
    public AudioClip success;

    public virtual void Start()
    {
        acting = false;
        ff = false;
        _as = GetComponent<AudioSource>();
    }

    public bool getFF()
    {
        return ff;
    }

    public void playSuccess()
    {
        if (_as)
            if (success)
                _as.PlayOneShot(success);
    }
}
