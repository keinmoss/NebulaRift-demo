using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource coin;
    public AudioSource hurt;
    public AudioSource step;

    public void PlayCoin() => coin.Play();
    public void PlayHurt() => hurt.Play();
    public void PlayStep() => step.Play();
}

