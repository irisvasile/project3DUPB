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

    private NavMeshAgent navMeshAgent;
    private Animator anim; //TODO animators
    private bool walking;

    private Transform targetedEnemy;
    private bool clickedEnemy;
    [HideInInspector]
    public Hero hero;

    private Vector3 lastPath;

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
        lastPath = navMeshAgent.destination;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            navMeshAgent.isStopped = true;
            return;
        }
        else
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.destination = lastPath;
        }

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
            if (hero.spells.Count > 0 && Physics.Raycast(ray, out hit, hero.spells[0].range)) //max distance = spell range
            {
                GetComponent<Hero>().CastSpell(0, hit.point);
                // dupa blink destinatia ramane setata si continua sa mearga spre ea
                // cineva ar trebui sa repare asta
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (hero.spells.Count > 1 && Physics.Raycast(ray, out hit, hero.spells[1].range)) //max distance = spell range
            {
                GetComponent<Hero>().CastSpell(1, hit.point);
                // dupa blink destinatia ramane setata si continua sa mearga spre ea
                // cineva ar trebui sa repare asta
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (hero.spells.Count > 2 && Physics.Raycast(ray, out hit, hero.spells[2].range)) //max distance = spell range
            {
                GetComponent<Hero>().CastSpell(2, hit.point);
                // dupa blink destinatia ramane setata si continua sa mearga spre ea
                // cineva ar trebui sa repare asta
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (hero.spells.Count > 3 && Physics.Raycast(ray, out hit, hero.spells[3].range)) //max distance = spell range
            {
                GetComponent<Hero>().CastSpell(3, hit.point);
                // dupa blink destinatia ramane setata si continua sa mearga spre ea
                // cineva ar trebui sa repare asta
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (hero.spells.Count > 4 && Physics.Raycast(ray, out hit, hero.spells[4].range)) //max distance = spell range
            {
                GetComponent<Hero>().CastSpell(4, hit.point);
                // dupa blink destinatia ramane setata si continua sa mearga spre ea
                // cineva ar trebui sa repare asta
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
