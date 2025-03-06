using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    // Tìm kiếm kẻ địch gần nhất trong bán kính (detectionRadius) quanh một đối tượng (player)
    public Transform FindNearestMonster(Transform player, float detectionRadius)
    {
        /* Tạo danh sách các collider trong bán kính phát hiện
         * - Physics2D.OverlapCircleAll : được dùng để phát hiện tất cả các collider2D nằm trong 1 hình tròn và trả về một mảng các collider2D
         * + tâm là player.position
         * + bán kính là detectionRadius
        */
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(player.position, detectionRadius);
        
        Transform nearestMonster = null; // biến để lưu kẻ địch gần nhất. mặc định là null vì chưa có kẻ địch nào được tìm thấy

        float minDistance = Mathf.Infinity; // biến để lưu khoảng cách nhỏ nhất tìm được. ban đầu là vô cực để dảm bảo mọi khoảng cách đều nhỏ hơn

        foreach (var collider2D in collider2Ds) // duyệt qua lần lượt từng collider2D được phát hiện trong collider2Ds
        {
            if (collider2D.CompareTag("Enemy")) // nếu như collider2D đó có tag là Enemy
            {
                float distance = Vector3.Distance(player.position, collider2D.transform.position); // tính khoảng cách từ tâm (player) đến collider2D đó
                if(distance < minDistance) // nếu khoảng cách tính được ở trên nhỏ hơn minDistance
                {
                    minDistance = distance; // gán minDistance = khoảng cách đó
                    nearestMonster = collider2D.transform; // và cập nhật nearestMonster là collider2D đó.
                }
            }
        }
        return nearestMonster; // trả về nearestMonster (là kẻ địch gần nhất được tìm thấy)
    }







































    
    //public Transform NearestEnemy(Transform player, float detectionRadius)
    //{
    //    Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(player.position, detectionRadius);
    //    Transform nearestEnemy = null;
    //    float minDistance = Mathf.Infinity;

    //    foreach(var collider2D in collider2Ds)
    //    {
    //        if (collider2D.CompareTag("Enemy"))
    //        {
    //            float distance = Vector3.Distance(player.position, collider2D.transform.position);
    //            if (distance < minDistance)
    //            {
    //                minDistance = distance;
    //                nearestEnemy = collider2D.transform;
    //            }
    //        }
    //    }
    //    return nearestEnemy;
    //}
}
