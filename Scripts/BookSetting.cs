using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookSetting : MonoBehaviour
{
    public Text f;
    public Text s;
    public Text txthint;
    public string BookName;
    public string hint;
    // Start is called before the first frame update
    void Start()
    {
        f.text = BookName;
        s.text = BookName;
        txthint.text = hint;
    }

}
