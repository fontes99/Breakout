using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_behavior : MonoBehaviour
{

    public static AudioClip log_break, dmg;
    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        log_break = Resources.Load<AudioClip>("Music/log_break");
        dmg = Resources.Load<AudioClip>("Music/damage");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip){
        switch (clip){
            case "log_break":
                audioSource.PlayOneShot(log_break);
                break;
            case "dmg":
                audioSource.PlayOneShot(dmg);
                break;
        }
    }
}
