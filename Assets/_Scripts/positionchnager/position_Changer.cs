using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class position_Changer : MonoBehaviour
{

    public GameObject player;

    public float tiemrcool = 0.5f;

    public bool canTP;


    private void Update()
    {
        player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            canTP = true;
            tiemrcool -= Time.deltaTime;
        }
        if (canTP == true && tiemrcool > 0)
        {
            player.transform.position = this.transform.position;
        }

    }

}
