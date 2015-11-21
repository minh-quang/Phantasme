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

    Animator[] anim;
    Animator anim1;
    Animator anim2;
    

    //Variable ori pour savoir dans quel sens on est et ainsi se déplacer correctement
    // -1 = left, 0 = down, 1 = right, 2 = up;
    private int ori;

    // Use this for initialization
    void Start () {
        Health = MaxHealth;
        position = this.transform.position;
        ori = 0;
<<<<<<< HEAD
        dimension = GameObject.FindGameObjectWithTag("MapManager").GetComponent<MapManager>().dimension;
        taille = GameObject.FindGameObjectWithTag("MapManager").GetComponent<MapManager>().taille;
    }
=======

        anim = GetComponentsInChildren<Animator>();
        anim1 = anim[0];
        anim2 = anim[1];
    } 
>>>>>>> refs/remotes/origin/Player
	
	// Update is called once per frame
	void Update () {
        //Mort
	    if (Health <= 0)
        {
            Die();
        }

        //Mouvement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        anim1.SetFloat("speed", horizontal + vertical);
        anim2.SetFloat("speed", horizontal + vertical);
        if (ori == 0)
        {
            Move(horizontal, vertical);
        }
        if (ori == 2)
        {
            Move(-horizontal, -vertical);
        }
        if (ori == 1)
        {
            Move(vertical, -horizontal);
        }
        if (ori == -1)
        {
            Move(-vertical, horizontal);
        }

        //Orientation
        float horizontalO = Input.GetAxis("HorizontalO");
        float verticalO = Input.GetAxis("VerticalO");
        Orientation(horizontalO, verticalO);
        
        //Tape
        Hitting();
        if (isHitting)
        {
            Debug.Log("je tape");
        }
        
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

    //Faire une fonction deplacement
    void Move(float h, float v)
    {
        float Speed = MaxSpeed * Time.deltaTime;
        this.transform.Translate(new Vector2(Speed * h, Speed * v));
<<<<<<< HEAD
        //Debug.Log(transform.position.ToString());
=======
        
>>>>>>> refs/remotes/origin/Player
    }

    //Faire la fonction qui reconnait les coups
    void OnTriggerEnter2D (Collider2D collided)
    {
        if (collided.name == "je sais pas encore")
        {
            //TakeDamage(Damage lié à l'arme);
        }
    }

    //Fonction d'orientation
    void Rotation(float x1, float x2, float x3)
    {
        transform.eulerAngles = new Vector3(x1, x2, x3);
    }

    void OrientationMouv()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Rotation(0, 0, 180);
            ori = 2;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            Rotation(0, 0, -90);
            ori = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Rotation(0, 0, 90);
            ori = 1;
        }
        else
        {
            Rotation(0, 0, 0);
            ori = 0;
        }
    }

    void Orientation (float horizontal, float vertical)
    {
        if (vertical > 0)
        {
            Rotation(0, 0, 180);
            ori = 2;
        }
        else if (vertical < 0)
        {
            Rotation(0, 0, 0);
            ori = 0;
        }
        else if (horizontal < 0)
        {
            Rotation(0, 0, -90);
            ori = -1;
        }
        else if (horizontal > 0)
        {
            Rotation(0, 0, 90);
            ori = 1;
        }
        else { OrientationMouv(); }
    }

    //Fonction pour savoir s'il tape
    void Hitting()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            isHitting = true;
            //lancé l'animation coup en bas
        }
        else { isHitting = false; }
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
