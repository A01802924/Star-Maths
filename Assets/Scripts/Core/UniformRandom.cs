using UnityEngine;

namespace Assets.Scripts.Core
{
    public class UniformRandom : IRandom
    {
        private int start;
        private int end;
        public UniformRandom(int s, int e)
        {
            start = s;
            end = e;
        }
        public int GetRandom()
        {
            return Random.Range(start, end);
        }
    }
}