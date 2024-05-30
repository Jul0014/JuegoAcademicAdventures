using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    public Animator weaponAnimator;
    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement script not found in parent.");
        }
    }

    void Update()
    {
        if (playerMovement != null)
        {
            UpdateWeaponAnimation();
        }
    }

    private void UpdateWeaponAnimation()
    {
        bool isJumping = playerMovement.IsJumping;
        bool isGrounded = playerMovement.IsGrounded;
        
        weaponAnimator.SetBool("IsGrounded", isGrounded);

        if (Input.GetButtonDown("Horizontal"))
		{
			weaponAnimator.SetTrigger("Move");
		}
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            weaponAnimator.SetTrigger("Fall");
        }
        if (Input.GetButtonDown("Jump"))
        {
            weaponAnimator.SetTrigger("Jump");
        }
    }

    public void ResetTrigger(string triggerName)
    {
        weaponAnimator.ResetTrigger(triggerName);
    }
}
