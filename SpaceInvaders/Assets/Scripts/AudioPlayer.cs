using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting Player")]
    [SerializeField] AudioClip shootingPlayerSFX;
    [SerializeField] [Range(0f,1f)] float shootingPlayerVolume = 1f;

    [Header("Shooting AI")]
    [SerializeField] AudioClip shootingAiSFX;
    [SerializeField] [Range(0f, 1f)] float shootingAiVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damageSFX;
    [SerializeField] [Range(0f, 1f)] float damageVolume = 1f;

    [Header("Explosion")]
    [SerializeField] AudioClip explosionSFX;
    [SerializeField] [Range(0f, 1f)] float explosionVolume;


    void Awake()
    {
        ManageSingleton();    
    }

    void ManageSingleton()
    {
        // Find this type of objects in whole game and store in array
        int instanceCount = FindObjectsOfType(GetType()).Length;
        if(instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    public void PlayShootingClipPlayer()
    {

        PlayClip(shootingPlayerSFX, shootingPlayerVolume);
    }

    public void PlayShootingClipAI()
    {
        PlayClip(shootingAiSFX, shootingAiVolume);
    }

    public void PlayDamageClip()
    {
        PlayClip(damageSFX, damageVolume);
    }

    public void PlayExplosionClip()
    {
        PlayClip(explosionSFX, explosionVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }



}
