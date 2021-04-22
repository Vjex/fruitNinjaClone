using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    //On 2D Collision With Blade Call The Stop Game Method In Game Manager Class Script.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();

        //Validating Cllision Only With Blade Object So That  we Will get te b any Value Otherwide Null;
        if (!b) return;

        //Now Calll The Stop Game Method In Game Manager.
        FindObjectOfType<GameManager>().StopTheGame();

    }
}
