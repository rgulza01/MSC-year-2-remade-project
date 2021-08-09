/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Spawner : MonoBehaviour
{
    private float xRandomPos, yRandomPos;
    Vector3 finalRandomPos;
    public int numToGenerate;
 
    public List<GameObject> listOfObjects;
    public List<GameObject> NewlistOfObjects; //for balls that do not collide 
    //problematic line
    public int totalBalls { get; set; }
    //ID for each ball
    public List<int> IDlist;
 
 
    public GameObject background;
    MeshCollider borders;
 
    void Start()
    {
        borders = background.GetComponent<MeshCollider>();
        WrappedCoroutine();
        numToGenerate =  Random.Range(2,12);
    }
 
    /// <summary>
    /// For the Button to click
    /// </summary>
    public void WrappedCoroutine()
    {
        StartCoroutine(Coroutine());
    }
 
    /// <summary>
    /// Main method that generates the balls in random positions
    /// </summary>
    /// <returns></returns>
    public IEnumerator Coroutine()
    {
        //coroutine
        WaitForSeconds wait = new WaitForSeconds(1f);
 
        int randomItemFromListIndex;
        GameObject randomItemFromList; 
 
        int idNum = 1;
        for (int i = 0; i < numToGenerate; i++)
        {
            //where to generate
            xRandomPos = Random.Range(borders.bounds.min.x, borders.bounds.max.x);
            yRandomPos = Random.Range(borders.bounds.min.y, borders.bounds.max.y);
            finalRandomPos = new Vector3(xRandomPos, yRandomPos, 0f);
         
            //what to generate
            randomItemFromListIndex = Random.Range(0, listOfObjects.Count);
            randomItemFromList = listOfObjects[randomItemFromListIndex];
         
            //to detect collision
 
            GameObject ball = Instantiate(randomItemFromList, finalRandomPos, Quaternion.identity);
 
            ball.GetComponent<Renderer>().enabled = false;
         
            yield return new WaitForFixedUpdate();
         
         
            bool hasCollided = ball.GetComponent<BallPrefab>().collided;
         
            print("collided? " + hasCollided);
            if (hasCollided == false)
            {
                ball.GetComponent<BallPrefab>().id = idNum++;
                NewlistOfObjects.Add(ball);
            }
        }
        totalBalls = NewlistOfObjects.Count;
        print("total balls minus those collided: " + totalBalls); //this keeps being 0
 
        //loop to make them appear on screen and check the IDs
        for (int i = 0; i < totalBalls; i++)
        {
            NewlistOfObjects[i].GetComponent<Renderer>().enabled = true;
            print("ID of the ball " + i + " is " + NewlistOfObjects[i].GetComponent<BallPrefab>().id);
            yield return wait;
        }
    }
 
    /// <summary>
    /// Restarts the current scene when the button is clicked
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene("random spawn");
    }
 
}*/