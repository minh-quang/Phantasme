using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterManager : MonoBehaviour {

    public int maxMonster = 20;
    public static int monsterInGame;

    protected List<GameObject> monsterInStock;
    public List<GameObject> monsterSpawners;
    public GameObject[] monsterPrefabs;

	// Use this for initialization
	void Start () {
        monsterInStock = new List<GameObject>();
        GetAllSpawnersMap();
        /*
        for(int i = 1; i < 10; i++)
        {

        }*/
    }
	
    void GetAllSpawnersMap()
    {
        monsterSpawners = new List<GameObject>(GameObject.FindGameObjectsWithTag("Spawner"));
    }

    void spawnMonster(float x, float y)
    {
        if(monsterInGame < maxMonster)
        {
            if (monsterInStock.Count > 0)
            {
                GameObject newMob = monsterInStock[0];
                newMob.SetActive(true);
                newMob.transform.position = x * Vector3.right + y * Vector3.up;
                monsterInStock.RemoveAt(0);
            }
            else
            {
                Instantiate(monsterPrefabs[0], x * Vector3.right + y * Vector3.up, Quaternion.identity);
            }
            monsterInGame++;
        }
            
    }

    void spawnMonsterAt(GameObject spawner)
    {
        if(spawner.tag == "Spawner")
        {
            spawnMonster(spawner.transform.position.x, spawner.transform.position.y);
        }
    }

    void destroyerMonster(GameObject monster)
    {
        monster.SetActive(false);
        monster.transform.position = Vector3.back;
        monsterInStock.Add(monster);
        monsterInGame--;
    }

	// Update is called once per frame
	void Update () {
        spawnMonsterAt(monsterSpawners[0]);
	}
}
