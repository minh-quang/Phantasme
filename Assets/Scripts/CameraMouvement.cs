using UnityEngine;
using System.Collections;

public class CameraMouvement : MonoBehaviour {
    public GameObject target;
    float x;
    float y;


	// Use this for initialization
	void Start () {
        x = target.transform.position.x;
        y = target.transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        float deplacementX = target.transform.position.x - x;
        float deplacementY = target.transform.position.y - y;
        this.transform.Translate(new Vector2(deplacementX, deplacementY));

        x = target.transform.position.x;
        y = target.transform.position.y;
    }
}
