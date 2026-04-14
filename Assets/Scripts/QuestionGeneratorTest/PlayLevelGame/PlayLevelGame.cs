using Assets.Scripts.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayLevelGame : MonoBehaviour
{
    private Label levelInfoLabel, questionLabel, currentLivesLabel;
    private Label currentCorrectsLabel, correctsGoalLabel;
    private Label equalsSeparatorLabel, answerLabel;
    private VisualElement inputContainer;
    private Button playNewGameButton;
    private string answer = "";
    private (string operation, int result, int falso) question;
    private LevelGame game;
    private int correctCounter = 0;
    private VisualElement root;
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
        VisualElement gameContainer = root.Q<VisualElement>("GameContainer");
        VisualElement statsContainer = root.Q<VisualElement>("StatsContainer");
        Label gameResult = root.Q<Label>("GameResult");
        Label finalLives = root.Q<Label>("FinalLives");
        Label totalQuestions = root.Q<Label>("TotalQuestionsNumber");
        Label correctQuestions = root.Q<Label>("CorrectQuestionsNumber");
        Label incorrectQuestions = root.Q<Label>("IncorrectQuestionsNumber");
        Label playTime = root.Q<Label>("PlayTimeNumber");
        if (isVictory)
            gameResult.text = "VICTORY!";
        else
            gameResult.text = "Game Over";
        finalLives.text = game.CurrentLives.ToString();
        totalQuestions.text = game.QuestionCounter.ToString();
        correctQuestions.text = (game.QuestionCounter + (game.CurrentLives - game.InitialLives)).ToString();
        incorrectQuestions.text = (game.InitialLives - game.CurrentLives).ToString();
        playTime.text = game.getPlayTimeSeconds().ToString();
        gameContainer.style.display = DisplayStyle.None;
        statsContainer.style.display = DisplayStyle.Flex;
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
