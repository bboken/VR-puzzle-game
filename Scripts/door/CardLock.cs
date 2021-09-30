using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLock : MonoBehaviour
{
    public GameObject passCard;
    public Renderer lig;
    public Material successLig;
    public Material failLig;

    [SerializeField]
    private DoorLockSystem _sys;


    private AudioSource _as;
    public AudioClip successEff;
    public AudioClip failEff;
    private bool acting = false;
    private bool iscorrect = false;

    // Start is called before the first frame update
    void Start()
    {
        _as = GetComponent<AudioSource>();
        if (lig)
            lig.material = failLig;
        if (!passCard)
        {
            Debug.Log("!passCard");
            _sys.unlock();
            if (lig)
                lig.material = successLig;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        if (other.tag == "keyCard")
        {
            if (other.gameObject == passCard)
            {
                if (successEff)
                {
                    iscorrect = true;
                    if (!acting)
                        StartCoroutine(playsong(successEff));
                }
            }
            else
            {
                if (failEff)
                {
                    if (!acting)
                        StartCoroutine(playsong(failEff));
                }
            }
        }
    }

    IEnumerator playsong(AudioClip clip)
    {
        Debug.Log("in act");
        acting = true;
        Debug.Log("act");
        //playsong
        _as.PlayOneShot(clip);
        yield return new WaitForSeconds(1f);
        if (iscorrect)
        {
            lig.material = successLig;
            _sys.unlock();
        }
        acting = false;
            Debug.Log("outact");
    }
}

