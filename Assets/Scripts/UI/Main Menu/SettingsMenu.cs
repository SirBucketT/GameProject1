using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;
    
    Resolution[] _resolutions;
    [SerializeField] TMP_Dropdown resolutionDropdown;

    int _currentResolutionIndex;
    
    void Start() {
        _resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        
        List<string> options = new List<string>();

        for (int i = 0; i < _resolutions.Length; i++) {
            string option = _resolutions[i].width + " x " + _resolutions[i].height;
            options.Add(option);

            if (_resolutions[i].width == Screen.currentResolution.width &&
                _resolutions[i].height == Screen.currentResolution.height) {
                _currentResolutionIndex = i;
            }
        }
        
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = _currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    
    public void CloseSettingsMenu() {
        settingsMenu.SetActive(false);
    }

    public void OpenSettingsMenu() {
        settingsMenu.SetActive(true);
    }
    
    public void SetFullscreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }
}
