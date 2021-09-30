using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonFun : MonoBehaviour
{
    [SerializeField]
    private GameObject _btnBase;
    [SerializeField]
    private Transform startPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _btnBase)
        {
            Debug.Log("Trigger");
            transform.position = startPoint.position;
        }
    }
}
