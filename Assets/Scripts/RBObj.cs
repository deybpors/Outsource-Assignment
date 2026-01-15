using System.Collections.Generic;
using UnityEngine;

public class RBObj : MonoBehaviour
{
    private List<Rigidbody> bodies = new List<Rigidbody>();

    void Start()
    {
        bodies.AddRange(GetComponentsInChildren<Rigidbody>());
    }


}
