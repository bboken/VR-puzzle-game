using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPos : MonoBehaviour
{
    private GameObject Cam;
    public Vector3 Offset;
    // Start is called before the first frame update
    void Start()
    {
        while (!Cam)
        {
            Cam = GameObject.FindWithTag("MainCamera");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        pos.y = Cam.transform.position.y;
        pos += Offset;
        transform.position = pos;
    }
}
