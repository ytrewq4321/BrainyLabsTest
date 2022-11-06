using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected float shootRate;
    protected float nextTimeShoot = 0f;

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<SpriteRenderer>().color = gameObject.GetComponent<SpriteRenderer>().color;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }
}
