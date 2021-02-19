using UnityEngine;

namespace Chess
{
    public static class Math
    {
        public static float Round(float value, int digits)
        {
            float mult = Mathf.Pow(10.0f, (float)digits);
            return Mathf.Round(value * mult) / mult;
        }
        public static Vector2 RoundV(Vector2 value, int digits)
        {
            float mult = Mathf.Pow(10.0f, (float)digits);

            return new Vector2(Mathf.Round(value.x * mult) / mult, Mathf.Round(value.y * mult) / mult);
        }
    }
}
