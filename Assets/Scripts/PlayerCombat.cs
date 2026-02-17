using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public MeleeHitbox leftHandHitbox;
    public Animator animator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) // left click
        {
            animator.SetTrigger("Punch");
            StartCoroutine(PunchCoroutine());
        }
    }

    private System.Collections.IEnumerator PunchCoroutine()
    {
        leftHandHitbox.EnableHitbox();
        yield return new WaitForSeconds(1f); // punch duration
        leftHandHitbox.DisableHitbox();
    }
}