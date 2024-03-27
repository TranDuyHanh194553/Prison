using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------AudioSource-------")]
   [SerializeField] AudioSource musicSource;
   [SerializeField] AudioSource SFXSource;

    [Header("--------AudioClip--------")]
   public AudioClip background;
//    public AudioClip caught;
   public AudioClip clear;
   public AudioClip fail;
//    public AudioClip flashLight;
   public AudioClip getKey;
   public AudioClip jump;
   public AudioClip sus;
   public AudioClip walk;
   public AudioClip click;
   public AudioClip doorOpen;
   
    private void Start(){
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }
}

