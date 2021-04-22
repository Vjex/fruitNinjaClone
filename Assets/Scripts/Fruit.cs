using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{

    public GameObject slicedFruitPrefab;

  

    // Update is called once per frame
    void Update()
    {
           //When User Hits Space Key Just Call The Method To Create Sliced Fruit Instance along With Destroy the Original Fruit.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateSlicedFruit();
        }
        
    }

    //Method To Creaate The Sliced Fruit Instance From The Joint Fruit .
    public void CreateSlicedFruit()
    {
        //Instatiate the Cutted Fruit along With Get The Game Object Of That Instatiated Cutted Fruit Object To Add Some More Behaviour Like Explosion and Other Effects.
        GameObject newCuttGameObject = (GameObject)Instantiate(slicedFruitPrefab , transform.position , transform.rotation);


        ////////////
        ///Now We Will Add The Explosion Behaviour In The new Cutted Fruit So That It Look More Realistic alon With We Will Also Change Rotation Of Each Cut Pice In The Cutted Fruit .

        //For That We First Need RigiDbody Of Each part and We Have Function Inbuit For That in Unity.
        Rigidbody[] rbsOfSlicedFruit = newCuttGameObject.transform.GetComponentsInChildren<Rigidbody>();

        //Now Add Exposion and Change Rotation Property of Each Part. Here Will Be Two Parts As Fruit Cutted Contains Two parts.
        //Random.rotation; ===> This is Inbuilt Unity metho that Will Automatical Give A Random Roation Value Every Time And We Will get realistic feel.

        foreach (Rigidbody r in rbsOfSlicedFruit)
        {
            //Change Roattion to a Random Value Every Time of Each part of Cutted Fruit.
            r.transform.rotation = Random.rotation;

            //Add A Explosion Like Effect to The each part of New Cutted game Object.
            //5 here Is A value Of Radius Of Explosion area.
            r.AddExplosionForce(Random.Range(500,1000),transform.position,5);


        }

        //Now Destroy The Original Fruit After Instatntiating New Cut Fruit.
        //GameObject Is Inbuilt Var of The Object On Which This Script Will Be Added i.e Joint Orange Fruit here.
        Destroy(gameObject);

    }
}
