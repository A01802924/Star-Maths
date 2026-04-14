using Assets.Scripts.Core;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayLevelGamePrueba : MonoBehaviour
{
    private Label levelInfoLabel, questionLabel, currentLivesLabel;
    private Label currentCorrectsLabel, correctsGoalLabel;
    private Label equalsSeparatorLabel, answerLabel;
    private VisualElement inputContainer;
    private Button playNewGameButton;
    private string answer = "";
    private (string operation, int result) question;
    private LevelGame game;
    private int correctCounter = 0;
    private VisualElement root;


    //Añandiendo para la prueba
    [SerializeField] private MostrarMenu menuFinal;



    void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        game = new LevelGame(LevelFactory.BuildLevel(SessionData.SelectedWorldID, SessionData.SelectedLevelID));

        levelInfoLabel = root.Q<Label>("LevelInfo");
        levelInfoLabel.text = $"World {game.Level.WorldID}. Level {game.Level.LevelID}";

        questionLabel = root.Q<Label>("Question");

        equalsSeparatorLabel = root.Q<Label>("EqualsSeparator");
        answerLabel = root.Q<Label>("Answer");

        equalsSeparatorLabel.style.display = DisplayStyle.None;
        answerLabel.style.display = DisplayStyle.None;

        currentLivesLabel = root.Q<Label>("CurrentLives");
        currentLivesLabel.text = game.CurrentLives.ToString();

        currentCorrectsLabel = root.Q<Label>("CurrentCorrects");
        currentCorrectsLabel.text = correctCounter.ToString();

        correctsGoalLabel = root.Q<Label>("CorrectsGoal");
        correctsGoalLabel.text = game.Level.CorrectAnswersGoal.ToString();

        inputContainer = root.Q<VisualElement>("InputContainer");
        inputContainer.RegisterCallback<ClickEvent>(TryInput);

        playNewGameButton = root.Q<Button>("NewGameButton");
        playNewGameButton.RegisterCallback<ClickEvent>(NewGame);


        //Añadiendo para prueba
        if(menuFinal == null)
        {
            menuFinal = FindAnyObjectByType<MostrarMenu>();
        }
        //menuFinal = GetComponent<MostrarMenu>();

        var datos = DatosPartida.instance;
        
        DisplayNewQuestion();
    }

    void NewGame(ClickEvent evt)
    {
        SessionData.ClearGameData();
        SceneManager.LoadScene("SelectLevel");
    }

    void TryInput(ClickEvent evt)
    {
        print("Container clicked!");
        VisualElement clickedElement = evt.target as VisualElement;
        if (clickedElement == inputContainer)
        {
            return;
        }
        int index = inputContainer.IndexOf(clickedElement);
        print("Selected item index: " + index);
        UpdateAnswer(index);
    }

    void UpdateAnswer(int inputIndex)
    {
        if (answer == "0" && inputIndex != 0) answer = "";
        else if (answer != "0" && inputIndex == 0) answer += "0";
        if (inputIndex > 0 && inputIndex < 9) answer += inputIndex.ToString();
        else if (inputIndex == 10) answer += "9";
        else if (inputIndex == 9 && answer != "") answer = answer[..^1];
        else if (inputIndex == 11 && answer != "") AnswerQuestion(answer);

        if (answer != "")
        {
            answerLabel.style.display = DisplayStyle.Flex;
            equalsSeparatorLabel.style.display = DisplayStyle.Flex;
            answerLabel.text = answer;
        }
        else
        {
            answerLabel.text = "";
            answerLabel.style.display = DisplayStyle.None;
            equalsSeparatorLabel.style.display = DisplayStyle.None;
        }
    }

    void AnswerQuestion(string answer)
    {
        int numericAnswer = int.Parse(answer);
        if (numericAnswer == question.result)
        {
            currentCorrectsLabel.text = (game.QuestionCounter + (game.CurrentLives - game.InitialLives)).ToString();
        } else
        {
            game.DecreaseLives();
            currentLivesLabel.text = game.CurrentLives.ToString();
        }
        if (game.CurrentLives == 0)
            FinishGame(false);
        else if (game.QuestionCounter + (game.CurrentLives - game.InitialLives) == game.Level.CorrectAnswersGoal)
            FinishGame(true);
        else
            DisplayNewQuestion();
    }

    public void FinishGame(bool isVictory)
    {
        game.stopCronometer();

        double time = game.getPlayTimeSeconds();
        float timeF = (float)time;
        int vidas = game.CurrentLives;
        int vidasI = game.InitialLives;
        int numpreguntas = game.QuestionCounter;
        int preguntasC = numpreguntas + (vidas - vidasI);
        int preguntasI = vidasI - vidas;
        // float ratio = (float)preguntasC / numpreguntas;
        //int puntos =  Mathf.RoundToInt(ratio* 10000000 - ((vidasI - vidas) * 100) + 10000 / (int)game.getPlayTimeSeconds());

        if (isVictory)
        {
            StartCoroutine(MostrarMenu.instance.MuestraMenu(timeF, vidas, vidasI, numpreguntas, preguntasC, preguntasI));    
        }
        else
        {
            menuFinal.MuestraGameOver();
        }

        // datos.vidasIniciales = game.InitialLives;
        // DatosPartida.instance.vidas = game.CurrentLives;
        // DatosPartida.instance.numPreguntas = game.Level.CorrectAnswersGoal;
        // DatosPartida.instance.numPreguntasCorrectas = game.Level.CorrectAnswersGoal + (game.CurrentLives - game.InitialLives);
        // DatosPartida.instance.numPreguntasIncorrectas = game.InitialLives - game.CurrentLives;
        // DatosPartida.instance.time = (float)game.getPlayTimeSeconds();

        // if (isVictory)
        // {
        //     StartCoroutine(MostrarMenu.MuestraMenu(DatosPartida.instance.CalcularPuntaje(),))
        // }
    }

    public void DisplayNewQuestion()
    {
        question = game.GenerateQuestion();
        questionLabel.text = question.operation;
        answerLabel.style.display = DisplayStyle.None;
        equalsSeparatorLabel.style.display = DisplayStyle.None;
        answer = "";
    }
}
