using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioMuteToggle : MonoBehaviour
{
	[SerializeField] Toggle toggle;
	[SerializeField] AudioMixer audioMixer;
	[SerializeField] string MasterVolumeParameter;
	private int mutePref;

	private void Awake () {
		mutePref = PlayerPrefs.GetInt("MUTE");
	}

	private void Start () {
		mutePref = PlayerPrefs.GetInt("MUTE");
		float volumeValue = 0;
		if (mutePref == 1) {
			volumeValue = -80;
		}
		audioMixer.SetFloat(MasterVolumeParameter, volumeValue);
		toggle.SetIsOnWithoutNotify(volumeValue == -80);
	}


	public void SetMute (bool toggleValue) {
		int mute;
		float volumeValue;
		if (toggleValue) {
			volumeValue = -80;
			mute = 1;
		} else {
			volumeValue = 0;
			mute = 0;
		}

		audioMixer.SetFloat(MasterVolumeParameter, volumeValue);
		PlayerPrefs.SetInt("MUTE", mute);
		PlayerPrefs.SetFloat("MASTER_VOL", volumeValue);
		PlayerPrefs.Save();
	}

	private void OnDestroy () {
		PlayerPrefs.Save();
	}

}
