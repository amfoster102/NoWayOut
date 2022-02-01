using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip scream, darklaugh, keypickup, backgroundmusic;
    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        scream = Resources.Load<AudioClip>("scream");
        darklaugh = Resources.Load<AudioClip>("DarkLaugh");
        keypickup = Resources.Load<AudioClip>("keypickup");
        backgroundmusic = Resources.Load<AudioClip>("backgroundmusic");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "scream":
                audioSource.PlayOneShot(scream);
                break;
            case "darklaugh":
                audioSource.PlayOneShot(darklaugh);
                break;
            case "keypickup":
                audioSource.PlayOneShot(keypickup);
                break;
           
            
        }
    }
}
