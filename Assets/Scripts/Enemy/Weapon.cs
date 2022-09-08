using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    
    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        // Logika untuk shooting
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
