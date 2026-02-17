using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health; 

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log($"{gameObject.name} hit enemy for {damage}");
    }
}