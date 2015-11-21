using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour {

    public int dimension;
    public float taille;

    

    [SerializeField]
    private Tiled_Map[] prefab = new Tiled_Map[4];

    public Vector3 seringue;
    public EndOfStage seringuePrefab;
    private GameObject[] EndsOfGame;
    

    
	// Use this for initialization
	void Start () {
        for (int x = 0; x < dimension; x++)
        {
            for (int y = 0; y < dimension; y++)
            {
                int rand = Random.Range(0, prefab.Length - 1);

                Tiled_Map clone = Instantiate(prefab[rand], new Vector3(x * 10.0f, y * 10.0f, 0), Quaternion.identity) as Tiled_Map;
                //clone.GetComponent<SpriteRenderer>().sprite = clone.GetComponent<Tiled_Map>().getSprite();
            }
        }

        EndsOfGame = GameObject.FindGameObjectsWithTag("seringuespawnpoints");
        seringue = EndsOfGame[Random.Range(0, EndsOfGame.Length - 1)].transform.position;
        Instantiate(seringuePrefab, seringue, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
