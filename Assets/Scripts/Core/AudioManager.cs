using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Scripts.Core
{
    public static class AudioClipSet
    {
        public static AudioClip MainBackgroundMusic => Resources.Load<AudioClip>("Audio/Retro Synth/Run the brave");
        public static AudioClip LevelGameBackgroundMusic => Resources.Load<AudioClip>("Audio/16-bit Space Adventure Music Pack v1.1/WAVs/04a Power Up for Light Speed (w Intro)");
        public static AudioClip BossGameBackgroundMusic => Resources.Load<AudioClip>("Audio/16-bit Space Adventure Music Pack v1.1/WAVs/01b Engaging Hyper Drive");
        public static AudioClip PauseBackgroundMusic => Resources.Load<AudioClip>("Audio/16-bit Space Adventure Music Pack v1.1/WAVs/06a Assembling Technical Components");
        public static AudioClip VictoryBackgrounMusic => Resources.Load<AudioClip>("Audio/Cosmic Disco/Plasma Bolt");
        public static AudioClip DefeatBackgroundMusic => Resources.Load<AudioClip>("Audio/16-bit Space Adventure Music Pack v1.1/WAVs/02a The Vastness of Outer Space");
        public static AudioClip HoverLevel => Resources.Load<AudioClip>("Audio/SCI-FI_UI_SFX_PACK/Clicks/Click_2");
        public static AudioClip ClickSaveChanges => Resources.Load<AudioClip>("Audio/SCI-FI_UI_SFX_PACK/Tone1/Tritone/Tone1A_TritoneOctaveUp");
        public static AudioClip ClickResetChanges => Resources.Load<AudioClip>("Audio/SCI-FI_UI_SFX_PACK/Tone1/Tritone/Tone1A_TritoneUp");
        public static AudioClip ClickNewWindow => Resources.Load<AudioClip>("Audio/SCI-FI_UI_SFX_PACK/Click Combos/Click_Combo_3_High");
        public static AudioClip ClickFormerWindow => Resources.Load<AudioClip>("Audio/SCI-FI_UI_SFX_PACK/Click Combos/Click_Combo_4");
        public static AudioClip ClickAccept => Resources.Load<AudioClip>("Audio/SCI-FI_UI_SFX_PACK/Click Combos/Click_Combo_2_High");
        public static AudioClip ClickDiscard => Resources.Load<AudioClip>("Audio/SCI-FI_UI_SFX_PACK/Click Combos/Click_Combo_2");
        public static AudioClip ClickNeutral => Resources.Load<AudioClip>("");
        public static AudioClip ClickSelectItem => Resources.Load<AudioClip>("Audio/SCI-FI_UI_SFX_PACK/Clicks/Click_1");
        public static AudioClip ClickNewTab => Resources.Load<AudioClip>("Audio/SCI-FI_UI_SFX_PACK/Clicks/High_Click_2");
        public static AudioClip ClickClosePopUPDialog => Resources.Load<AudioClip>("Audio/SCI-FI_UI_SFX_PACK/Clicks/Click_Pitched_Down_High_Pass");
        public static AudioClip PopUpDialog => Resources.Load<AudioClip>("Audio/SCI-FI_UI_SFX_PACK/Click Combos/Click_Combo");
        public static AudioMixer GlobalAudioMixer => Resources.Load<AudioMixer>("Audio/AudioMixer");
        public static void MusicVolume(float volumePercentage)
        {
            GlobalAudioMixer.SetFloat("MusicVolume", GetDecibels(volumePercentage));
        }
        public static void SFXVolume(float volumePercentage)
        {
            GlobalAudioMixer.SetFloat("SFXVolume", GetDecibels(volumePercentage));
        }
        public static float GetDecibels(float volumePercentage)
        {
            if (volumePercentage == 0)
            {
                return -80f;
            }
            else
            {
                return Mathf.Log10(volumePercentage / 100f) * 20f;
            }
        }
    }
    public class AudioManager : MonoBehaviour
    {
        private static AudioManager veryFirstInstance;
        private AudioSource backgroundMusicSource;
        private AudioSource uiSFXSource;
        public static AudioManager Instance { get {
                if (veryFirstInstance == null)
                {
                    GameObject immortalMusicManager = new("MusicManager");
                    veryFirstInstance = immortalMusicManager.AddComponent<AudioManager>();

                    veryFirstInstance.backgroundMusicSource = immortalMusicManager.AddComponent<AudioSource>();
                    veryFirstInstance.backgroundMusicSource.clip = AudioClipSet.MainBackgroundMusic;
                    veryFirstInstance.backgroundMusicSource.loop = true;
                    AudioMixerGroup[] musicGroup = AudioClipSet.GlobalAudioMixer.FindMatchingGroups("Music");
                    if (musicGroup.Length > 0)
                    {
                        veryFirstInstance.backgroundMusicSource.outputAudioMixerGroup = musicGroup[0];
                    }
                    veryFirstInstance.backgroundMusicSource.Play();

                    veryFirstInstance.uiSFXSource = immortalMusicManager.AddComponent<AudioSource>();
                    veryFirstInstance.uiSFXSource.loop = false;
                    AudioMixerGroup[] SFXGroup = AudioClipSet.GlobalAudioMixer.FindMatchingGroups("SFX");
                    if (SFXGroup.Length > 0)
                    {
                        veryFirstInstance.uiSFXSource.outputAudioMixerGroup = SFXGroup[0];
                    }

                    DontDestroyOnLoad(immortalMusicManager);
                }
                return veryFirstInstance;
            }
            private set {}
        }
        public void Resume()
        {
            return;
        }
        public void SetTrackStartTime(float time)
        {
            backgroundMusicSource.time = time;
        }
        public void PlayNewTrack(AudioClip newTrack)
        {
            if (backgroundMusicSource.clip == newTrack) return;
            backgroundMusicSource.clip = newTrack;
            backgroundMusicSource.Play();
        }
        public void PlayUISFX(AudioClip uiSFX)
        {
            uiSFXSource.PlayOneShot(uiSFX);
        }
    }
}