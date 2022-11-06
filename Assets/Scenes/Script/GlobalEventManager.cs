using UnityEngine.Events;

public class GlobalEventManager
{
    public static UnityEvent PlayerDied = new UnityEvent();
    public static UnityEvent EnemyDied = new UnityEvent();
    public static UnityEvent PlayerShoot = new UnityEvent();
    public static UnityEvent Ricochet = new UnityEvent();
}
