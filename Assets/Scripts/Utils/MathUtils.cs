using UnityEngine;

namespace Utils
{
    public class MathUtils
    {

        public static Vector2 LerpVector(Vector2 from, Vector2 to, float t)
        {
            from.x = Mathf.Lerp(from.x, to.x, t);
            from.y = Mathf.Lerp(from.y, to.y, t);
            return from;
        }

    }
}
