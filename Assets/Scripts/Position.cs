using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Position
    {
        public int Row { get; private set; }
        public int Col { get; private set; }

        public Position(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public override string ToString()
        {
            return "(" + Row + "," + Col + ")";
        }

        public static Position operator +(Position a, Position b)
        {
            var row = a.Row + b.Row;
            var col = a.Col + b.Col;

            if (col > GameGrid.Size)
            {
                row += Mathf.CeilToInt(col / GameGrid.Size);
                while (col > GameGrid.Size) col -= GameGrid.Size;
            }

            if (row > GameGrid.Size && row < 1 && col > GameGrid.Size && col < 1) throw new Exception("fuck off you cant do that");

            return new Position(row, col);
        }

        public override bool Equals(object obj)
        {
            if (obj is Position)
            {
                var pos = (Position)obj;
                return pos.Row == Row && pos.Col == Col;
            }

            return false;
        }

        public override int GetHashCode()
        {
            var hashCode = 1084646500;
            hashCode = hashCode * -1521134295 + Row.GetHashCode();
            hashCode = hashCode * -1521134295 + Col.GetHashCode();
            return hashCode;
        }
    }
}