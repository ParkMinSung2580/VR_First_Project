using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyExample : MonoBehaviour
{ 
    void OnCollisionEnter(Collision collider)
    {
        Debug.Log(collider.gameObject.name);
    }
}
