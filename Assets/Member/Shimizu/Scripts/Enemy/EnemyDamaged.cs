using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamaged : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerAtack"))
        {
            transform.GetComponentInParent<Enemy>().EnmeyDamaged();
        }
    }
}
