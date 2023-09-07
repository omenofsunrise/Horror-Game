using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusikManager : MonoBehaviour
{
    public string volumeParameter = "MasterVolume";
    public AudioMixer mixer;
    public Slider slider;
    public const float _multiplier = 20f;

    private float _volumeValue;

    private void Awake()
    {
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    private void HandleSliderValueChanged(float value)
    {
        _volumeValue = Mathf.Log10(value) * _multiplier;
        mixer.SetFloat(volumeParameter, _volumeValue);

    }

  

    void Start()
    {
        PlayerPrefs.GetFloat(volumeParameter, Mathf.Log10(slider.value) * _multiplier);
        slider.value = Mathf.Pow(10f, _volumeValue / _multiplier);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(volumeParameter, _volumeValue);
    }



    //public Toggle toggleMusik;
    //public Slider sliderVolumeMusik;
    //public AudioSource audio;
    //public float volume;




    //// Start is called before the first frame update
    //void Start()
    //{
    //    Load();
    //    ValueMusik();

    //    toggleMusik = GameObject.FindGameObjectWithTag("Toggle").GetComponent<Toggle>();
    //    sliderVolumeMusik = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
    //}

    //public void SliderMusik()
    //{
    //    volume = sliderVolumeMusik.value;
    //    Save();
    //    ValueMusik();
    //}

    //public void ToggleMusik()
    //{
    //    if (toggleMusik.isOn == true)
    //    {
    //        volume = 1;
    //    }
    //    else
    //    {
    //        volume = 0;
    //    }
    //    Save();
    //    ValueMusik();
    //}

    //private void ValueMusik()
    //{
    //    audio.volume = volume;
    //    sliderVolumeMusik.value = volume;
    //    if (volume == 0 ) 
    //    {
    //        toggleMusik.isOn = false;
    //    }
    //    else
    //    {
    //        toggleMusik.isOn = true;
    //    }
    //}













    //private void Save()
    //{
    //    PlayerPrefs.SetFloat("volume", volume);
    //}

    //private void Load()
    //{
    //    volume = PlayerPrefs.GetFloat("volume", volume);
    //}
}
