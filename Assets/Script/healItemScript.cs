using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healItemScript : MonoBehaviour
{
    public int heal;

    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        Destroy(transform.parent.gameObject);
    }

}
