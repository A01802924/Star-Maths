using Assets.Scripts.Core;
using UnityEngine;
using UnityEngine.UIElements;

public class controladorOperaciones : MonoBehaviour
{
    private LevelGame game;
    private Label operacion;
    private Label res1;
    private Label res2;
    private (string operation, int result, int falso) question;

    public static controladorOperaciones instance;
    
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        game = new LevelGame(LevelFactory.BuildLevel(SessionData.SelectedWorldID, SessionData.SelectedLevelID));

        var root = GetComponent<UIDocument>().rootVisualElement;

        operacion = root.Q<Label>("Operacion");
        res1 = root.Q<Label>("Res1");
        res2 = root.Q<Label>("Res2");

        generarOperacion(Random.Range(1, 3));
    }

    public void generarOperacion(int num)
    {
        question = game.GenerateQuestion();

        operacion.text = question.operation;

        if (num == 1)
        {
            res1.text = question.result.ToString();
            res2.text = question.falso.ToString();
            SessionData.meteoritoCorrecto = 1;

        } else
        {
            res2.text = question.result.ToString();
            res1.text = question.falso.ToString();
            SessionData.meteoritoCorrecto = 2;
        }
    }
}
