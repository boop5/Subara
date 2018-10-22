using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Field : MonoBehaviour
    {
        private static int _globalIndex;
        private Dictionary<string, Sprite> _tiles;

        public Color Color
        {
            get
            {
                var img = GetComponent<Image>();
                return img.color;
            }
            set
            {
                var img = GetComponent<Image>();
                if (!Equals(img.color, value))
                {
                    img.color = value;
                }
            }
        }

        public int Index { get; private set; }

        public int Score { get; set; }

        public Sprite Sprite
        {
            get { return GetComponent<Image>().sprite; }
            private set
            {
                if (!Equals(GetComponent<Image>().sprite, value))
                {
                    GetComponent<Image>().sprite = value;
                }
            }
        }

        private Text Text
        {
            get
            {
                return GetComponentInChildren<Text>();
            }
        }

        public void Reset()
        {
            Color = Util.RandomColor();
            Score = 0;
        }

        public override string ToString()
        {
            return "Field " + Util.IndexToPosition(Index) + " (i:" + Index + ")";
        }

        public void Update()
        {
            UpdateTile();
            UpdateText();
            UpdateAlpha();
        }

        private void UpdateAlpha()
        {
            var alpha = 1f;
            if (GameOver.IsOver)
            {
                alpha = 0.5f;
            }

            if (!Color.a.Equals(alpha))
            {
                var color = Color;
                color.a = alpha;
                Color = color;
            }
            if (!Text.color.a.Equals(alpha))
            {
                var color = Text.color;
                color.a = alpha;
                Text.color = color;
            }
        }

        public string GetTileLayout()
        {
            var n1 = this.HasFieldOfSameColorLeft() ? "0" : "1";
            var n2 = this.HasFieldOfSameColorTopLeft() && (this.HasFieldOfSameColorAbove() || this.HasFieldOfSameColorLeft()) ? "0" : "1";
            var n3 = this.HasFieldOfSameColorAbove() ? "0" : "1";
            var n4 = this.HasFieldOfSameColorTopRight() && (this.HasFieldOfSameColorAbove() || this.HasFieldOfSameColorRight()) ? "0" : "1";
            var n5 = this.HasFieldOfSameColorRight() ? "0" : "1";

            var n6 = this.HasFieldOfSameColorBottomRight() && (this.HasFieldOfSameColorBelow() || this.HasFieldOfSameColorRight()) ? "0" : "1";

            var n7 = this.HasFieldOfSameColorBelow() ? "0" : "1";
            var n8 = this.HasFieldOfSameColorBottomLeft() && (this.HasFieldOfSameColorBelow() || this.HasFieldOfSameColorLeft()) ? "0" : "1";

            var layout = n1 + n2 + n3 + n4 + n5 + n6 + n7 + n8;

            return layout;
        }

        public void Start()
        {
            Index = _globalIndex++;
            name = "Field " + Index;
            transform.localScale = Vector3.one;

            var tiles = Resources.LoadAll<Sprite>("Tiles/").ToList();
            _tiles = tiles.ToDictionary(t => t.name, t => t);

            Reset();
            GetComponent<Button>().onClick.AddListener(() => { FindObjectOfType<GameController>().OnFieldClicked(Index); });
        }

        private void UpdateText()
        {
            var text = string.Empty;

            if (Score > 0)
            {
                text = Score.ToString();
            }

            Text.text = text;
        }

        private void UpdateTile()
        {
            var layout = GetTileLayout();
            var tile = _tiles[layout];
            Sprite = tile;
        }
    }
}