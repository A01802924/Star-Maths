using Assets.Scripts.Core;
using UnityEngine;
using UnityEngine.UIElements;

public class controladorOperacionesJefe : MonoBehaviour
{
    private LevelGame game;
    private Label operacion;
    private IntegerField input;
    private (string operation, int result, int falso) question;

    private int num;

    public static controladorOperacionesJefe instance;
    
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        game = new LevelGame(LevelFactory.BuildLevel(SessionData.SelectedWorldID, SessionData.SelectedLevelID));

        var root = GetComponent<UIDocument>().rootVisualElement;

        operacion = root.Q<Label>("Operacion");
        input = root.Q<IntegerField>("Input");

        input.Focus();

        input.RegisterCallback<KeyDownEvent>(evt =>
        {
            if (evt.keyCode == KeyCode.Return)
            {
                num = input.value;

                input.value = 0;
                input.Focus();
            }
        });

        generarOperacion(Random.Range(1, 3));
    }

    public void generarOperacion(int num)
    {
        question = game.GenerateQuestion();

        operacion.text = question.operation;
    }
}
