using System;
using UnityEngine;

public class MeleeHitbox : MonoBehaviour
{
    public int damage = 10;
    public GameObject attacker; 
    private bool canHit = false;

    private void Start()
    {
        canHit = true;
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (!canHit) return;

        Health h = other.GetComponent<Health>();
        if (h != null && other.gameObject != attacker)
        {
            Debug.Log("HIT: " + other.name); // Debug line
            h.TakeDamage(damage, attacker);
        }
    }
    */


    public void EnableHitbox()
    {
        canHit = true;
        Debug.Log("Hitbox Enabled");
    }

    public void DisableHitbox()
    {
        canHit = false;
    }
}