using System;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
