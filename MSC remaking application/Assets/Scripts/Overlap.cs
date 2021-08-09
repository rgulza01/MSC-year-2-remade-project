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

    public int CountD;
    int numBallsToGenerate;
    public List<GameObject> ballList;

    void Start()
    {
        numBallsToGenerate = Random.Range(2, 10);
        WrappedCoroutine();
    }

    public void WrappedCoroutine()
    {
        StartCoroutine(Coroutine());
    }
    
    public IEnumerator Coroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(1f);
        var c = quadForBoundary.GetComponent<MeshCollider>();
        GameObject ball;
        numBallsToGenerate = Random.Range(1, 10);
            
        for (int i = 0; i < numBallsToGenerate; i++)
        {
            ball = ballList[0];
            
            //next step is finding random x and y 
            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            position = new Vector3(screenX, screenY, 0f);
            Instantiate(ball, position, Quaternion.identity);
            yield return wait;

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

