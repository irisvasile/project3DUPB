using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapscript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    void LateUpdate () {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        //if we want to rotate with player;
        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
