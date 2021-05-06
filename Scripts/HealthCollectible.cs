using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{

    public ParticleSystem HealthEffect;
    private ParticleSystem HealthCollisionEffect;

    public AudioClip collectedClip;


    private void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            if (controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                Destroy(gameObject);
                HealthCollisionEffect = Instantiate(HealthEffect, transform.position, Quaternion.identity) as ParticleSystem;
                HealthCollisionEffect.Play();

                controller.PlaySound(collectedClip);
            }

        }
    }
}
