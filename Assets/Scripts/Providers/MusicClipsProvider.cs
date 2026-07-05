using Uniject;
using UnityEngine;

public class MusicClipsProvider : IProvider<AudioClip[]>
{
    public bool HasData { get; set; }

    public AudioClip[] Data { get; set; }

    public MusicClipsProvider(AudioClip[] musicClips)
    {
        Data = musicClips;
        HasData = true;
    }
}