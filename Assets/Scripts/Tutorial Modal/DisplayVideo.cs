using Assets.Scripts.Core;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;


public class DisplayVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private RenderTexture videoTexture;
    private Button levelGameTutorial;
    private Button bossGameTutorial;
    private Button storeTutorial;
    private Button customizationTutorial;
    private Button settingsTutorial;
    private VisualElement videoContainer;
    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        levelGameTutorial = root.Q<Button>("LevelGameButton");
        bossGameTutorial = root.Q<Button>("FinalBossButton");
        storeTutorial = root.Q<Button>("StoreButton");
        customizationTutorial = root.Q<Button>("CustomizationButton");
        settingsTutorial = root.Q<Button>("SettingsButton");

        videoContainer = root.Q<VisualElement>("VideoContainer");
        videoContainer.style.backgroundImage = new StyleBackground(Background.FromRenderTexture(videoTexture));
        videoContainer.style.unityBackgroundImageTintColor = Color.white;

        levelGameTutorial.clicked += () => PlayVideo("LevelGameTutorial.mp4");
        bossGameTutorial.clicked += () => PlayVideo("BossGameTutorial.mp4"); // TODO: Edit Boss Game Tutorial Video Source
        storeTutorial.clicked += () => PlayVideo("StoreTutorial.mp4"); // TODO: Edit Store Tutorial Video Source
        customizationTutorial.clicked += () => PlayVideo("CustomizationTutorial.mp4"); // TODO: Edit Customization Tutorial Video Source
        settingsTutorial.clicked += () => PlayVideo("SettingsTutorial.mp4");
        string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, "LevelGameTutorial.mp4");
        videoPlayer.url = videoPath;
        videoPlayer.Play();
    }

    private void PlayVideo(string filename)
    {
        AudioManager.Instance.PlayUISFX(AudioClipSet.ClickNewTab);
        string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, filename);
        videoPlayer.url = videoPath;
        videoPlayer.Play();
    }
}
