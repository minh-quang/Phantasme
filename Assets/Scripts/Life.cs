using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {

    GameObject player;
    float length;
    float pas;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        length = gameObject.GetComponent<RectTransform>().sizeDelta.y;
        pas = length / 100.0f;
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(
            gameObject.GetComponent<RectTransform>().sizeDelta.x,
            pas *100* Mathf.Floor(player.GetComponent<Player>().Health / player.GetComponent<Player>().MaxHealth)
            );
	}
}
