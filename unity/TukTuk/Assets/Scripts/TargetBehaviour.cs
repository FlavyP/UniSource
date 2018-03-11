using UnityEngine;
using System.Collections;

public class TargetBehaviour
    : MonoBehaviour
{
    //When the gameObject gets picked up, make it invisible
    void OnTriggerEnter(Collider col)
    {
        gameObject.SetActive(false);
        Invoke("show", 5);
    }

    void show()
    {
        gameObject.SetActive(true);
    }
}

