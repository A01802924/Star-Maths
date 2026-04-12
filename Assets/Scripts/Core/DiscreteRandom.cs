using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class DicreteRandom : IRandom
    {
        private List<double> weights;
        private double totalWeight;
        public DicreteRandom(List<double> w)
        {
            weights = w;
            totalWeight = 0;
            foreach (double weight in weights) {
                totalWeight += weight;
            }
        }
        public int GetRandom()
        {
            double randomValue = Random.Range(0f, (float)totalWeight);
            double currentSum = 0;
            for (int i = 0; i < weights.Count; ++i)
            {
                currentSum += weights[i];
                if (randomValue <= currentSum)
                    return i;
            }
            return weights.Count - 1;
        }
    }
}
