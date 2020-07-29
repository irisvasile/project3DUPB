using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Unit source;
    public GameObject impactType;
    public float damage, range;
    public Spell effect;
    private Vector3 startingPosition;

    private void Start()
    {
        startingPosition = source.transform.position;
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(startingPosition, transform.transform.position) > range)
            Explode();
    }

    private void OnTriggerEnter(Collider other)
    {
        Unit hitUnit = other.GetComponent<Unit>();
        if (hitUnit == null && other.GetComponent<Missile>() == null)
            Explode();
        else if (hitUnit != source)
        {
            hitUnit.TakeDamage(damage);
            if (effect != null)
            {
                //effect.caster = source;
                //effect.target = hitUnit;
                //effect.Execute();
            }
            Explode();
        }
    }

    private void Explode()
    {
        if (impactType != null)
        {
            GameObject impact = GameObject.Instantiate(impactType) as GameObject;
            impact.transform.position = transform.position;
        }
        Destroy(gameObject);
    }
}
