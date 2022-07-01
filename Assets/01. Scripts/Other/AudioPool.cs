using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPool : PoolAbleObject
{
    AudioSource audioSource;
    public override void Init_Pop()
    {
        if(audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    public override void Init_Push()
    {
        audioSource.Stop();
    }

    public void Play(AudioClip clip, float pitch = 1f, float volume = 1f)
    {
        audioSource.clip = clip;
        audioSource.pitch = pitch;
        audioSource.volume = volume;

        audioSource.Play();

        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        PoolManager.instance.Push(PoolType, gameObject);
    }
}
