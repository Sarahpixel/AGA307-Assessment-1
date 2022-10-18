using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPad : MonoBehaviour
{
    [SerializeField] private Renderer myObject;

    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Player"))
        {
           myObject.material.color = Color.green;
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (CompareTag("Player"))
        {
            myObject.material.color = Color.blue;
        }
    }
}

