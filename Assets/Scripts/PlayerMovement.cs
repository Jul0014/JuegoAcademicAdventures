using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

    public Animator animator;

	public float runSpeed = 40f;
	public float originalSpeed;

	private bool _isCoffeeTime = false;

	float horizontalMove = 0f;
	bool jump = false;
	bool fall = false;

	public float HorizontalMove => horizontalMove;
    public bool IsJumping => jump;
    public bool IsFalling => fall;

	private bool isGrounded = true;

	public bool IsGrounded => isGrounded;
	
	private void Start() {
        originalSpeed = runSpeed; // Store the original speed at start.
    }

	public bool IsCoffeeTime {
        get => _isCoffeeTime;
        private set => _isCoffeeTime = value;
    }
	// Update is called once per frame
	void Update () {
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
		//attack onside

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
            animator.SetBool("IsJumping", true);
			//attack upwards
		}

		if (Input.GetButtonDown("Fall"))
		{
			fall = true;
			animator.SetBool("IsFalling", true);
			//attack downwards
		}
		Debug.Log(runSpeed + " " + originalSpeed);

	}

	public void AddSpeed(float speed){
		runSpeed *= speed;
	}

	public void ResetSpeed() {
        runSpeed = originalSpeed; // Reset to original speed.
    }

	public void CoffeeTime(SpeedBoostData data) {
        if (!IsCoffeeTime) {
            IsCoffeeTime = true;
            StartCoroutine(SpeedBoost(data.BoostFactor, data.Duration));
        }
    }

	private IEnumerator SpeedBoost(float speedFactor, float duration) {
        AddSpeed(speedFactor);
        yield return new WaitForSeconds(duration);
        ResetSpeed();
        IsCoffeeTime = false;
    }


    public void OnLanding ()
	{
		animator.SetBool("IsJumping", false);
		animator.SetBool("IsFalling", false);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump, fall);
		jump = false;
		fall = false;
	}
}