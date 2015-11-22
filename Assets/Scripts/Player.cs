using UnityEngine;
using System.Collections;
public class Player : MonoBehaviour {

    public float MaxHealth;
    public float Health;
    public float MaxSpeed;
    public Vector2 position;
    private bool isHitting;

    int dimension;
    float taille;

    private float TimeAttack;

    Animator[] anim;
    Animator anim1;
    Animator anim2;

    //Orientation selon la souris
    private Vector3 mouse_pos;
    private Vector3 Obj_pos;
    private float angle;
    

    // Use this for initialization
    void Start () {
        Health = MaxHealth;
        position = this.transform.position;

        dimension = GameObject.FindGameObjectWithTag("MapManager").GetComponent<MapManager>().dimension;
        taille = GameObject.FindGameObjectWithTag("MapManager").GetComponent<MapManager>().taille;

        anim = GetComponentsInChildren<Animator>();
        anim1 = anim[0];
        anim2 = anim[1];

        TimeAttack = 0;
    }
	
	// Update is called once per frame
	void Update () {
        //Mort
	    if (Health <= 0)
        {
            Die();
        }

        //Orientation selon la souris
        mouse_pos = Input.mousePosition;
        Obj_pos = Camera.main.WorldToScreenPoint(this.transform.position);
        mouse_pos.x -= Obj_pos.x;
        mouse_pos.y -= Obj_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle+90));


        //Tape
        Hitting();
        //if (isHitting)
        //{
        //    Debug.Log("je tape");
        //}
        
    }

    //Fonction dammage
    void TakeDamage (float damage)
    {
        Health -= damage;
    }

    //Fonction mort
    void Die()
    {
        //On détruit le perso  ? Retour vers un menu GameOver je suppose
    }

    //Faire la fonction qui reconnait les coups
    void OnTriggerEnter2D(Collider2D collided)
    {
        if (collided.tag == "Monster")
        {
            TakeDamage(collided.GetComponent<MonsterCaracteristics>().attack);
        }
    }

    //Fonction pour savoir s'il tape
    void Hitting()
    {
        if (Input.GetKey(KeyCode.Mouse0) && (Time.time - TimeAttack) > 0.2)
        {
            isHitting = true;
            anim1.SetBool("coup", true);
            TimeAttack = Time.time;
        }
        else
        {
            isHitting = false;
            anim1.SetBool("coup", false);
        }
        //if l'animation n'est pas acitivé alors isHittingUp = false
    }

    //void OnCollisionEnter2D(Collision2D coll)
    //{
    //    Vector3 pos = transform.position;
    //    if (coll.gameObject.tag == "obstacles")
    //    {
    //        transform.position = pos;
    //    }
    //}
}
