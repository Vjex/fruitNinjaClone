using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{

    public GameObject slicedFruitPrefab;

  

    //// Update is called once per frame
    //void Update()
    //{
    //       //When User Hits Space Key Just Call The Method To Create Sliced Fruit Instance along With Destroy the Original Fruit.
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        CreateSlicedFruit();
    //    }
        
    //}

    //Method To Creaate The Sliced Fruit Instance From The Joint Fruit .
    public void CreateSlicedFruit()
    {
        //Instatiate the Cutted Fruit along With Get The Game Object Of That Instatiated Cutted Fruit Object To Add Some More Behaviour Like Explosion and Other Effects.
        GameObject newCuttGameObject = (GameObject)Instantiate(slicedFruitPrefab , transform.position , transform.rotation);


        //Get The Game Manager Class and Call The Play Random Slice Sound As The Fruit is Sliced
        FindObjectOfType<GameManager>().PlayRandomSliceSound();


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


        //Increase The Score Of Teh Game and pass The Score Point One On Cut of Orange
        //This GameManager Class is assigned to a empty Object .
        FindObjectOfType<GameManager>().IncreaseTheScore(1);

        //Now Destroy The Original Fruit After Instatntiating New Cut Fruit.
        //GameObject Is Inbuilt Var of The Object On Which This Script Will Be Added i.e Joint Orange Fruit here.
        Destroy(gameObject);

        //After 5 seconds also Destroy the Cut Fruit Instatiated So that It Goes From Screen out Only Then otherwise There Will So many Cutted Fruit Object Will be in Background after some Time.
        Destroy(newCuttGameObject, 5);
      
    }


    ///On trigger 2D With Blade Element We Will Call The Cut Fuit Method.
    ///On trigger 2D is Used Other than OnCollider2D Because We Have IsTriiggered Enabled to both the Fruit
    /////Prefab Of Orange Variant and Blade Under Circle Collission2D So that On Collision With Blade Only This Cut Fruit Method Is Called Not With any Other Fruit.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();

        //Validating if Triggered Element/Component is Balde Or Not
        if (!b)
        {
            return;
        }

        //Create Cut Frut Of That Element Only
        CreateSlicedFruit();
    }


}
