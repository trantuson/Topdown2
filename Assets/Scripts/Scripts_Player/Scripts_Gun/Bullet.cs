using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // tốc độ

    public Transform target; // mục tiêu của đạn

    public int dame;

    public void SetTarget (Transform newTarget, int playerDamege) 
    {
        target = newTarget; // gán mục tiêu mới
        dame = playerDamege;
    }
    private void Update()
    {
        BulletMoveToTarget();
    }
    protected void BulletMoveToTarget()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
            
        // di chuyển tới mục tiêu
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            HeathManager heathManager = collision.GetComponent<HeathManager>();
            if (heathManager != null)
            {
                heathManager.TakeDame(dame);                    
            }
            Destroy(gameObject);
        }
    }








































    //public float speedd = 5f;
    //public Transform targett;
    //public void SetGEt(Transform newtarget)
    //{
    //    targett = newtarget;
    //}
    //public void bulletMoveToTarget()
    //{
    //    if (targett == null) return;

    //    Vector3 direction = (targett.position - transform.position).normalized;
    //    transform.position += direction * speedd * Time.deltaTime;
    //}
}
