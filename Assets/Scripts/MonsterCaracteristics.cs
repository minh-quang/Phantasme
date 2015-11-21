using UnityEngine;
using System.Collections;

public class MonsterCaracteristics : MonoBehaviour {

    public int life = 2;
    public int maxLife = 2;
    public int attack = 1;
    public float range = 0.1f;
    public float cooldown = 1f;
    public float growth = 0;
    public GameObject target;

    protected Animator animator;
    protected BoxCollider2D selfCollider;
    protected CircleCollider2D attackingCollider;
    protected float timeSinceLastAttack = 0;
	// Use this for initialization
	void Start () {
	    
	}

    void OnEnable()
    {
        life = maxLife;
        target = GameObject.FindGameObjectWithTag("Player");
        GetComponent<AIMouvement>().target = target.transform;
        animator = GetComponent<Animator>();
        selfCollider = GetComponent<BoxCollider2D>();
    }
	
    public void Attack()
    {
        if(timeSinceLastAttack > cooldown)
        {
            animator.SetBool("IsAttacking", true);
            timeSinceLastAttack = 0f;
        }
    }

	// Update is called once per frame
	void Update () {
        //Debug.Log(timeSinceLastAttack);
        timeSinceLastAttack += Time.deltaTime;
    }
}
