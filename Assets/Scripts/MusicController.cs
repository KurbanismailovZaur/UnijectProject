using System.Collections;
using Uniject.Attributes;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    private MusicClipsProvider _musicClipsProvider;
    private Coroutine _playCoroutine;

    [Inject]
    private void Construct(MusicClipsProvider musicClipsProvider)
    {
        _musicClipsProvider = musicClipsProvider;
    }

    public void StartPlayRandomMusics()
    {
        _playCoroutine = StartCoroutine(StartPlayRandomMusicEnumerator());
    }

    private IEnumerator StartPlayRandomMusicEnumerator()
    {
        while (true)
        {
            var musicClip =_musicClipsProvider.Data[Random.Range(0, _musicClipsProvider.Data.Length)];
            _audioSource.PlayOneShot(musicClip);

            yield return new WaitForSeconds(musicClip.length);
        }
    }

    public void StopPlayingMusic()
    {
        if (_playCoroutine == null)
            return;

        _audioSource.Stop();
        StopCoroutine(_playCoroutine);
        _playCoroutine = null;
    }

    public void StartPlayNextMusic()
    {
        StopPlayingMusic();
        StartPlayRandomMusics();
    }
}