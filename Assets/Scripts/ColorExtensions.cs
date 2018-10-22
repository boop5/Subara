using UnityEngine;

namespace Assets.Scripts
{
    public static class ColorExtensions
    {
        public static bool IsEqualTo(this Color color1, Color color2)
        {
            return Equals(color1.r, color2.r)
                && Equals(color1.g, color2.g)
                && Equals(color1.b, color2.b)
                && Equals(color1.a, color2.a);
        }

        public static string ToName(this Color color)
        {
            if (color.IsEqualTo(Color.white)) return "white"; // empty color.
            if (color.IsEqualTo(Color.red)) return "red";
            if (color.IsEqualTo(Color.green)) return "green";
            if (color.IsEqualTo(Color.blue)) return "blue";
            if (color.IsEqualTo(Color.yellow)) return "yellow";
            return "error " + color;
        }
    }
}