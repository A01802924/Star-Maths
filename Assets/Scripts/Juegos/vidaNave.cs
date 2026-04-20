using Assets.Scripts.Core;
using UnityEngine;
using UnityEngine.UIElements;

public class vidaNave : MonoBehaviour
{
    public int vidas = 3;
    public int correctas = 0;
    private LevelGame game;

    public static vidaNave instance;

    private MostrarMenu menuFinal;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        if(menuFinal == null)
        {
            menuFinal = FindAnyObjectByType<MostrarMenu>();
        }
    }

    void Start()
    {
        game = new LevelGame(LevelFactory.BuildLevel(SessionData.SelectedWorldID, SessionData.SelectedLevelID));
    }

    public void Perder()
    {
        Destroy(gameObject);
        AudioManager.Instance.PlayNewTrack(AudioClipSet.DefeatBackgroundMusic);
        MenuPausa.instance.respuestas.style.display = DisplayStyle.None;
        MenuPausa.instance.HUD.style.display = DisplayStyle.None;
        MenuPausa.instance.infoHUD.style.display = DisplayStyle.None;
        menuFinal.MuestraGameOver();
    }

    public void Ganar(int x)
    {
        Destroy(gameObject);
        AudioManager.Instance.SetTrackStartTime(26f);
        AudioManager.Instance.PlayNewTrack(AudioClipSet.VictoryBackgrounMusic);
        MenuPausa.instance.respuestas.style.display = DisplayStyle.None;
        MenuPausa.instance.HUD.style.display = DisplayStyle.None;
        MenuPausa.instance.infoHUD.style.display = DisplayStyle.None;

        StartCoroutine(MostrarMenu.instance.MuestraMenu((float)game.getPlayTimeSeconds(), vidas, 3, x + (3 - vidas), x, 3 - vidas));
    }
}