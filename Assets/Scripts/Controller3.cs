using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller3 : MonoBehaviour
{

    public static bool sounds;
    public static bool music;
    // Start is called before the first frame update
    void Start()
    {
        sounds = true;
        music = true;
    }


    public void onChangeSoundFX(bool newValue)
    {
        sounds = newValue;
        
    }

    public void onChangeMusic(bool newValue)
    {
        music = newValue;
        
    }
}
