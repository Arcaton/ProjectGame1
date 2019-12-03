using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Angel : MonoBehaviour
{

    private Player player;

    void Start()
    {

        //getting the script (Player) for the player by finding an object with the tag "player"
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        //if something with the tag "Player" collides with the enemy, the player's health is reduced
        if (col.CompareTag("Player"))
        {

            player.Damage(100);

        }

    }
        
}
