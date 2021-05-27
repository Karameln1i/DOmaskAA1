using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlaySignalization : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeChangeRate;
    
   private Coroutine _changeVolumeJob;
   private float _maximumSoundValue=1F;
   private float _minimumSoundValue = 0F;

   private void OnTriggerEnter2D(Collider2D colision)
   {
       if (colision.TryGetComponent<Thief>(out Thief thief))
       {
           if (_audioSource.volume == 0F) 
           {
               _audioSource.Play();
<<<<<<< HEAD
                _changeVolumeJob = StartCoroutine(ChangeVolume(_maximumSoundValue));
=======
                _changeVolumeJob = StartCoroutine(ChangeVolume(Time.deltaTime * _volumeChangeRate,_maximumSoundValue));
>>>>>>> 75f0f666de4ff80b54e559e71ec25c5b856a99fc
           }
           else
           {
               StopCoroutine(_changeVolumeJob);
<<<<<<< HEAD
               _changeVolumeJob = StartCoroutine(ChangeVolume(_minimumSoundValue));
=======
               _changeVolumeJob = StartCoroutine(ChangeVolume(Time.deltaTime * _volumeChangeRate,_minimumSoundValue));
>>>>>>> 75f0f666de4ff80b54e559e71ec25c5b856a99fc
           }
       }
   }
   
   private IEnumerator ChangeVolume(float soundValue)
   {
       while (_audioSource.volume!=soundValue)
       {
           _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, soundValue, Time.deltaTime*_volumeChangeRate);
           yield return null;
       }
   }
}
