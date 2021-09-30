using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startAct : MonoBehaviour
{
    public Transform startpoint;
    public GameObject _playerPerfab;
    private GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        while (!player) {
            player = GameObject.FindWithTag("Player");
            if (!player)
            {
                Debug.Log("no player");
                Instantiate(_playerPerfab, startpoint.position, Quaternion.identity);
            }
            else
            {
                Debug.Log("have player");
                player.transform.position = startpoint.transform.position;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
