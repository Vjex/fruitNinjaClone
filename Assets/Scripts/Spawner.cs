using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
       //The List of  Gamem Object is The Fruit Prefab which is To Spawn randomly.
    public GameObject[] objectsToSpawnPrefab;

    //Bomb Game Object
    public GameObject bombObjectPrefab;

    //This Is The Array Of Places From Where Fruits To be Spawned.
    public Transform[] spawnPlaces;

    //Min max Time To Wait To Spawn A New Fruit 
    public float minWait = 0.3f;
    public float  maxWait = 1f;

    //Min Max Force Applied To New Spawned Fruit in Upward Dorection.
    public int minForce = 12;
    public int maxForce = 17;

    private void Start()
    {   
        //Start CoRoutine For Spawing Of Fruits.
        StartCoroutine(StartSpawningFruits());
    }


    //Method To return a Ienumerator of Spawning fruit automatically as StartCouroutine will automatically Call iEnumerator passed To it  
    //Only One Time And There We Need To use A While Loop to Return New Iterable Value evry Time. That Will be Updated To the Front End.

    //Working Of CoRoutine  ==>
    // Use One Of The StartCoroutine Method Available To Overide.
    //Which Requires A Ienumeratior as  Many Time As We Want Like In A Infinite While Loop.

    private IEnumerator StartSpawningFruits()
    {
        //A While Loop That Will End With The End(False) Of Couroutine Only Otherwill Will Always True.
        while (true)
        {
  
        //This Below Lone Is To Stop Execution for The Random Seconds.
        yield return new WaitForSeconds(Random.Range(minWait, maxWait));

        //Randomly Select Any Place From Spawning Places Array to spawn Fruit From That Place.
        Transform t = spawnPlaces[Random.Range(0,spawnPlaces.Length)];

            //Desciding Which Game Object To Instantiate.
            GameObject go = null;

            var descider = Random.Range(0, 100);

            //if Descider is Less Than 20 then Intatiate a Bomb Otherwise The Random Fruit from Fruits Prefab Object List .
            if (descider < 20)
            {
                go = bombObjectPrefab;
            }
            else
            {
                go = objectsToSpawnPrefab[Random.Range(0, objectsToSpawnPrefab.Length)];
            }



        //Now Instantiate That Fruit Object To Spawn and also get Its game Object to add More Properties like Up Force etc on It.

        GameObject newFruitObject = (GameObject)Instantiate(go, t.position , t.rotation );

        //Now get The Game Object RigidBody 2D (2D To apply Force only on 2 D Direct ) to apply Upward Force on It.
        newFruitObject.GetComponent<Rigidbody2D>().AddForce(t.up * Random.Range(minForce, maxForce) , ForceMode2D.Impulse );



        //Now As This Method Will be Called Automatically in every Frame So We Need To Destroy The Instatiated GameObject 
        //Otherwise After Sometime So Many Game Object Will Be Created In the Background And Will Affect The Game Execution.
        //After 5 Seconds.
        Destroy(newFruitObject , 5);

        }

    }


}
