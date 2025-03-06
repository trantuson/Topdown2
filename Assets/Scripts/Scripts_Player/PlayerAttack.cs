using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    TargetManager targetManager;
    GunCtrl gunCtrl;
    BulletSpawner bulletSpawner;

    [SerializeField] private float detectionRadius = 5f;
    [SerializeField] private Transform nearestMonster;

    public float fireRate = 0.5f;        // Tần suất bắn (số lần bắn mỗi giây)

    public float nextFireTime;        // Thời gian tiếp theo có thể bắn

    private void Start()
    {
        targetManager = GetComponent<TargetManager>();
        gunCtrl = GetComponent<GunCtrl>();
        bulletSpawner = GetComponent<BulletSpawner>();
    }
    private void Update()
    {
        Attack();
    }
    protected void Attack()
    {
        nearestMonster = targetManager.FindNearestMonster(transform, detectionRadius);
        if (nearestMonster != null)
        {
            // Xoay súng về phía enemy gần nhất
            gunCtrl.RotateTowards(nearestMonster);

            // Kiểm tra thời gian và bắn
            if (Time.time >= nextFireTime)
            {
                bulletSpawner.SpawnBullet(nearestMonster);
                nextFireTime = Time.time + fireRate;
            }
        }
        else
        {
            Debug.Log("No enemy found within radius.");
        }
    }
}
