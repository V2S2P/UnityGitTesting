using UnityEngine;
using UnityEngine.UIElements;

public class PlayerBehaviour : MonoBehaviour
{
    Animator playerAnimator;
    [SerializeField] private Collider weaponCollider;
    [SerializeField] private Collider[] unarmedColliders;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        DisableWeaponCollider();
        DisableUnarmedColliders();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            {
            playerAnimator.SetBool("isPraying", true);
            }
        if (Input.GetKeyUp(KeyCode.P))
            {
            playerAnimator.SetBool("isPraying", false);
            }
        if (Input.GetMouseButtonDown(0))
            {
            playerAnimator.SetTrigger("Punch");
            }
        if (Input.GetMouseButtonDown(1))
        {
            playerAnimator.SetTrigger("ElbowPunch");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerAnimator.SetTrigger("RunningJump");
            }
            else
            {
                playerAnimator.SetTrigger("StandingJump");
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
            {
            playerAnimator.SetBool("Running", true);
            }
        if (Input.GetKeyUp(KeyCode.LeftShift))
            {
            playerAnimator.SetBool("Running", false);
            }
        if (Input.GetKeyDown(KeyCode.W))
            {
            playerAnimator.SetBool("isWalking", true);
            }
        if (Input.GetKeyUp(KeyCode.W))
            {
            playerAnimator.SetBool("isWalking", false);
            }

        if (Input.GetKeyDown(KeyCode.E))
        {
            playerAnimator.SetTrigger("leftSword");
        }
    }

    public void EnableUnarmedColliders()
    {
        foreach (Collider col in unarmedColliders)
            col.enabled = true;
    }

    public void DisableUnarmedColliders()
    {
        foreach (Collider col in unarmedColliders)
            col.enabled = false;
    }

    public void EnableWeaponCollider()
    {
        weaponCollider.enabled = true;
    }

    public void DisableWeaponCollider()
    {
        weaponCollider.enabled = false;
    }
}