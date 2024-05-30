using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 16;
	public int currentHealth;
	public float invincibilityDuration = 2.0f;  // Duration of invincibility after being hit
    public float blinkDuration = 0.1f;  // How long each blink lasts
	private Renderer[] playerRenderers;
	public HealthCounter healthCounter;

	[SerializeField] private CapsuleCollider2D playerCollider; 

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthCounter.SetMaxHealth(maxHealth);
		
		playerRenderers = GetComponentsInChildren<Renderer>();
        if (playerRenderers == null || playerRenderers.Length == 0)
        {
            Debug.LogError("No Renderer components found on " + gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

	public void TakeDamage(int damage)
	{
		if (!IsInvincible()){

			currentHealth -= damage;

			if (currentHealth <= 0){
                currentHealth = 0;
				Die();
			} else {
				Physics2D.IgnoreLayerCollision(3, 8);
                Physics2D.IgnoreLayerCollision(9, 9);
				StartCoroutine(DoBlinks(invincibilityDuration, blinkDuration));
			}

			healthCounter.SetHealth(currentHealth, maxHealth);
		}
	}

    public void TakeHealth(int cure)
	{
		if (!IsInvincible()){
            if (currentHealth < maxHealth){
			    currentHealth += cure;
            }

			healthCounter.SetHealth(currentHealth, maxHealth);
		}
	}

	IEnumerator DoBlinks(float invincibilityTime, float blinkTime)
    {

        float endTime = Time.time + invincibilityTime;
        while (Time.time < endTime)
        {
            foreach (Renderer renderer in playerRenderers)
            {
                renderer.enabled = !renderer.enabled;
            }
            yield return new WaitForSeconds(blinkTime);
        }
        foreach (Renderer renderer in playerRenderers)
        {
            renderer.enabled = true;  // Ensure all renderers are enabled when done
        }
		Physics2D.IgnoreLayerCollision(3, 8, false);
        Physics2D.IgnoreLayerCollision(9, 9, false);
    }

    bool IsInvincible()
    {
        // Checks if any renderer is disabled, indicating invincibility
        return playerRenderers.Any(rend => !rend.enabled);
    }

    void Die()
    {
        Debug.Log("Player has died!");
    }
}
