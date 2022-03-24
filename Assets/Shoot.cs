using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;
    public float projectileSpeed = 20f;
    public Transform shootPos;
    public bool automatic = false;
    public bool allowfire;
    public float rateOfFire = 0.03f;
    public int bulletsShot = 0;

    Vector3 destination;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (automatic) {
            if (Input.GetButton("Fire1") && allowfire)
            {
                StartCoroutine(ShootProjectile());
            }
        } else {
            if (Input.GetButtonDown("Fire1") && allowfire)
            {
                StartCoroutine(ShootProjectile());
            }
        }
        
    }

    IEnumerator ShootProjectile() {
        allowfire = false;
        bulletsShot++;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
            destination = hit.point;
        else destination = ray.GetPoint(1000);


        var projectileObject = Instantiate(projectile, shootPos.position, Quaternion.identity);
        projectileObject.GetComponent<Rigidbody>().velocity = (destination - shootPos.position).normalized * projectileSpeed;
        yield return new WaitForSeconds(rateOfFire/100);
        allowfire = true;
    }
}
