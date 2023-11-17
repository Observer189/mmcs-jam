using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

public class SoundSettingSliderController : SliderValueMapping
{
    [SerializeField]
    private MMSoundManager.MMSoundManagerTracks trackType;
    
    [SerializeField]
    private float maxTrackVolume;
    [SerializeField]
    private int maxSliderValue = 100;

    public void ApplySetting()
    {
        MMSoundManagerTrackEvent.Trigger(MMSoundManagerTrackEventTypes.SetVolumeTrack,trackType,
            (slider.value/maxSliderValue)*maxTrackVolume);
    }

    public void Load()
    {
        if(slider==null)
            Awake();
        var volume=MMSoundManager.Instance.settingsSo.GetTrackVolume(trackType);
        slider.value = volume / maxTrackVolume * maxSliderValue;
        UpdateText();
    }
}
