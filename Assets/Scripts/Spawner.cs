using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] asteroidPrefab;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAsteroid());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnAsteroid()
    {
        yield return new WaitForSeconds(5);

        if (GameConst.score < 100)
        {
            index = 0;
        }else if(GameConst.score < 200)
        {
            index = 1;
        }
        else
        {
            index = 2;
        }

        Instantiate(asteroidPrefab[index], transform.position, Quaternion.identity);

        StartCoroutine(SpawnAsteroid());
    }
}
