using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirLig : MonoBehaviour
{
    public Vector3 c;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(c * Time.deltaTime, Space.World);
    }
}
