using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWallBehaviour : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "enemy(Clone)")
        {
            other.GetComponent<EnemyBehaviour>().Attack();
        }
        if (other.gameObject.name == "juggernaut(Clone)")
        {
            other.GetComponent<JuggernautBehaviour>().Attack();
        }
        if (other.gameObject.name == "splitter(Clone)")
        {
            other.GetComponent<SplitterBehaviour>().Attack();
        }
    }
}
