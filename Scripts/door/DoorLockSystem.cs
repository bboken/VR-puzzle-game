using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLockSystem : MonoBehaviour
{

    public GameObject idol;
    public GameObject interact;
    private bool isopen = false;
    public PuzzeBase passwordLock;


    // Start is called before the first frame update
    void Start()
    {
        idol.SetActive(true);
        interact.SetActive(false);
    }

    void Update()
    {
        if (!isopen)
        {
            if (passwordLock)
                isopen = passwordLock.getFF();
            /*
            else
                isopen = true;*/
            if (isopen)
                unlock();
        }
    }

    public void unlock()
    {
        idol.SetActive(false);
        interact.SetActive(true);
    }
}
