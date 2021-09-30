using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    List<AudioSource> eff = new List<AudioSource>();
    public AudioSource bgm;
    public AudioClip A;

    // Start is called before the first frame update
    void Start()
    {

        AudioSource[] allChildren = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
		foreach (AudioSource child in allChildren) {
           // Debug.Log(child.gameObject.name);
            if(child.name != bgm.name)
                eff.Add(child);
		}
        bgm.PlayOneShot(A);
        //Debug.Log(allChildren.Length + "    :    " + eff.Count);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangebgmV(float v)
    {
        bgm.volume = v;
    }

    public void ChangeEffV(float v)
    {
        for (int i = 0; i < eff.Count; i++)
        {
            eff[i].volume = v;
        }
    }

    public void Mutebgm()
    {
        bgm.mute = !bgm.mute;
    }

    public void MuteEff()
    {
        for(int i = 0; i < eff.Count; i++)
        {
            eff[i].mute = !eff[i].mute;
        }
    }
}
