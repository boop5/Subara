using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ScoreBoard : MonoBehaviour
    {
        private static string Format(decimal num)
        {
            var result = num.ToString(CultureInfo.InvariantCulture);

            if (num > 999999999 || num < -999999999)
            {
                result = num.ToString("0,,,.###B", CultureInfo.InvariantCulture);
            }
            else if (num > 999999 || num < -999999)
            {
                result = num.ToString("0,,.##M", CultureInfo.InvariantCulture);
            }
            else if (num > 999 || num < -999)
            {
                result = num.ToString("0,.#K", CultureInfo.InvariantCulture);
            }

            return result;
        }

        public void Update()
        {
            var score = GameGrid.Fields.Sum(f => f.Score);
            var formattedScore = Format(score);

            GetComponentInChildren<Text>().text = formattedScore + " points";
        }
    }
}