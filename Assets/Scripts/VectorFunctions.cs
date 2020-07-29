using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorFunctions
{
    public static Vector3 Elevate(Vector3 vector, Vector3 reference)
    {
        return new Vector3(vector.x, reference.y + 1, vector.z);
    }
}
