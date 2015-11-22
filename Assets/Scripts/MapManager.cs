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

                Quaternion rotation = Quaternion.identity;

                if (x == 0)
                {
                    if (y == 0)
                    {
                        rotation = Quaternion.identity;
                    }
                    else if (y == 1)
                    {
                        rotation = Quaternion.FromToRotation(new Vector3(1,0,0), new Vector3(0,1,0));
                    }
                }
                else if (x == 1)
                {
                    if (y == 0)
                    {
                        rotation = Quaternion.FromToRotation(new Vector3(1, 0, 0), new Vector3(0, -1, 0));
                    }
                    else if (y == 1)
                    {
                        //rotation = Quaternion.FromToRotation(Vector3.right, Vector3.left);
                        rotation = Quaternion.Euler(0, 0, 180f);
                    }
                }
 
                Tiled_Map clone = Instantiate(prefab[rand], new Vector3(x * 4.8f, -y * 4.8f, 0), rotation) as Tiled_Map;
                //clone.GetComponent<SpriteRenderer>().sprite = clone.GetComponent<Tiled_Map>().getSprite();
            }
        }

        EndsOfGame = GameObject.FindGameObjectsWithTag("seringuespawnpoints");
        seringue = EndsOfGame[Random.Range(0, EndsOfGame.Length - 1)].transform.position;
        Instantiate(seringuePrefab, new Vector3(seringue.x,seringue.y,0), Quaternion.identity);
        AstarPath.active.Scan();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
