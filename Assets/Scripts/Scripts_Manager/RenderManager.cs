using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderManager : MonoBehaviour
{
    public int dame;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && gameObject.CompareTag("Enemy"))
        {
            HeathManager healthmanager = collision.GetComponent<HeathManager>();
            if(healthmanager != null)
            {
                healthmanager.TakeDame(dame);
            }
        }
        else if (collision.CompareTag("Enemy") && gameObject.CompareTag("Player"))
        {
            HeathManager healthmanager = collision.GetComponent<HeathManager>();
            if (healthmanager != null)
            {
                healthmanager.TakeDame(dame);
            }
        }
    }
}
