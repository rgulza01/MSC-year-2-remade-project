/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///this class checks the collisions 
//also tells us which ID the ball we clicked has
//and each clicked ball's ID is added to the list of ID's that was initialized in the Spawner class.
public class BallPrefab : MonoBehaviour
{
 
    public bool collided;
    public int id;
    //the problematic reference
    public Spawner reference;
    void Start()
    {
        //problem: had to clear the list here and not in the class where originally instantiated
        FindObjectOfType<Spawner>();
        reference.IDlist.Clear();
    }
    private void OnMouseDown()
    {
        print("you clicked ball number: " + id);
        reference.IDlist.Add(id);
        var totID = reference.IDlist.Count;
        //problem: totBalls is giving the wrong value, by showing 0, so the list is is empty based on this
        var totBalls = reference.totalBalls;
        print("total IDs: " + totID); //right
        print("total balls: " + totBalls); //wrong
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        collided = true;
    }
 
}*/