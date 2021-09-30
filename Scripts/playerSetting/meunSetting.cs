using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class meunSetting : MonoBehaviour
{
    public GameObject UI;
    public SteamVR_Action_Boolean _ui;
    public GameObject Oppos;
    private bool isopen;

    private CharacterController m_characterController = null;
    [SerializeField]
    private Transform m_Head = null;

    private void Start()
    {
        isopen = false;
    }

    // Update is called once per frame
    void Update()
    {
       // UI.transform.position.y = m_Head.transform.position.y;
        if (UI)
        {
            if (_ui.stateDown)
            {
                isopen = !isopen;
                UI.transform.position = Oppos.transform.position;
            }
            if (isopen)
            {
                UI.SetActive(true);
            }
            else
            {
                UI.SetActive(false);
            }
        }
    }
}
