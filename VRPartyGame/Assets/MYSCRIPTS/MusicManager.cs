using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MusicManager : MonoBehaviour
{
    private float volume = 1.0f; // Default volume level
    public AudioSource[] audioSources; // Array of all AudioSource components
    public AudioClip AudioClip; // The AudioClip to play
    public void SetVolume(float newVolume)
    {
        volume = Mathf.Clamp01(newVolume); // Ensure volume is between 0 and 1
        foreach (AudioSource audioSource in audioSources) // Loop through all AudioSource components
        {
            audioSource.volume = volume; // Set the volume on all AudioSource components
        }
    }

    // Method to get the current volume level
    public float GetVolume()
    {
        return volume;
    }

   // Method to play the AudioClip
   public void PlayMusic()
    {
        foreach (AudioSource audioSource in audioSources) // Loop through all AudioSource components
        {
            audioSource.clip = AudioClip; // Set the AudioClip on all AudioSource components
            audioSource.Play(); // Play the AudioClip on all AudioSource components
        }
    }
}
