using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioClip F1, G1, Bb, C, D, Eb, F2, G2, A, C2;
    public AudioSource audioSource;
    public AudioClip bg;
    public Slider volumeSlider;

    private List<AudioClip> song;
    private int clipIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        AudioClip[] songArray = {D, F1, Bb, D, G2, F2,
                                 D, F1, Bb, D, G2, F2,
                                 D, G1, Bb, D, A, G2,
                                 G2, C, Eb, G2, F2, Eb, F2, C2};
        song = new List<AudioClip>(songArray);

        audioSource.clip = bg;
        audioSource.Play();
        audioSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = volumeSlider.value;
    }

    public void PlayNextSongClip()
    {
        audioSource.clip = song[clipIndex];
        audioSource.Play();
        clipIndex = (clipIndex + 1) % (song.Count);
    }
}
