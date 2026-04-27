using System.Diagnostics;

namespace Assets.Scripts.Core
{
    public abstract class Game
    {
        public bool IsVictory { get; protected set; }
        public bool IsFinished { get; protected set; }
        public int QuestionCounter { get; protected set; }
        protected Stopwatch cronometer;
        public Level Level { get; protected set; }
        protected Game(Level lvl)
        {
            IsVictory = true;
            IsFinished = false;
            QuestionCounter = 0;
            Level = lvl;
            cronometer = new Stopwatch();
        }
        public void startCronometer()
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
        public (string, int, int) GenerateQuestion()
        {
            ++QuestionCounter;
            return Level.GetRandomOperation().GenerateOperation();
        }
    }
}
