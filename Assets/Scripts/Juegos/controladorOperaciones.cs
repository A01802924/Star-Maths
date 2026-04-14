using Assets.Scripts.Core;
using UnityEngine;
using UnityEngine.UIElements;

public class controladorOperaciones : MonoBehaviour
{
    private LevelGame game;
    private Label operacion;
    private Label res1;
    private Label res2;
    private (string operation, int result) question;
    
    void Start()
    {
        game = new LevelGame(LevelFactory.BuildLevel(3, 1));

        var root = GetComponent<UIDocument>().rootVisualElement;

        operacion = root.Q<Label>("Operacion");
        res1 = root.Q<Label>("Res1");
        res2 = root.Q<Label>("Res2");

        generarOperacion(Random.Range(1, 3));
    }

    void generarOperacion(int num)
    {
        question = game.GenerateQuestion();

        operacion.text = question.operation;

        if (num == 1)
        {
            res1.text = question.result.ToString();
            // res2.text = question.false.ToString();
            // m1.valor = true;
            // m2.valor = false;
        } else
        {
            res2.text = question.result.ToString();
            // res1.text = question.false.ToString();
            // m2.valor = true;
            // m1.valor = false;
        }
    }
}
