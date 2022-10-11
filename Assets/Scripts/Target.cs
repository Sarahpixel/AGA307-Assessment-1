using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int health;

    public void TakeDamage(int _damage)
    {
        health = _damage;

        if(health > 0)
        {
             Destroy(gameObject);
        }
              
    }
}
