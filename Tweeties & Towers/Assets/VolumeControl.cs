using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] string _volumeParameter = "MasterVolume"; // Name of the volume parameter in the AudioManager
    [SerializeField] AudioMixer _mixer; // Reference to the AudioMixer component 
    [SerializeField] Slider _slider; // Reference to the Slider component for volume control
    [SerializeField] float _multiplier = 30f; // Multiplier for the volume parameter
    [SerializeField] private Toggle _toggle; // Reference to the Toggle component for muting/unmuting
    private bool _disableToggleEvent;

    private void Awake()
    {
        _slider.onValueChanged.AddListener(SetVolume); // Add a listener to the slider's value change event
        _toggle.onValueChanged.AddListener(SetMute); // Add a listener to the toggle's value change event
    }

    private void SetMute(bool enableSound)
    {
        if (_disableToggleEvent)
            return; // If the toggle event is disabled, do not proceed 
        if (enableSound)
        {
            _slider.value = _slider.maxValue; // Set the slider value to the maximum value (unmute)
        }    
        else
        {
            _slider.value = _slider.minValue; // Set the slider value to the minimum value (mute)
            _disableToggleEvent = true; // Prevent the toggle event from being triggered when muting
            _toggle.isOn = _slider.value > _slider.minValue; // Update the toggle state based on the slider value
            _disableToggleEvent = false; // Reset the flag to allow toggle event to be triggered again
        }
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat(_volumeParameter, _slider.value); 
    }

    private void SetVolume(float value)
    {
        _mixer.SetFloat(_volumeParameter, Mathf.Log10(value) * _multiplier); // Set the volume parameter in the AudioMixer based on the slider value
    }

    void Start()
    {
        _slider.value = PlayerPrefs.GetFloat(_volumeParameter, _slider.value); // Get the saved volume value from PlayerPrefs or use the default slider value
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
