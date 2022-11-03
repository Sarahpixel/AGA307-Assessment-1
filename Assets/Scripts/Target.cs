using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public EnemyType myType;
    public int health;

    float moveDistance = 500;

    void Start()
    {
        Setup();
        
    }
    void Setup()
    {
        switch (myType)
        {
            case EnemyType.Target:
                health = 200;
                break;

            case EnemyType.NormalTarget:
                health = 100;
                break;
                 
            case EnemyType.BigTarget:
                health = 50;
                break;




        }
    }
    
       
   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Move());
        }
    }

    IEnumerator Move()
    {
        for(int i = 0; i < moveDistance; i++)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
            yield return null;
        }

        transform.Rotate(Vector3.up * 180);

        yield return new WaitForSeconds(3);

        StartCoroutine(Move());
    }
     void TakeDamage(int _damage)
    {
        health = _damage;

        if(health > 0)
        {
             Destroy(gameObject);
        }
              
    }
}
