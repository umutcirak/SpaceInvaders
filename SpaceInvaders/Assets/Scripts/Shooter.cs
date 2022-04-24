using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 2f;
    [SerializeField] float firingRate = 0.3f;

    [Header("AI")]
    [SerializeField] float minFiringRateAI = 1f;    
    [SerializeField] float firingTimeVarienceAI = 0.65f;
    [SerializeField] bool useAI;

    [HideInInspector] public bool isFiring;

    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if (useAI) { InitAI(); }

    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());

        }
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }        
                 
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            Rigidbody2D rbInstance = instance.GetComponent<Rigidbody2D>();
            rbInstance.velocity = transform.up * projectileSpeed;

            Destroy(instance, projectileLifeTime);

            
            if (!useAI) 
            {
                audioPlayer.PlayShootingClipPlayer();
                yield return new WaitForSeconds(firingRate); 
            }
            else
            {
                audioPlayer.PlayShootingClipAI();
                yield return new WaitForSeconds(GetRandomfiringRateAI()); 
            }           
                                    
        }
    }

    void InitAI()
    {                     
        isFiring = true; 
        projectileSpeed = -projectileSpeed;
        firingRate = minFiringRateAI;        
    }

    float GetRandomfiringRateAI()
    {
        return Random.Range(minFiringRateAI, minFiringRateAI + firingTimeVarienceAI);
    }


}
