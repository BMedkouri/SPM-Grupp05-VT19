using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{

    #region README
    /* 
     * If audiomanager.cs doesnt exist, and we call .Play() from somewhere...
     * Unity will do unecessary bullshit. so... Dont kill me (this script).  
     * https://www.youtube.com/watch?v=tLyj02T51Oc 16:56
     */
    #endregion

    #region Quick Tips
    /*
     * Quick tips:
     *            - Volume:
     *              Between 0 and 1. 
     *              0 = mute
     *              1 = max
     *            
     *            - Overlapping:
     *              If you have two clips overlapping it's going to completely mute the previous cliip, and play the new one.
     *              (It is going to clip that clip apart).
     *              Using PlayOneShot is a little expensive on CPU, BUT! You can overlap clips, without any cuts.   
     */
    #endregion

    #region Static Instance
    private static audioManager instance;
    public static audioManager Instance
    {

        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<audioManager>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned Audiomanager", typeof(audioManager)).GetComponent<audioManager>();
                }
            }
            return instance;
        }

        private set
        {
            instance = value;
        }

    }
    #endregion

    #region Fields
    private AudioSource musicSource;
    private AudioSource musicSource2; //For purpose of crossfade between 2 scenes
    private AudioSource sfxSource;

    private bool firstMusicSourceIsPlaying;

    #endregion


    private void Awake()
    {
        musicSource = this.gameObject.AddComponent<AudioSource>();
        musicSource2 = this.gameObject.AddComponent<AudioSource>();
        sfxSource = this.gameObject.AddComponent<AudioSource>();

        //Loop the music tracks
        musicSource.loop = true;
        musicSource2.loop = true;

    }

    #region PlayMusic
    public void PlayMusic(AudioClip musicClip)
    {
        AudioSource activeSource = (firstMusicSourceIsPlaying) ? musicSource : musicSource2; //Determine which source is active

        activeSource.clip = musicClip;
        activeSource.volume = 1;
        activeSource.Play();
    }

    public void PlayMusicWithFade(AudioClip newClip, float transitionTime = 1.0f)
    {
        AudioSource activeSource = (firstMusicSourceIsPlaying) ? musicSource : musicSource2; //Determine which source is active

        StartCoroutine(UpdateMusicWithFade(activeSource, newClip, transitionTime));


    }

    public void PlayMusicWithCrossFade(AudioClip musicClip, float transitionTime = 1.0f)
    {
        AudioSource activeSource = (firstMusicSourceIsPlaying) ? musicSource : musicSource2; //Determine which source is active
        AudioSource newSource = (firstMusicSourceIsPlaying) ? musicSource2 : musicSource;

        firstMusicSourceIsPlaying = !firstMusicSourceIsPlaying;

        newSource.clip = musicClip;
        newSource.Play();
        StartCoroutine(UpdateMusicWithCrossFade(activeSource, newSource, transitionTime));


    }
    #endregion

    #region UpdateMusic
    private IEnumerator UpdateMusicWithFade(AudioSource activeSource, AudioClip newClip, float transitionTime)
    {
        // Make sure the source is active and playing
        if (!activeSource.isPlaying)
        {
            activeSource.Play();

            float transition = 0.0f;

            //Fade out loop
            for (transition = 0; transition < transitionTime; transition += Time.deltaTime)
            {
                activeSource.volume = (1 - (1 / transition / transitionTime));
                yield return null;
            }

            activeSource.Stop();
            activeSource.clip = newClip;
            activeSource.Play();

            //Fade in
            for (transition = 0; transition < transitionTime; transition += Time.deltaTime)
            {
                activeSource.volume = (transition / transitionTime);
                yield return null;
            }
        } // Hmmm 1 too mcuh ? }
    }
    private IEnumerator UpdateMusicWithCrossFade(AudioSource original, AudioSource newSource, float transitionTime)
    {
        float transition = 0.0f;

        for (transition = 0.0f; transition <= transitionTime; transition += Time.deltaTime)
        {
            original.volume = (1 - (transition / transitionTime));
            newSource.volume = (transition / transitionTime);
            yield return null;
        }
        original.Stop();
    }
    #endregion

    #region PlaySFX
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
    public void PlaySFX(AudioClip clip, float volume)
    {
        sfxSource.PlayOneShot(clip, volume);
        
    }
    #endregion

    public void PlayLoop(AudioClip clip, float volume)
    {
        //sfxSource.loop = true;
        sfxSource.loop = enabled;
        sfxSource.PlayOneShot(clip);
        
    }

    public void StopLoop(AudioClip clip, float volume)
    {
        sfxSource.loop = !enabled;
    }


    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        musicSource2.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

}


