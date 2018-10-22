using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameGrid : MonoBehaviour
    {
        public static readonly int Size = 5;

        [SuppressMessage("ReSharper", "UnassignedField.Global", Justification = "Set by the Unity3D Editor.")]
        public GameObject FieldPrefab;
        private static IEnumerable<FieldClone> _undo;

        public static Field[] Fields
        {
            get { return FindObjectsOfType<Field>().OrderBy(f => f.Index).ToArray(); }
        }

        public static void InitUndo()
        {
            _undo = Fields.Select(field => new FieldClone { Score = field.Score, Color = field.Color, Index = field.Index }).ToList();
        }

        public static void Refill()
        {
            while (Fields.Any(f => f.IsEmpty()))
            {
                foreach (var field in Fields.Where(f => f.IsEmpty()))
                {
                    if (field.HasFieldAbove())
                    {
                        var above = field.GetFieldAbove();
                        field.Color = above.Color;
                        field.Score = above.Score;
                        above.Empty();
                    }
                    else
                    {
                        field.Reset();
                    }
                }
            }
        }

        public void Reset()
        {
            for (var i = 0; i < Mathf.Pow(Size, 2); i++)
            {
                Fields[i].Reset();
            }
        }

        public void Start()
        {
            var layout = GetComponent<GridLayoutGroup>();
            var w = Mathf.FloorToInt(GetComponent<RectTransform>().sizeDelta.x);
            var h = Mathf.FloorToInt(GetComponent<RectTransform>().sizeDelta.y);

            layout.cellSize = new Vector2Int(w / Size, h / Size);

            var parent = transform;
            for (var i = 0; i < Mathf.Pow(Size, 2); i++)
            {
                var field = Instantiate(FieldPrefab);
                field.transform.SetParent(parent);
            }
        }

        public void Undo()
        {
            if (_undo != null)
            {
                foreach (var field in Fields)
                {
                    var old = _undo.Single(f => f.Index == field.Index);
                    field.Score = old.Score;
                    field.Color = old.Color;
                }

                _undo = null;
            }
        }

        private struct FieldClone
        {
            public int Score;
            public Color Color;
            public int Index;
        }
    }
}