using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    public int objectPoolSize = 5;
    public GameObject objectPrefab;

    private GameObject[] objects;

    // Create objest at off screen location in the beginning.
    private Vector2 objectPoolPosition = new Vector2(-11f, 0f);



    private float spawnRate = 2.25f;

    // Respawn position range
    private float objectMinY = -3.12f;
    private float objectMaxY = 2.38f;

    private float spawnPositionX = 5f; // constant 임 

    private int currentObject = 0;


    [SerializeField]
    [Tooltip("it's Serialize fied only to see ia as Debug Check")]
    private float timeSinceLastSpawn = 0f;

    // 시작할때 object 만들어 두는 용도
    private void Start()
    {
        objects = new GameObject[objectPoolSize];

        for(int i = 0; i < objectPoolSize; ++i)
        {
            objects[i] = (GameObject)Instantiate(objectPrefab, objectPoolPosition, Quaternion.identity);

        }



    }

    private void FixedUpdate()
    {
        // Start Timmer in Play Status only
        if (GameManager.instance.gameStatus == GameManager.GameStatus.Play)
            timeSinceLastSpawn += Time.deltaTime;

    }

    private void Update()
    {
        if (timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0;
            float spawnPositionY = Random.Range(objectMinY, objectMaxY);
            objects[currentObject].transform.position = new Vector2(spawnPositionX, spawnPositionY);

            ++currentObject;

            if (currentObject >= objectPoolSize)
                currentObject = 0;
        }



    }
}
