using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCtrl : MonoBehaviour
{
    [SerializeField] private Transform gunTransform; // súng gắn ở trong inspector

    public void RotateTowards(Transform target) // xoay súng theo monster gần nhất được tìm thấy (target)
    {
        if(target == null) return; // nếu trong inspector không gán súng thì dừng, không làm gì cả

        Vector3 direction = target.position - gunTransform.position; // tính khoảng cách từ súng tới mục tiêu (monster gần nhất được tìm thấy)

        /*
         * Atan2 : dùng để tính góc giữa 2 đường thằng nối tiếp (x,y) và góc tọa độ (0,0) và trả về kết quả là góc được tính bằng radian
         * Góc có 2 đơn vị phổ biến :
         *      - Độ : (Degrees) một vòng tròn là 360 độ
         *      - Radian : một vòng tròn là 2pi radian (~6.28 radian)
         *  - công thức chuyển đổi từ radian sang độ : độ = radian * (180/pi)
         * Mathf.Rad2Deg : dùng để chuyển từ radian sang độ (Mathf.Rad2Deg = 180/pi)
         * Mathf.Deg2Rad : dùng để chuyển từ độ sang radian
        */
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gunTransform.rotation = Quaternion.Euler(0,0,angle); // xoay súng theo góc đã được tính
    }










































    //public GameObject gun;
    //public void RotateGun(Transform target)
    //{
    //    if(target == null) return;
    //    Vector3 direction = (gun.transform.position - target.position);
    //    float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
    //    gun.transform.rotation = Quaternion.Euler(0,0,angle);
    //}
}
