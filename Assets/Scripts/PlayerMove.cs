using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    [Header("Stats")]
    public float attackDistance;
    public float attackRate;
    private float nextAttack;

    public NavMeshAgent navMeshAgent;
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

        //am implementat hold position pe left shift
        if (Input.GetKey(KeyCode.LeftShift))
        {
            navMeshAgent.isStopped = true;
            navMeshAgent.destination = transform.position;
        }
        else
        {
            navMeshAgent.isStopped = false;
        }

        if (Input.GetButton("Fire1") || Input.GetButtonDown("Fire1")) //left click
        {
            if (Physics.Raycast(ray, out hit, 1000)) //max distance = 1000
            {
                if (Input.GetButtonDown("Fire1") && hit.collider.tag == "Enemy" && (!navMeshAgent.isStopped || Vector3.Distance(transform.position, hit.transform.position) <= attackDistance))
                {
                    targetedEnemy = hit.transform;
                    clickedEnemy = true;
                    print("I WANNA TARGET THE ENEMY!");
                    if (Vector3.Distance(transform.position, hit.transform.position) <= attackDistance)
                        GetComponent<Hero>().Attack(targetedEnemy.transform.position);
                }
                else if (!navMeshAgent.isStopped)
                {
                    walking = true;
                    clickedEnemy = false;
                    navMeshAgent.isStopped = false;
                    navMeshAgent.destination = hit.point;
                }
            }
        }
        else
        if (Input.GetButton("Fire2") || Input.GetButtonDown("Fire2")) //right click
        {
            if (hero.spells[0] != null && Physics.Raycast(ray, out hit, hero.spells[0].range)) //max distance = spell range
            {
                GetComponent<Hero>().CastSpell(0, hit.point);
                navMeshAgent.destination = transform.position;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (hero.spells[1] != null && Physics.Raycast(ray, out hit, hero.spells[1].range)) //max distance = spell range
            {
                GetComponent<Hero>().CastSpell(1, hit.point);
                navMeshAgent.destination = transform.position;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (hero.spells[2] != null && Physics.Raycast(ray, out hit, hero.spells[2].range)) //max distance = spell range
            {
                GetComponent<Hero>().CastSpell(2, hit.point);
                navMeshAgent.destination = transform.position;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (hero.spells[3] != null && Physics.Raycast(ray, out hit, hero.spells[3].range)) //max distance = spell range
            {
                GetComponent<Hero>().CastSpell(3, hit.point);
                navMeshAgent.destination = transform.position;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (hero.spells[4] != null && Physics.Raycast(ray, out hit, hero.spells[4].range)) //max distance = spell range
            {
                GetComponent<Hero>().CastSpell(4, hit.point);
                navMeshAgent.destination = transform.position;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (hero.spells[5] != null && Physics.Raycast(ray, out hit, hero.spells[5].range)) //max distance = spell range
            {
                GetComponent<Hero>().CastSpell(5, hit.point);
                navMeshAgent.destination = transform.position;
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
