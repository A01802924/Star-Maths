using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public struct MultipleFrequencies
    {
        public double five, three, two, rest;
        public List<int> multiples;
        public MultipleFrequencies(double f, double th, double tw, double r)
        {
            five = f; three = th; two = tw; rest = r;
            multiples = new List<int>{5, 3, 2, 1};
        }
    }
    public class Domain
    {
        MultipleFrequencies mf;
        DicreteRandom randomMult;
        UniformRandom randomNum;
        public Domain
        (
            double freq5, double freq3, double freq2, double freqR,
            int domainStart, int domainEnd
        )
        {
            mf = new MultipleFrequencies(freq5, freq3, freq2, freqR);
            randomNum = new UniformRandom(domainStart, domainEnd);
            List<double> multipleFreq = new() { mf.five, mf.three, mf.two, mf.rest };
            randomMult = new DicreteRandom(multipleFreq);
        }

        public int generateNumber()
        {
            int multiple = mf.multiples[randomMult.GetRandom()];
            int number = randomNum.GetRandom();
            if (number % multiple > 0)
                number += multiple - (number % multiple);
            return number;
        }
    }
}