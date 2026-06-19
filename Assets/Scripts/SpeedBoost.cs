using UnityEngine;
using System.Collections;

public class SpeedBoost : MonoBehaviour
{
    public float boostMultiplier = 2f;
    public float boostDuration = 3f;
    public AudioClip boostSFX;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (boostSFX != null)
            {
                AudioSource.PlayClipAtPoint(boostSFX, Camera.main.transform.position);
            }

            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.StartCoroutine(ActivateBoost(player));
            }

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;

            Destroy(gameObject, boostDuration + 0.1f);
        }
    }

    IEnumerator ActivateBoost(PlayerController player)
    {
        float originalSpeed = player.normalSpeed;

        player.normalSpeed *= boostMultiplier;

        yield return new WaitForSeconds(boostDuration);

        player.normalSpeed = originalSpeed;
    }
}