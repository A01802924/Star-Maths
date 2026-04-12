using System.Diagnostics;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public abstract class Game
    {
        protected bool isVictory;
        protected bool isFinished;
        public int QuestionCounter { get; protected set; }
        protected Stopwatch cronometer;
        public Level Level { get; protected set; }
        protected Game(Level lvl)
        {
            isVictory = false;
            isFinished = false;
            QuestionCounter = 0;
            Level = lvl;
            cronometer = new Stopwatch();
        }

        protected void startCronometer()
        {
            cronometer.Start();
        }

        public void stopCronometer()
        {
            cronometer.Stop();
        }
        public double getPlayTimeSeconds()
        {
            return cronometer.Elapsed.TotalSeconds;
        }

        public (string, int) GenerateQuestion()
        {
            ++QuestionCounter;
            return Level.GetRandomOperation().GenerateOperation();
        }

    }   
}
