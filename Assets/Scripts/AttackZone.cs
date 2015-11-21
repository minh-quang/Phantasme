using UnityEngine;
using System.Collections;

public class AttackZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Monster")
        {
            col.gameObject.GetComponent<MonsterCaracteristics>().Attack();
        }
    }
    
}
