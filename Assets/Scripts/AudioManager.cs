using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------- Audio Source --------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------- Audio Clips --------")]
    public AudioClip title;
    public AudioClip background;
    public AudioClip knifeAttack;
    public AudioClip forceFieldAttack;
    public AudioClip playerDmg;
    public AudioClip enemyDmg;
    public AudioClip itemPickUp;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
