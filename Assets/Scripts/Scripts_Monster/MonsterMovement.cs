using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 1f;

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        MoveToPlayer();
    }
    protected void MoveToPlayer()
    {
        if (player == null) return;
        
        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}
