using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
//[RequireComponent(typeof(AudioSource))]
public abstract class UniversalCollision : MonoBehaviour
{
    protected abstract void OnTriggerAction(Collider collider);
    [Header("Feedback")]
    //[SerializeField] AudioClip _pickupSFX = null;
    [SerializeField] protected ParticleSystem _particlePrefab = null;
    Collider _collider = null;
    AudioSource _audioSource = null;
    protected virtual void Awake()
    {
        _collider = GetComponent<Collider>();
        _audioSource = GetComponent<AudioSource>();
    }
    protected virtual void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        OnTriggerAction(other);



        //if (_pickupSFX != null)
        //{
        //    SpawnAudio(_pickupSFX);
        //}

        if (_particlePrefab != null)
        {
            SpawnParticle(_particlePrefab);
        }


    }

    private void Reset()
    {
        // set isTrigger in the Inspector, just in case Designer forgot
        Collider collider = GetComponent<Collider>();
        collider.isTrigger = true;
    }

    void SpawnAudio(AudioClip pickupSFX)
    {
        AudioSource.PlayClipAtPoint(pickupSFX, transform.position);
    }

    void SpawnParticle(ParticleSystem pickupParticles)
    {
        ParticleSystem newParticles =
            Instantiate(pickupParticles, transform.position, Quaternion.identity);
        newParticles.Play();
    }

}
