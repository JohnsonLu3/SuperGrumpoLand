using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    float MoveSpeed = 10;
    float MaxDist = 15;
    float MinDist = 5;



    public void MoveToPlayer(Transform player) {
        transform.LookAt(player);

        if (Vector3.Distance(transform.position, player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;



            if (Vector3.Distance(transform.position, player.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
            }

        }
    }
}