using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeValueChange : MonoBehaviour {

    /** Contributed by Team Member */
    
    public AudioMixer BGMusicMixer;

    public Slider MusicSlider;

    private static VolumeValueChange instance = null;

    public static VolumeValueChange Instance
    {
        get { return instance;  }
    }
    

    /*public void SetVolume(float volume)
    {
        BGMusicMixer.SetFloat("BGMusicParam", volume);
    }

    private void Start()
    {
        MusicSlider.value = PlayerPrefs.GetFloat("musicVolume", 0);
    }

    private void OnDisable()
    {
        float BGVolume = 0;
        BGMusicMixer.GetFloat("BGMusicParam", out BGVolume);
        PlayerPrefs.SetFloat("musicVolume", BGVolume);
        PlayerPrefs.Save();
    }*/

    public void SetVolume(float slider_volume)
    {
        BGMusicMixer.SetFloat("BGMusicParam", ConvertToDecibel(slider_volume));
        PlayerPrefs.SetFloat("musicVolume", slider_volume);
    }

    private void Start()
    {
        MusicSlider.value = PlayerPrefs.GetFloat("musicVolume", 0.75f);
    }

    public float ConvertToDecibel(float _value)
    {
        return Mathf.Log10(Mathf.Max(_value, 0.0001f)) * 20f;
    }

    /*private void Awake()
    {
        
        if (instance != null && instance!=this)
        {
            //Debug.Log("Not null");
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            //Debug.Log("Object is null");
            
        }
        DontDestroyOnLoad(gameObject);

    }*/
}
