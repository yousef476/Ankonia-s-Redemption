using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public Transform raycast;
    public LayerMask raycastMask;
    public float raycastLength;
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    
    private RaycastHit2D hit;
    private GameObject target;
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float inTimer;
    

    void Awake() {
        inTimer = timer;
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
       if (inRange){
           hit = Physics2D.Raycast(raycast.position, Vector2.left, raycastLength, raycastMask);
           RaycastDebugger();
       }

       if (hit.collider != null)
       {
           EnemyLogic();
       }
       else if (hit.collider == null)
       {
           inRange = false;
       }

       if (inRange == false)
       {
           anim.SetBool("Walk", false);
           StopAttack();
       }
    }

    void OnTriggerEnter2D(Collider trig) {
        if(trig.gameObject.tag == "Player"){
            target = trig.gameObject;
            inRange = true;
        }
    }

    void EnemyLogic(){
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }

        if (cooling)
        {
            cooldown();
            anim.SetBool("Attack", false);
        }
    }

    void Move(){
        anim.SetBool("Walk", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Guard_attack"))
        {
            Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack(){
        timer = inTimer;
        attackMode = true;

        anim.SetBool("Walk", false);
        anim.SetBool("Attack", true);
    }

    void cooldown(){
        timer -= Time.deltaTime;

        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = inTimer;
        }
    }

    void StopAttack(){
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
    }

    void RaycastDebugger(){
        if (distance > attackDistance)
        {
            Debug.DrawRay(raycast.position, Vector2.left * raycastLength, Color.red);
        }
        else if (attackDistance > distance){
            Debug.DrawRay(raycast.position, Vector2.left * raycastLength, Color.green);
        }
    }

    public void TrriggerCooling(){
        cooling = true;
    }
    
    }
