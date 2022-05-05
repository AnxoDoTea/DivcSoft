using UnityEngine;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class AudioSettings : MonoBehaviour
{
    //Booleanos para botones

    private bool bSoloKick = false;
    private bool bSoloLeadVox = false;
    private bool bSoloOverhead = false;
    private bool bSoloSnare = false;

    private bool bPlay = false;
    private bool bStop = false;

    private float timer = 0.0f;

    FMOD.Studio.Bus Master;
    FMOD.Studio.Bus Reverb;

    FMOD.Studio.EventInstance Kick;
    FMOD.Studio.EventInstance LeadVox;
    FMOD.Studio.EventInstance Overhead;
    FMOD.Studio.EventInstance Snare;

    void Start()
    {
        Kick = RuntimeManager.CreateInstance("event:/Music/Kick");
        LeadVox = RuntimeManager.CreateInstance("event:/Music/LeadVox");
        Overhead = RuntimeManager.CreateInstance("event:/Music/Overhead");
        Snare = RuntimeManager.CreateInstance("event:/Music/Snare");

        Master = RuntimeManager.GetBus("bus:/");
        Reverb = RuntimeManager.GetBus("bus:/Reverb");
    }

    //-------------------------------------Start & Stop-------------------------------------
    public void bPlayPressed()
    {
        if (bPlay == false)
        {
            bPlay = true;
            bStop = false;
            Kick.start();
            LeadVox.start();
            Overhead.start();
            Snare.start();
        }
    }
    public void bStopPressed()
    {
        if (bStop == false)
        {
            bStop = true;
            bPlay = false;
            Kick.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            LeadVox.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            Overhead.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            Snare.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }

    public IEnumerator DemoMusica()
    {
        bPlayPressed();
        yield return new WaitForSeconds(30f);
        bStopPressed();


    }

    public void activarDemo()
    {
        StartCoroutine("DemoMusica");
    }
    //-------------------------------------Volume Sliders-------------------------------------

    public void MasterVolumeLevel(float newMasterVolume)
    {
        Master.setVolume(newMasterVolume);
    }

    public void KickVolumeLevel(float newKickVolume)
    {
        Kick.setVolume(newKickVolume);
    }

    public void LeadVoxVolumeLevel(float newLeadVoxVolume)
    {
        LeadVox.setVolume(newLeadVoxVolume);
    }

    public void OverheadVolumeLevel(float newOverheadVolume)
    {
        Overhead.setVolume(newOverheadVolume);
    }

    public void SnareVolumeLevel(float newSnareVolume)
    {
        Snare.setVolume(newSnareVolume);
    }

    //-------------------------------------Boton Mute / Unmute-------------------------------------

    public void bMuteKickPressed()
    {
        Kick.setVolume(0.0001f);
    }
    public void bUnmuteKickPressed()
    {
        Kick.setVolume(1f);
    }

    public void bMuteLeadVoxPressed()
    {
        LeadVox.setVolume(0.0001f);
    }
    public void bUnmuteLeadVoxPressed()
    {
        LeadVox.setVolume(1f);
    }

    public void bMuteOverheadPressed()
    {
        Overhead.setVolume(0.0001f);
    }
    public void bUnmuteOverheadPressed()
    {
        Overhead.setVolume(1f);
    }

    public void bMuteSnarePressed()
    {
        Snare.setVolume(0.0001f);
    }
    public void bUnmuteSnarePressed()
    {
        Snare.setVolume(1f);
    }

    //-------------------------------------Boton Solo-------------------------------------
    public void bSoloKickPressed()
    {
        if (bSoloKick == false)
        {
            Kick.setVolume(1f);
            LeadVox.setVolume(0.0001f);
            Overhead.setVolume(0.0001f);
            Snare.setVolume(0.0001f);
            bSoloKick = true;
        }
        else if (bSoloKick == true)
        {
            Kick.setVolume(1f);
            LeadVox.setVolume(1f);
            Overhead.setVolume(1f);
            Snare.setVolume(1f);
            bSoloKick = false;
        }
    }
    public void bSoloLeadVoxPressed()
    {
        if (bSoloLeadVox == false)
        {
            Kick.setVolume(0.0001f);
            LeadVox.setVolume(1f);
            Overhead.setVolume(0.0001f);
            Snare.setVolume(0.0001f);
            bSoloLeadVox = true;
        }
        else if (bSoloLeadVox == true)
        {
            Kick.setVolume(1f);
            LeadVox.setVolume(1f);
            Overhead.setVolume(1f);
            Snare.setVolume(1f);
            bSoloLeadVox = false;
        }
    }
    public void bSoloOverheadPressed()
    {
        if (bSoloOverhead == false)
        {
            Kick.setVolume(0.0001f);
            LeadVox.setVolume(0.0001f);
            Overhead.setVolume(1f);
            Snare.setVolume(0.0001f);
            bSoloOverhead = true;
        }
        else if (bSoloOverhead == true)
        {
            Kick.setVolume(1f);
            LeadVox.setVolume(1f);
            Overhead.setVolume(1f);
            Snare.setVolume(1f);
            bSoloOverhead = false;
        }
    }
    public void bSoloSnarePressed()
    {
        if (bSoloSnare == false)
        {
            Kick.setVolume(0.0001f);
            LeadVox.setVolume(0.0001f);
            Overhead.setVolume(0.0001f);
            Snare.setVolume(1f);
            bSoloSnare = true;
        }
        else if (bSoloSnare == true)
        {
            Kick.setVolume(1f);
            LeadVox.setVolume(1f);
            Overhead.setVolume(1f);
            Snare.setVolume(1f);
            bSoloSnare = false;
        }
    }

    public void bUnsoloPressed()
    {
        Kick.setVolume(1f);
        LeadVox.setVolume(1f);
        Overhead.setVolume(1f);
        Snare.setVolume(1f);
        bSoloKick = false;
        bSoloLeadVox = false;
        bSoloOverhead = false;
        bSoloSnare = false;
    }

    //----------------------------------------------------------------------Reverb-------------------------------------------------------------------------

    public void ReverbVolumeLevel(float newReverbVolume)
    {
        Reverb.setVolume(newReverbVolume);
    }
}