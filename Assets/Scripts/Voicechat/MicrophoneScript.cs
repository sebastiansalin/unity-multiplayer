using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneScript : MonoBehaviour
{
    public AudioSource source;
    private AudioClip audioclip;
    private string micName;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        MicrophoneToAudio();
        source.clip = audioclip;
    }

    // Update is called once per frame
    void Update()
    {
        source.clip = audioclip;
        Debug.Log(Microphone.IsRecording(micName));
        Debug.Log(Microphone.GetPosition(micName));
    }

    public void MicrophoneToAudio(){
        micName = Microphone.devices[0];
        Debug.Log("Mic name is: "+micName);

        //AudioClip done = Microphone.Start(micName,true,20,AudioSettings.outputSampleRate);
        
        audioclip = Microphone.Start(micName,true,5,AudioSettings.outputSampleRate);
    }
}
