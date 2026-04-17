using UnityEngine;

namespace Assets.Scripts.Core
{
    public class LevelGame : Game
    {
        public int InitialLives { get; private set; }
        public int CurrentLives { get; private set; }
        public LevelGame(Level lvl) : base(lvl)
        {
            InitialLives = 5;
            CurrentLives = 5;
            startCronometer();
        }
        public bool TryDecreaseLives()
        {
            if (CurrentLives > 0)
            {
                --CurrentLives;
                return true;
            }
            else
            {
                IsFinished = true;
                IsVictory = false;
                return false;
            }
        }
    }
}
