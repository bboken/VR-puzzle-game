using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class HandleHeight : MonoBehaviour
{
    private CharacterController m_characterController = null;
    [SerializeField]
    private Transform m_Head = null;

    private void Awake()
    {
        m_characterController = GetComponent<CharacterController>();

    }
    // Start is called before the first frame update
    void Start()
    {
       // m_Head = SteamVR_Render.Top().head;
    }

    // Update is called once per frame
    void Update()
    {
        Height();
    }


    private void Height()
    {
        // Get the head in local space
        float headHeight = Mathf.Clamp(m_Head.localPosition.y, 1, 2);
        m_characterController.height = headHeight;

        // cut in half
        Vector3 newCenter = Vector3.zero;
        newCenter.y = m_characterController.height / 2;
        newCenter.y += m_characterController.skinWidth;

        // move capsule in local space
        newCenter.x = m_Head.localPosition.x;
        newCenter.z = m_Head.localPosition.z;



        //Apply
        m_characterController.center = newCenter;
    }
}
