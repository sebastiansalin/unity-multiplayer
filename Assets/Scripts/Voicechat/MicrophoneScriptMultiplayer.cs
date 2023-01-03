using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MicrophoneScriptMultiplayer : NetworkBehaviour
{
    public AudioSource source;
    private AudioClip audioclip;
    private string micName;
    private int frameCount = 0;
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
        if(!source.enabled){
            if(frameCount > 1){
                source.enabled = true;
            } else {
                frameCount += 1;
            }
            
        }
        
        source.clip = audioclip;
    }

    public void MicrophoneToAudio(){
        micName = Microphone.devices[0];
        Debug.Log("Mic name is: "+micName);

        //AudioClip done = Microphone.Start(micName,true,20,AudioSettings.outputSampleRate);
        
        audioclip = Microphone.Start(micName,true,5,AudioSettings.outputSampleRate);
    }
}
