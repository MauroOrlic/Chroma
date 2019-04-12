using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Audio;

public class MenuButtonBehaviour : MonoBehaviour {
	GameObject Manager;
	public Resolution[] screenResolutions;
    [SerializeField] public AudioMixer audioMixer;
	// Use this for initialization
	void Start () {
		Manager = GameObject.Find("Manager");

        screenResolutions = Screen.resolutions;
		setVolumeMaster(Manager.GetComponent<Manager>().volumeMaster);		
		setVolumeSFX(Manager.GetComponent<Manager>().volumeSFX);
		setVolumeMusic(Manager.GetComponent<Manager>().volumeMusic);

		GameObject.Find("Master").GetComponent<Slider>().value = Manager.GetComponent<Manager>().volumeMaster;
		GameObject.Find("SoundEffects").GetComponent<Slider>().value = Manager.GetComponent<Manager>().volumeSFX;
		GameObject.Find("Music").GetComponent<Slider>().value = Manager.GetComponent<Manager>().volumeMusic;

		GameObject.Find("OptionsContainer").SetActive(false);
		GameObject.Find("InstructionsContainer").SetActive(false);
	}
	
	void Update () {
		
	}
	public void PlayHit(){
		Manager.GetComponent<Manager>().LoadGame();
	}
	public void InstructionsHit(){}
	public void OptionsHit(){}
	public void QuitHit()
	{
		Application.Quit();
	}
	    public void setVolumeMaster(float newVolume)
    {
		Manager.GetComponent<Manager>().volumeMaster = newVolume;
        audioMixer.SetFloat("Master", Mathf.Log(newVolume) * 20);
    }
    public void setVolumeSFX(float newVolume)
    {
		Manager.GetComponent<Manager>().volumeSFX = newVolume;
        audioMixer.SetFloat("SFX", Mathf.Log(newVolume) * 20);
    }
    public void setVolumeMusic(float newVolume)
    {
		Manager.GetComponent<Manager>().volumeMusic = newVolume;
        audioMixer.SetFloat("Music", Mathf.Log(newVolume) * 20);
    }
    public void setGameQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
	public void SettingsClosed()
	{		
		Manager.GetComponent<Manager>().UpdateSettings();
	}
}
