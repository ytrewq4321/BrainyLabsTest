using UnityEngine;

public class PlayerShooting : Shooting
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Time.time >= nextTimeShoot)
            {
                Shoot();
                nextTimeShoot = Time.time + 1f / shootRate;
                GlobalEventManager.PlayerShoot.Invoke();
            }
        }
    }
}
