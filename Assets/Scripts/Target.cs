using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : GameBehaviour
{
    public static event Action<GameObject> OnEnemyHit = null;
    public static event Action<GameObject> OnEnemyDie = null;

    public EnemyType myType;
    public float mySpeed = 2f;
    public float myHealth = 100f;
    public int health;

    float moveDistance = 600;

    void Start()
    {
        Setup();
        
    }
    void Setup()
    {
        switch (myType)
        {
            case EnemyType.Small:
                health = 200;
                break;

            case EnemyType. Medium:
                health = 100;
                break;
                 
            case EnemyType.Large:
                health = 50;
                break;

        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Move());
        }
        if (Input.GetKeyDown(KeyCode.H))
            Hit(10);
    }

    void Hit(int _damage)
    {
        myHealth -= _damage;
        GameManager.instance.AddScore(10);

        if (myHealth <= 0)
            Die();
    }
    void Die()
    {
        _GM.AddScore(100);
        _EM.KillEnemy(gameObject);
        StopAllCoroutines();
        Destroy(gameObject);
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
