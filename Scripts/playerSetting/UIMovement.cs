using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMovement : MonoBehaviour
{

    public Text type;
    private string[] txtType = { "搖杆", "傳送" };
    private int index = 0;
    private Movement gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.FindWithTag("GameManager").GetComponent<Movement>();
        gamemanager.Changewalk(index);
    }

    // Update is called once per frame
    void Update()
    {
        type.text = txtType[index];
    }
    public void changeWalk(int T)
    {
        index = gamemanager.Changewalk(T);
        Debug.Log(index);
    }
}
