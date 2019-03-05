using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public GameObject player;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject player5;

    private Vector3 offset;

    private void Start()
    {
        offset = new Vector3(0,2,-4);
    }

    private void LateUpdate()
    {//finds which player is active and shows where the camera should go
        if(player.activeInHierarchy)//if player is active
        transform.position = player.transform.position + offset;//put camera to the correct place
        if (player1.activeInHierarchy)
            transform.position = player1.transform.position + offset;
        if (player2.activeInHierarchy)
            transform.position = player2.transform.position + offset;
        if (player3.activeInHierarchy)
            transform.position = player3.transform.position + offset;
        if (player4.activeInHierarchy)
            transform.position = player4.transform.position + offset;
        if (player5.activeInHierarchy)
            transform.position = player5.transform.position + offset;
    }
}