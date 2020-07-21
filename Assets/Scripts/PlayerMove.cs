using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    [Header("Stats")]
    public float attackDistance;
    public float attackRate;
    private float nextAttack;

    private NavMeshAgent navMeshAgent;
    private Animator anim; //TODO animators
    private bool walking;

    private Transform targetedEnemy;
    private bool clickedEnemy;
    [HideInInspector]
    public Hero hero;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); //for animators
        navMeshAgent = GetComponent<NavMeshAgent>();
        hero = GetComponent<Hero>();
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //am modificat putin ca sa pun blink
        if (Input.GetButtonDown("Fire1")) //left click
        {
            if (Physics.Raycast(ray, out hit, 1000)) //max distance = 1000
            {
                if (hit.collider.tag == "Enemy")
                {
                    targetedEnemy = hit.transform;
                    clickedEnemy = true;
                    print("I WANNA TARGET THE ENEMY!");
                    GetComponent<Hero>().Attack(hit.point);
                }
                else
                {
                    walking = true;
                    clickedEnemy = false;
                    navMeshAgent.isStopped = false;
                    navMeshAgent.destination = hit.point;
                }
            }
        }
        else
        if (Input.GetButtonDown("Fire2")) //right click
        {
            if (Physics.Raycast(ray, out hit, hero.spells[0].range)) //max distance = spell range
            {
                GetComponent<Hero>().CastSpell(0, hit.point);
                // dupa blink destinatia ramane setata si continua sa mearga spre ea
            }
        }

        if (clickedEnemy)
        {
            MoveAndAttack();
        }

        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            walking = false;
        }
        else
        {
            walking = true;
        }

       // anim.SetBool("isWalking", walking); //TODO animators
    }
    void MoveAndAttack()
    {
        if (targetedEnemy == null)
        {
            return;
        }

        navMeshAgent.destination = targetedEnemy.position;

        if (navMeshAgent.remainingDistance > attackDistance)
        {
            navMeshAgent.isStopped = false;
            walking = true;
        }
        else
        {
            transform.LookAt(targetedEnemy);
            Vector3 dirToAttack = targetedEnemy.transform.position - transform.position;

            if(Time.time > nextAttack)
            {
                nextAttack = Time.time + attackRate;
            }
            navMeshAgent.isStopped = true;
            walking = false;
        }
    }
}
