using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _grumbleShipAudio, _grumbleCockpitAudio;
    void Start()
    {
        _grumbleShipAudio.volume = 0.3f;
        _grumbleCockpitAudio.volume = 0.1f;

        _grumbleCockpitAudio.Stop();
        _grumbleShipAudio.Play();
    }



    public void ShipGrumbleOn()
    {
        _grumbleShipAudio.Play();
    }
    public void ShipGrumbleOff()
    {
        _grumbleShipAudio.Stop();
    }
    public void CockpitGrumbleOn()
    {
        _grumbleCockpitAudio.Play();
    }
    public void CockpitGrumbleOff()
    {
        _grumbleCockpitAudio.Stop();
    }


}
