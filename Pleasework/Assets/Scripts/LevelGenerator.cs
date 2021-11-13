using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [HideInInspector] public GameObject cameraGO = null;

    [SerializeField] private Level[] levels = null;
    private GameObject currentLevel = null;
    private GameObject oldLevel = null;
    private GameObject newLevel = null;
    private Vector3 endPosition = Vector3.zero;
    [SerializeField] private float nextLevelDistance = 0;

    float distToNextLevel = 10;

    private void Start()
    {
        cameraGO = GameObject.FindGameObjectWithTag("MainCamera");

        StartGeneration();

        if (cameraGO == null) Debug.LogError("Could not find the player gameobject by tag. does the player have the Player tag? :)))");
    }


    private void Update()
    {
        distToNextLevel = cameraGO.transform.position.x - endPosition.x;
        //Debug.Log(distToNextLevel);

        if (distToNextLevel >= -nextLevelDistance)
        {
            SpawnNextLevel();
        }
    }

    void SpawnNextLevel()
    {
        //delete old level 
        DestroyLevel(oldLevel);

        Debug.Log("spawning next level");
        //get a random number
        int rng = Random.Range(0, levels.Length);

        
        //spawn the next level by random
        newLevel = Instantiate(levels[rng].gameObject, new Vector3(endPosition.x, 0, 0), Quaternion.identity);
        endPosition = newLevel.GetComponent<Level>().endPos.position;

        // handle level order
        oldLevel = currentLevel;
        currentLevel = newLevel;

        

       
    }

    void DestroyLevel(GameObject level)
    {
        Destroy(level);
    }

    void StartGeneration()
    {
        SpawnNextLevel();
    }
}