using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerController : MonoBehaviour
{
    //[SerializeField]
    private GameObject _player;

    public SteamVR_Action_Vector2 input;
    public SteamVR_Action_Boolean run;
    public float startSpeed = 1;
    public float bootUp = 2;
    private float speed;
    private CharacterController characterController;
    private bool isRun;
    // Start is called before the first frame update
    void Start()
    {
        isRun = false;
        while (!_player)
        {
            Debug.Log("PlayerController");
            _player = GameObject.FindGameObjectWithTag("Player");
        }
        
            characterController = _player.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (run.stateDown)
        {
            isRun = !isRun;
           // Debug.Log("isRum : "+isRun);
        }
        Vector3 direction = Vector3.zero;
        if (input.axis.magnitude > 0.1f)
        {
            direction = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));
        }
        else
        {
            isRun = false;
            //Debug.Log("isRum : " + isRun);
        }
        if (isRun)
        {
            speed = startSpeed * bootUp;
        }
        else
            speed = startSpeed;
        if (_player)
            characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up) - new Vector3(0, 9.8f, 0) * Time.deltaTime);
    }
}


