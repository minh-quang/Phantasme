using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour {

    [SerializeField]
    private int dimension;
    [SerializeField]
    private Tiled_Map prefab;
    
	// Use this for initialization
	void Start () {
        for (int x = 0; x < dimension; x++)
        {
            for (int y = 0; y < dimension; y++)
            {
                int rand = Random.Range(1, 4);
                string toset = "Earth" + rand;
                Tiled_Map clone = Instantiate(prefab, new Vector3(x * 10.0f, y * 10.0f, 0), Quaternion.identity) as Tiled_Map;
                //clone.GetComponent<SpriteRenderer>().sprite = clone.GetComponent<Tiled_Map>().getSprite();
                clone.GetComponent<Tiled_Map>().setSprite(Resources.Load<Sprite>(toset));
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
