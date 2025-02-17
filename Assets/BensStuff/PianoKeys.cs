﻿using UnityEngine;
using System.Collections;

public class PianoKeys : MonoBehaviour
{
    Animation anim;

    public AudioSource pianoAudio;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnHandHoverBegin(VRHand hand)
    {
        if(Globals.ritualSequence.Count >= 3)
        {
            Globals.ritualSequence[2] = true;
        }
        anim.Play();
        pianoAudio.Play();
        Globals.buttonPressed = !Globals.buttonPressed;
        Debug.Log(Globals.buttonPressed);
    }
}
