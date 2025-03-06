using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    private PlayerStats playerStats;

    [SerializeField] private GameObject bulletPrefabs; // đạn gắn trong inspector
    private GameObject bullet; // biến lưu đạn spawn
    [SerializeField] private Transform firePoint; // điểm spawn ra đạn gắn trong inspector

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }
    public void SpawnBullet(Transform target)
    {
        if (bulletPrefabs == null) return; // nếu đạn không được gắn trong inspector thì dừng, không làm gì

        // spawn ra đạn ở vị trí được gán 
        bullet = Instantiate(bulletPrefabs, firePoint.position, Quaternion.identity);

        // những viên đạn được spawn sẽ được gán script Bullet
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if(bulletScript != null )
        {
            bulletScript.SetTarget(target, playerStats.dame); // gọi hàm SetTarget (Transform target) ở bên script Bullet. để đạn bay tới monster gần nhất
        }
    }










































    //public GameObject bullett;
    //public GameObject bulletInsta;
    //public Transform point;
    //public void Spawner(Transform target)
    //{
    //    if(target == null) return;
    //    bulletInsta = Instantiate(bullett, point.position, Quaternion.identity);
    //    Bullet bulletScript = bulletInsta.GetComponent<Bullet>();
    //    if(bulletScript != null )
    //    {
    //        bulletScript.SetTarget(target);
    //    }
    //}
}
