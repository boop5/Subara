using UnityEngine;

namespace Assets.Scripts
{
    public static class Util
    {
        public static Position IndexToPosition(int index)
        {
            var x = IndexToXPosition(index);
            var y = IndexToYPosition(index);

            return new Position(y, x);
        }

        public static int IndexToXPosition(int index)
        {
            return Mathf.CeilToInt(index % GameGrid.Size) + 1;
        }

        public static int IndexToYPosition(int index)
        {
            return Mathf.CeilToInt(index / GameGrid.Size) + 1;
        }

        public static Color RandomColor(int paletteSize = 4)
        {
            if (paletteSize < 2) throw new System.ArgumentException("You need at least 2 colors.", "paletteSize");
            if (paletteSize > 7) throw new System.ArgumentException("Current supported maximum of colors is 7.", "paletteSize");

            var color = Color.white;
            switch (Random.Range(0, paletteSize))
            {
                case 0:
                    color = Color.red;
                    break;
                case 1:
                    color = Color.green;
                    break;
                case 2:
                    color = Color.blue;
                    break;
                case 3:
                    color = Color.yellow;
                    break;
                case 4:
                    color = Color.cyan;
                    break;
                case 5:
                    color = Color.magenta;
                    break;
                case 6:
                    color = Color.gray;
                    break;
            }

            return color;
        }
    }
}