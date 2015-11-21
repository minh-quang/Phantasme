using UnityEngine;
using System.Collections;

public class EndOfStage : MonoBehaviour {

    public float timeout;
    private bool activated;
    public float time;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(activated)
        {
            Debug.Log(time + timeout - Time.timeSinceLevelLoad);
        }
	}

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.tag == "Player"){
            if(!activated)
            {
                activated = true;
                time = Time.timeSinceLevelLoad;
                Debug.Log("Activation !");
            }
            if (activated && Time.timeSinceLevelLoad > time + timeout)
            {
                //TODO passer à un level plus dur
                activated = false;
                Debug.Log("On passe au niveau suivant !");
                //Application.LoadLevel("Machin");
                
            }
        }
    }
}
