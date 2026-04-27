using System.Collections.Generic;

namespace Assets.Scripts.Core
{
    public class Level
    {
        private List<Operation> operations;
        private DicreteRandom operationRandom;
        public int CorrectAnswersGoal { get; private set; }
        public int WorldID { get; private set; }
        public int LevelID { get; private set; }
        public Level(int wID, int lvlID, List<Operation> ops, int nOps)
        {
            WorldID = wID;
            LevelID = lvlID;
            CorrectAnswersGoal = nOps;
            operations = ops;
            List<double> opWeights = new List<double>();
            foreach (Operation op in ops)
            {
                opWeights.Add(op.Frequency);
            }
            operationRandom = new DicreteRandom(opWeights);
        }
        public Operation GetRandomOperation()
        {
            return operations[operationRandom.GetRandom()];
        }
    }
}
