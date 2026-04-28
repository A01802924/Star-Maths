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

        levelGameTutorial.clicked += () => PlayVideo("TutorialVideoTemplate.mp4"); // TODO: Level Game Tutorial Video Source
        bossGameTutorial.clicked += () => PlayVideo("TutorialVideoTemplate.mp4"); // TODO: Boss Game Tutorial Video Source
        storeTutorial.clicked += () => PlayVideo("TutorialVideoTemplate.mp4"); // TODO: Store Tutorial Video Source
        customizationTutorial.clicked += () => PlayVideo("TutorialVideoTemplate.mp4"); // TODO: Customization Tutorial Video Source
        settingsTutorial.clicked += () => PlayVideo("TutorialVideoTemplate.mp4"); // TODO: Settings Tutorial Video Source
        string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, "TutorialVideoTemplate.mp4");
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
