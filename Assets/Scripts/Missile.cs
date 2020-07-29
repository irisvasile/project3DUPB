using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public ManaUser user;
    public ParticleSystem impactType;
    public float damage, radius, speed;
    public Buff effect;
    public bool targetsEnemies;
    public Vector3 startingPosition;
    public Vector3 targetPosition;
    private bool summoned = false;

    public static Missile Summon(string missileName, ParticleSystem impactType, SpellMissile spell, ManaUser user, Vector3 pos)
    {
        Debug.Log(missileName);
        Missile m = Instantiate(Resources.Load< Missile>("Prefabs/Missiles/" + missileName)) as Missile;
        m.user = user;
        m.impactType = impactType;
        m.damage = spell.damage;
        m.radius = spell.radius;
        m.speed = spell.speed;
        m.effect = spell.effect;
        m.impactType = spell.impactType;
        m.targetsEnemies = spell.targetsEnemies;
        m.startingPosition = m.transform.position = VectorFunctions.Elevate(m.user.transform.position, m.user.transform.position);
        m.targetPosition = VectorFunctions.Elevate(pos, m.user.transform.position);
        Vector3 shootDirection = m.targetPosition - m.startingPosition;
        m.GetComponent<Rigidbody>().velocity = new Vector3(shootDirection.x * m.speed, 0, shootDirection.z * m.speed);
        m.summoned = true;
        return m;
    }

    private void FixedUpdate()
    {
        if (!summoned)
            return;
        if (Vector3.Distance(transform.position, targetPosition) <= 1)
            Explode();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!summoned)
            return;
        Unit hitUnit = other.GetComponent<Unit>();
        Debug.LogWarning(other);
        if (hitUnit == null && other.GetComponent<Missile>() == null)
            Explode();
        else if (user.CanTarget(hitUnit, targetsEnemies, false))
        {
            Explode();
        }
    }

    private void Explode()
    {
        Debug.Log("expl");
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        ShowImpact(transform.position);
        for (int i = 0; i < hitColliders.Length; ++i)
        {
            Unit u = hitColliders[i].GetComponent<Unit>();
            if (u != null && user.CanTarget(u, targetsEnemies, false))
            {
                u.ApplyBuff(effect, user);
            }
        }
        Destroy(gameObject);
    }


    public void ShowImpact(Vector3 pos)
    {
        if (impactType != null)
        {
            ParticleSystem impact = GameObject.Instantiate(impactType) as ParticleSystem;
            //ShapeModule sm = impact.shape;
            //sm.radius = radius;
            impact.transform.localScale *= radius;
            impact.transform.position = pos;
        }
    }
}
