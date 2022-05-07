using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("General")]
    [SerializeField] int health = 50;    
    [SerializeField] bool isPlayer;
    [SerializeField] ParticleSystem hitEffect;

    [Header("Player Settings")]
    [SerializeField] bool applyCameraShake; // Don't use for AI

    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;


    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        cameraShake = Camera.main.GetComponent<CameraShake>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        
    }  


    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            ShakeCamera();
            damageDealer.Hit();
            audioPlayer.PlayDamageClip();
        }

    }

    void ShakeCamera()
    {
        if (applyCameraShake)
        {
            cameraShake.Play();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        scoreKeeper.ModifyScore();
        if (health <= 0)
        {
            audioPlayer.PlayExplosionClip();            
            Die();           
        }
    }

    void Die()
    {
        if (!isPlayer)
        {
            scoreKeeper.ModifyScoreKill();
        }
        Destroy(gameObject);
    }

    void PlayHitEffect()
    {
        ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
    }

    public int GetHealth()
    {
        return health;
    }
}
