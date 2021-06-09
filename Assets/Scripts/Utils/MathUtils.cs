using UnityEngine;

namespace Utils
{
    public static class MathUtils
    {

        public static Vector2 LerpVector(Vector2 from, Vector2 to, float t)
        {
            from.x = Mathf.Lerp(from.x, to.x, t);
            from.y = Mathf.Lerp(from.y, to.y, t);
            return from;
        }

        public static Vector2 ClampX(this Vector2 current, Vector2 mins, Vector2 maxs)
        {
            current.x = Mathf.Clamp(current.x, mins.x, maxs.x);
            return current;
        }

    }
}
