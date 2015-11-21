using UnityEngine;
using System.Collections;

public class Tiled_Map : MonoBehaviour {

    [SerializeField]
    private Sprite sprite;

    public int subdivision;

    public int[] map;

    private int temp;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        temp = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //if (temp > 200){
        //    sprite = Resources.Load<Sprite>("Earth2");
        //    gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        //}
        //Debug.Log(temp);
        //temp++;
	}

    public void setSprite(Sprite toset)
    {
        sprite = toset;
    }
}
