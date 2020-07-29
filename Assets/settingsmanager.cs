using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.IO;

public class settingsmanager : MonoBehaviour
{
    public Toggle fullscreenToggle;
    public Dropdown resolutiondropdown;
    public Slider musicvolumeslider;
    public Button applybutton;

    public Resolution[] resolutions;
    public gamesett gamesettings;
    public AudioSource musicSource;
    void OnEnable () {

        gamesettings = new gamesett();
        
        fullscreenToggle.onValueChanged.AddListener(delegate {Onfullscreentoggle();});
        resolutiondropdown.onValueChanged.AddListener(delegate {Onresolutionchange();});
        musicvolumeslider.onValueChanged.AddListener(delegate {Onvolumechange();});
        applybutton.onClick.AddListener(delegate {Onapply();});

        resolutions = Screen.resolutions;
        foreach(Resolution res in resolutions) {
            resolutiondropdown.options.Add(new Dropdown.OptionData(res.ToString()));
        }
        loadsettings();
    }
    
    public void Onfullscreentoggle() {

        
        gamesettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
        Debug.Log("cevaaafullscreen=========");
    }

    public void Onresolutionchange() {
        Screen.SetResolution(resolutions[resolutiondropdown.value].width,
                            resolutions[resolutiondropdown.value].height,
                            Screen.fullScreen);
        gamesettings.resolutionIndex = resolutiondropdown.value;
       
    }
    
    public void Onvolumechange() {
        musicSource.volume = gamesettings.musicVolume = musicvolumeslider.value;
    }

    public void Onapply() {

    }
    public void savesettings() {

    string jsonData = JsonUtility.ToJson(gamesettings, true);
    File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);
    }

    public void loadsettings() {
        gamesettings = JsonUtility.FromJson<gamesett>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));
        musicvolumeslider.value = gamesettings.musicVolume;
        resolutiondropdown.value = gamesettings.resolutionIndex;
        fullscreenToggle.isOn = gamesettings.fullscreen;
        Screen.fullScreen = gamesettings.fullscreen;
        resolutiondropdown.RefreshShownValue();
    }
}
