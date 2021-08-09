using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Overlap : MonoBehaviour
{

    //number of balls to generate 
    public int numBallsToGenerate;

    //_____________trying with list__________________
    public List<GameObject> ballList;

    public GameObject quadForBoundary;
    
    // Start is called before the first frame update
    void Start()
    {
        generateInRandomPosition();
        numBallsToGenerate = Random.Range(0, 10);
        print("random number of balls to generate was "+ numBallsToGenerate);
    }

    public void generateInRandomPosition()
    {
        int ballIndex = 0;
        GameObject ball;
        
        MeshCollider c = quadForBoundary.GetComponent<MeshCollider>();
        float screenX, screenY;
        Vector3 position;
        print("its reaching here");
        
        //PROBLEM FROM HEREEEEEEEEEEEEEEEEEEEEEEEEEEEE
        for (int i = 0; i < numBallsToGenerate; i++)
        {
            //this is supposed to get random item, but I dont need random item, I  have 1
            ball = ballList[ballIndex];
            print(i);
            
            //next step is finding random x and y 
            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            position = new Vector3(screenX, screenY, 0f);
            print(position);
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

