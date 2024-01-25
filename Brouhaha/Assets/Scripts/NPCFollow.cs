using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    public GameObject Player;
    //public GameObject NPC;
    public float TargetDisctance;
    public float AllowedDistance;
    public float FollowSpeed;

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(Player.transform);
        TargetDisctance = Vector3.Distance(Player.transform.position, transform.position);
        if (TargetDisctance >= AllowedDistance)
        {
            
            //change to running animation
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, FollowSpeed * Time.deltaTime);
        }
        else
        {
            
            //change to idle animation
        }
    }
}
