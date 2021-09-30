using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class DoorGrabbable : MonoBehaviour
{
    public Transform handler;
    private Interactable interactable;
    Vector3 myScale;
    public Mesh _idol;
    public Mesh _Grab;
    private BoxCollider _boxC;
    public bool isstop;


    // Update is called once per frame
    void Update()
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        myScale = transform.localScale;
        _boxC = GetComponent<BoxCollider>();
    }

    private void HandHoverUpdate(Hand hand)
    {
        GrabTypes grabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(gameObject);

        //GRAB the object
        if (interactable.attachedToHand == null && grabType != GrabTypes.None)
        {
            GetComponent<MeshFilter>().mesh = _Grab;
            //Debug.Log("Grab");
            hand.AttachObject(gameObject, grabType);
            hand.HoverLock(interactable);
            _boxC.enabled = false;

        }
        //Release
        else if (isGrabEnding)
        {
            GetComponent<MeshFilter>().mesh = _idol;
            //Debug.Log("release");
            hand.DetachObject(gameObject);
            hand.HoverUnlock(interactable);
            _boxC.enabled = true;
            if(isstop)
                stop();
            reSet();
        }
    }


    private void OnHandHoverEnd(Hand hand)
    {
        reSet();
        stop();
    }

    private void stop()
    {

        Rigidbody rbhandler = handler.GetComponent<Rigidbody>();
        rbhandler.velocity = Vector3.zero;
        rbhandler.angularVelocity = Vector3.zero;
    }

    private void reSet()
    {
        transform.position = handler.transform.position;
        transform.rotation = handler.transform.rotation;
        transform.localScale = myScale;
    }
}
