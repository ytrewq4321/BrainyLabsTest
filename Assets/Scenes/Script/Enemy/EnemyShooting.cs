using UnityEngine;

public class EnemyShooting : Shooting
{
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.up);
        if (hit.collider.gameObject.CompareTag("Player"))
        {
            if(Time.time>=nextTimeShoot)
            {
                Shoot();
                nextTimeShoot = Time.time + 1f / shootRate;
            }
        }
    }
}
