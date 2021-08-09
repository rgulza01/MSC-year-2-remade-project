using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Overlap : MonoBehaviour
{
    
    public GameObject quadForBoundary;
    MeshCollider c; 
    float screenX, screenY;
    Vector3 position;

    //new addition 
    //D = delta
    public float CountD;
    //public GameObject ballPrefab;
   

    //________________________________________________________previously
    
    //number of balls to generate 
    int numBallsToGenerate;
    public List<GameObject> ballList;

    
    // Start is called before the first frame update
    void Start()
    {
        numBallsToGenerate = Random.Range(2, 10);
        generateInRandomPosition();
    }

    //this can't be used because this would produce infinite
    // void Update()
    // {
    //     CountD -= Time.deltaTime;
    //     if (CountD <= 0)
    //     {
    //         generateInRandomPosition();
    //         CountD = 2f;
    //     }
    // }
    public void generateInRandomPosition()
    {
        var c = quadForBoundary.GetComponent<MeshCollider>();
        GameObject ball;
        numBallsToGenerate = Random.Range(1, 10);
            
        for (int i = 0; i < numBallsToGenerate; i++)
        {
            //this is supposed to get random item, but I dont need random item, I  have 1
            ball = ballList[0];
            
            //next step is finding random x and y 
            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            position = new Vector3(screenX, screenY, 0f);
            Instantiate(ball, position, Quaternion.identity);
        }
    }
    
    void destroyEvryTime()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Spawnable"))
        {
            Destroy(o);
        }
    }

}

