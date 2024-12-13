using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;

    Resolution[] _resolutions;
    [SerializeField] TMP_Dropdown resolutionDropdown;

    int _currentResolutionIndex;
    List<Resolution> uniqueResolutions = new List<Resolution>(); 

    void Start() {
        _resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        HashSet<string> uniqueResolutionsSet = new HashSet<string>();

        for (int i = 0; i < _resolutions.Length; i++) {
            string option = _resolutions[i].width + " x " + _resolutions[i].height;

            if (uniqueResolutionsSet.Add(option)) { 
                options.Add(option);
                uniqueResolutions.Add(_resolutions[i]); 
            }

            if (_resolutions[i].width == Screen.currentResolution.width &&
                _resolutions[i].height == Screen.currentResolution.height) {
                _currentResolutionIndex = uniqueResolutions.Count - 1;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = _currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex) {
        Resolution resolution = uniqueResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
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
