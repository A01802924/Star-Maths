using Assets.Scripts.Core;
using UnityEngine;
using UnityEngine.UIElements;

public class controladorOperacionesJefe : MonoBehaviour
{
    private LevelGame gamee;

    private Label operacion;
    private IntegerField input;

    private (string operation, int result, int falso) question;

    public bool respondido = false;
    public int inputRes;
    public int resultadoCorrecto;

    public static controladorOperacionesJefe instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        gamee = new LevelGame(LevelFactory.BuildLevel(1, 1));

        var root = GetComponent<UIDocument>().rootVisualElement;

        operacion = root.Q<Label>("Operacion");
        input = root.Q<IntegerField>("Input");

        input.style.display = DisplayStyle.None;

        input.RegisterCallback<KeyDownEvent>(evt =>
        {
            if (evt.keyCode == KeyCode.Return)
            {
                inputRes = input.value;
                respondido = true;

                input.value = 0;
                input.Focus();
            }
        });
    }

    public void generarOperacion()
    {
        question = gamee.GenerateQuestion();

        operacion.text = question.operation;

        resultadoCorrecto = question.result;
    }

    public void MostrarInput(bool estado)
    {
        input.style.display = estado ? DisplayStyle.Flex : DisplayStyle.None;

        if (estado)
        {
            input.Focus();
            input.value = 0;
        }
    }
}