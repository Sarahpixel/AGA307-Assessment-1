using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : MonoBehaviour
{
    [Header("References")]
    public GameObject projectilePrefab;
    public GameObject hitSparks;
    public LineRenderer laser;
    public float projectileSpeed = 1000;
    public Transform firingPoint;
    public Camera cam;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1")) 
        {
            FireRigidProjectile();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            FireRaycast();
        }


    }

    void FireRigidProjectile()
    {
            //Create a reference to hold our instantiated object
            GameObject projectileInstance;
            //Instantiate our projectile prefab at the firing positon and rotation
            projectileInstance=Instantiate(projectilePrefab,firingPoint.position,firingPoint.rotation);
            //Get the rigidbody component of the projectile and add force to 'fire' it
            projectileInstance.GetComponent<Rigidbody>().AddForce(firingPoint.forward * projectileSpeed);
            //Destroy our projectile after 5 sec
            Destroy(projectileInstance, 2);

    }
    void FireRaycast()
    {
        Ray ray = new Ray(transform.position,transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit,Mathf.Infinity))
        {
            Debug.Log("We hit"+hit.collider.name+ "at point " + hit.point+ "which was" + hit.distance+ "units away");
            laser.SetPosition(0, transform.position);
            laser.SetPosition(1,hit.point);
            StopAllCoroutines();
            StartCoroutine(StopLaser());
            GameObject party = Instantiate(hitSparks, hit.point, hit.transform.rotation);
            Destroy(party,2);
            if (hit.collider.CompareTag("Target"))
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }

    IEnumerator StopLaser()
    {
        laser.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        laser.gameObject.SetActive(false);
    }

}
