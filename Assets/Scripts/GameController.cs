using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameController : MonoBehaviour
    {
        private readonly Position[] _floodFillDirections =
        {
            new Position(-1, 0), // up
            new Position(1, 0), // down
            new Position(0, -1), // left
            new Position(0, 1) // right
        };

        public void OnFieldClicked(int index)
        {
            if (!GameOver.IsOver)
            {
                GameGrid.InitUndo();

                Debug.Log("Interacted with Field: " + index + " => " + Util.IndexToPosition(index));
                FloodFill(index);
            }
        }

        private void FloodFill(int startIndex)
        {
            var stack = new Stack<int>(new[] { startIndex });
            var visited = new bool[(int)Mathf.Pow(GameGrid.Size, 2)];
            var output = new List<int>();
            var wantedColor = GameGrid.Fields[startIndex].Color;

            visited[startIndex] = true;

            while (stack.Count > 0)
            {
                var now = stack.Pop();
                output.Add(now);

                foreach (var direction in _floodFillDirections)
                {
                    var p = Util.IndexToPosition(now);
                    var row = p.Row + direction.Row;
                    var col = p.Col + direction.Col;
                    if (row > GameGrid.Size || row < 1 || col > GameGrid.Size || col < 1) continue;

                    var nextPosition = new Position(row, col);

                    if (nextPosition.Row <= GameGrid.Size && nextPosition.Row >= 0
                     && nextPosition.Col <= GameGrid.Size && nextPosition.Col >= 0)
                    {
                        var newIndex = nextPosition.ToIndex();

                        if (newIndex >= 0 && newIndex < GameGrid.Fields.Length && GameGrid.Fields[newIndex].Color.IsEqualTo(wantedColor))
                        {
                            if (visited[newIndex] == false)
                            {
                                visited[newIndex] = true;
                                stack.Push(newIndex);
                            }
                        }
                    }
                }
            }

            if (output.Count > 1)
            {
                var lowest = GameGrid.Fields[startIndex];

                while (lowest.HasFieldOfSameColorBelow())
                {
                    lowest = lowest.GetFieldBelow();
                }
                lowest.Score = output.Sum(i => Mathf.Max(1, GameGrid.Fields[i].Score));

                output.Where(i => i != startIndex)
                      .Select(i => GameGrid.Fields[i])
                      .ToList()
                      .ForEach(f => f.Empty());

                GameGrid.Refill();
            }
        }
    }
}