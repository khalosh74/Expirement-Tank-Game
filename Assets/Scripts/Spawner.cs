using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Vector2 screenBounds;
    [SerializeField] private GameObject enemyOne;
    [SerializeField] private GameObject enemyTwo;
    private GameObject prefab;
    [SerializeField] private float respawnTime = 1.0f;
    private List<GameObject> spawnList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        spawnList.Add(enemyOne);
        spawnList.Add(enemyTwo);
        spawnList.Add(enemyTwo);
    }
    private void SpawnEnemies()
    {
        for(int i = 0; i < spawnList.Count; i++)
        {
            GameObject clone = Instantiate(spawnList[i]);
            clone.transform.position = new Vector2(Random.Range(-screenBounds.x * -1.5f, screenBounds.x * -1.5f), Random.Range(-screenBounds.y * -1.5f, screenBounds.y * -1.5f));
        }
    }
    float timer = 0;
    void Spawn()
    {
        timer += Time.deltaTime;
        if(timer >= respawnTime)
        {
            SpawnEnemies();
            timer = 0;
        }

    }
    // Update is called once per frame
    void Update()
    {
        Spawn();
    }
}
