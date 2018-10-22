using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameOver : MonoBehaviour
    {
        private readonly string _gameOverText = "Game Over!";

        public static bool IsOver
        {
            get
            {
                return !GameGrid.Fields.Any(field => field.HasFieldOfSameColorAbove()
                                                  || field.HasFieldOfSameColorBelow()
                                                  || field.HasFieldOfSameColorLeft()
                                                  || field.HasFieldOfSameColorRight());
            }
        }

        private string Text
        {
            get { return GetComponent<Text>().text; }
            set
            {
                if (!Equals(GetComponent<Text>().text, value))
                {
                    GetComponent<Text>().text = value;
                }
            }
        }

        [UsedImplicitly]
        private void Update()
        {
            Text = IsOver ? _gameOverText : string.Empty;
        }
    }
}