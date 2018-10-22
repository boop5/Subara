using UnityEngine;

namespace Assets.Scripts
{
    public static class FieldExtensions
    {
        public static void Empty(this Field field)
        {
            field.Color = Color.white;
        }

        public static bool IsEmpty(this Field field)
        {
            return field.Color.IsEqualTo(Color.white);
        }

        #region AdjacentFields

        #region Left

        public static Field GetFieldLeft(this Field field)
        {
            return GameGrid.Fields[field.IndexLeft()];
        }

        public static bool HasFieldLeft(this Field field)
        {
            return Util.IndexToXPosition(field.Index) > 1;
        }

        public static bool HasFieldOfSameColorLeft(this Field field)
        {
            return field.HasFieldLeft() && field.Color.IsEqualTo(field.GetFieldLeft().Color);
        }

        private static int IndexLeft(this Field field)
        {
            return field.Index - 1;
        }

        #endregion

        #region TopLeft

        public static int IndexTopLeft(this Field field)
        {
            return field.Index - GameGrid.Size - 1;
        }

        public static Field GetFieldTopLeft(this Field field)
        {
            return GameGrid.Fields[field.IndexTopLeft()];
        }

        public static bool HasFieldTopLeft(this Field field)
        {
            return field.IndexTopLeft() >= 0 && field.IndexTopLeft() < Mathf.Pow(GameGrid.Size, 2);
        }

        public static bool HasFieldOfSameColorTopLeft(this Field field)
        {
            return field.HasFieldTopLeft() && field.Color.IsEqualTo(field.GetFieldTopLeft().Color);
        }

        #endregion

        #region Top / Above

        private static int IndexAbove(this Field field)
        {
            return field.Index - GameGrid.Size;
        }

        public static Field GetFieldAbove(this Field field)
        {
            return GameGrid.Fields[field.IndexAbove()];
        }

        public static bool HasFieldAbove(this Field field)
        {
            return field.IndexAbove() >= 0;
        }

        public static bool HasFieldOfSameColorAbove(this Field field)
        {
            return field.HasFieldAbove() && field.Color.IsEqualTo(field.GetFieldAbove().Color);
        }

        #endregion

        #region TopRight

        public static int IndexTopRight(this Field field)
        {
            return field.Index - GameGrid.Size + 1;
        }

        public static Field GetFieldTopRight(this Field field)
        {
            return GameGrid.Fields[field.IndexTopRight()];
        }

        public static bool HasFieldTopRight(this Field field)
        {
            return field.IndexTopRight() >= 0 && field.IndexTopRight() < Mathf.Pow(GameGrid.Size, 2);
        }

        public static bool HasFieldOfSameColorTopRight(this Field field)
        {
            return field.HasFieldTopRight() && field.Color.IsEqualTo(field.GetFieldTopRight().Color);
        }

        #endregion

        #region Right

        public static bool HasFieldOfSameColorRight(this Field field)
        {
            return field.HasFieldRight() && field.Color.IsEqualTo(field.GetFieldRight().Color);
        }

        public static Field GetFieldRight(this Field field)
        {
            return GameGrid.Fields[field.IndexRight()];
        }

        public static bool HasFieldRight(this Field field)
        {
            return Util.IndexToXPosition(field.Index) < GameGrid.Size;
        }

        private static int IndexRight(this Field field)
        {
            return field.Index + 1;
        }

        #endregion

        #region BottomRight

        public static int IndexBottomRight(this Field field)
        {
            return field.Index + GameGrid.Size + 1;
        }

        public static Field GetFieldBottomRight(this Field field)
        {
            return GameGrid.Fields[field.IndexBottomRight()];
        }

        public static bool HasFieldBottomRight(this Field field)
        {
            return field.IndexBottomRight() >= 0 && field.IndexBottomRight() < Mathf.Pow(GameGrid.Size, 2);
        }

        public static bool HasFieldOfSameColorBottomRight(this Field field)
        {
            return field.HasFieldBottomRight() && field.Color.IsEqualTo(field.GetFieldBottomRight().Color);
        }

        #endregion

        #region Bottom / Below

        private static int IndexBelow(this Field field)
        {
            return field.Index + GameGrid.Size;
        }

        public static Field GetFieldBelow(this Field field)
        {
            return GameGrid.Fields[field.IndexBelow()];
        }

        public static bool HasFieldBelow(this Field field)
        {
            return field.IndexBelow() < Mathf.Pow(GameGrid.Size, 2);
        }

        public static bool HasFieldOfSameColorBelow(this Field field)
        {
            return field.HasFieldBelow() && field.Color.IsEqualTo(field.GetFieldBelow().Color);
        }

        #endregion

        #region BottomLeft

        public static int IndexBottomLeft(this Field field)
        {
            return field.Index + GameGrid.Size - 1;
        }

        public static Field GetFieldBottomLeft(this Field field)
        {
            return GameGrid.Fields[field.IndexBottomLeft()];
        }

        public static bool HasFieldBottomLeft(this Field field)
        {
            return field.IndexBottomLeft() >= 0 && field.IndexBottomLeft() < Mathf.Pow(GameGrid.Size, 2);
        }

        public static bool HasFieldOfSameColorBottomLeft(this Field field)
        {
            return field.HasFieldBottomLeft() && field.Color.IsEqualTo(field.GetFieldBottomLeft().Color);
        }

        #endregion

        #endregion
    }
}