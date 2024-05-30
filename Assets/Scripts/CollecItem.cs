using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollecItem : MonoBehaviour
{
    public float boostNumber = 1f;
    public float boostDuration = 0f; // Speed boost lasts for 10 seconds
    public int type = 0;
	public GameObject burstParticles;

	private SpriteRenderer _rederer;
	private Collider2D _collider;
    private BoxCollider2D _boxCollider;

    public float lifeTime = 5f;  // Total time before the item is destroyed
    public float blinkStart = 1f;  // When to start to fade

	private void Awake()
	{
		_rederer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        StartCoroutine(DestroyAfterTime(lifeTime));
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            // Call relevant methods based on item type
            if (type == 0) {
                Debug.Log("Aumentar vida");
                collision.SendMessageUpwards("TakeHealth", boostNumber);
            } else if (type == 1) {
                Debug.Log("Añadir a gemas");
                collision.SendMessageUpwards("AddGem", boostNumber);
            } else if (type == 2) {
                Debug.Log("Aumentar velocidad");
                SpeedBoostData data = new SpeedBoostData(boostNumber, boostDuration);
                collision.SendMessageUpwards("CoffeeTime", data);
            }

            // Ensure renderer is visible and stop any fading
            StopAllCoroutines();
            _rederer.color = new Color(_rederer.color.r, _rederer.color.g, _rederer.color.b, 1);

            // Visual effects
            _rederer.enabled = false;
            burstParticles.SetActive(true);

            // Disable collider
            _collider.enabled = false;
            _boxCollider.enabled = false;

            // Destroy after some time
            Destroy(gameObject, 1f);
        }
    }

    private IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time - blinkStart);

        // Start fading out
        StartCoroutine(FadeOut());
        
        // Wait for the remaining time before destroying the object
        yield return new WaitForSeconds(blinkStart);
        
        Destroy(gameObject);
    }

    private IEnumerator FadeOut()
    {
        float startTime = Time.time;
        float duration = blinkStart;  // Set the duration of the fade
        float elapsed = 0;

        while (elapsed < duration)
        {
            elapsed = Time.time - startTime;
            float percentComplete = elapsed / duration;

            // Change alpha based on how much time has elapsed
            Color currentColor = _rederer.color;
            currentColor.a = 1f - percentComplete;  // Linearly interpolate alpha
            _rederer.color = currentColor;

            yield return null;  // Wait until the next frame
        }

        _rederer.color = new Color(_rederer.color.r, _rederer.color.g, _rederer.color.b, 0);  // Ensure it's fully transparent at the end
    }
}
