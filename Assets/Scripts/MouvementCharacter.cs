using UnityEngine;
using System.Collections;

public class MouvementCharacter : MonoBehaviour {

    Animator[] anim;
    Animator anim1;
    Animator anim2;

    private float M_speed;

    // Use this for initialization
    void Start () {
        anim = GetComponentsInChildren<Animator>();
        anim1 = anim[0];
        anim2 = anim[1];
        M_speed = GetComponentInChildren<Player>().MaxSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        anim1.SetFloat("speed", horizontal + vertical);
        anim2.SetFloat("speed", horizontal + vertical);
        Move(horizontal, vertical);
    }

    void Move(float h, float v)
    {
        float Speed = M_speed * Time.deltaTime;
        this.transform.Translate(new Vector2(Speed * h, Speed * v));

    }
}
