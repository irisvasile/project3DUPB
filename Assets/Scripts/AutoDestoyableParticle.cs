using UnityEngine;
using System.Collections;
public class AutoDestoyableParticle : MonoBehaviour
{

    public IEnumerator Start()
    {
        yield return new WaitForSeconds(GetComponent<ParticleSystem>().duration);
        Destroy(gameObject);
    }
}