using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cdBase : MonoBehaviour
{
    public musicnDisplay _SYS;
    public int baseNum;
    private AudioSource _as;
    private AudioClip clip;
    private bool isact;

    private void Start()
    {
        _as = GetComponent<AudioSource>();
        isact = false;
    }

    IEnumerator playsong()
    {
       
        isact = true;
        _as.PlayOneShot(clip);
        yield return new WaitForSeconds(1.5f);
        isact = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CD")
        {
            if (_SYS)
            {
                    clip = _SYS.getSong(baseNum, other.GetComponent<CdNumber>().number);
                    if (_as)
                {
                    if (!isact)
                    {
                        StartCoroutine(playsong());
                    }
                }
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "CD")
        {
            if (_SYS)
            {
                _SYS.getSong(baseNum, 0);
            }
        }
    }
}
