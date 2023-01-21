using UnityEngine;

namespace Utils
{
    public class Timer
    {
        private static float _startTime;
        public static bool IsTimeOver(ref float time)
        {
            if (_startTime <= time) _startTime = time;
            time -= Time.fixedDeltaTime;
            if (time <= 0)
            {
                time = _startTime;
                return true;
            }
            return false;
        }
    }
}