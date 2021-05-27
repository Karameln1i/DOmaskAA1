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
                _changeVolumeJob = StartCoroutine(ChangeVolume(_maximumSoundValue));
           }
           else
           {
               StopCoroutine(_changeVolumeJob);
               _changeVolumeJob = StartCoroutine(ChangeVolume(_minimumSoundValue));
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
