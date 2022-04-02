using System.Linq;
using Midway.Model;
using Unity.VisualScripting;
using UnityEngine;

namespace Midway.Viewer {
    public class FieldView : MonoBehaviour {
        private const float Deg1 = 30 * Mathf.Deg2Rad;
        private const float Deg2 = 90 * Mathf.Deg2Rad;
        private const float Deg3 = 150 * Mathf.Deg2Rad;
        private const float Deg4 = 210 * Mathf.Deg2Rad;
        private const float Deg5 = 270 * Mathf.Deg2Rad;
        private const float Deg6 = 330 * Mathf.Deg2Rad;
        private static readonly ushort[] Triangles = { 0, 1, 2, 0, 2, 3, 0, 3, 4, 0, 4, 5, 0, 5, 6, 0, 6, 1};
        private const float R = 50;
        private const int R2 = (int) (R * 2);
        private static readonly float BoardXLength = Mathf.Sin(Deg1) * R + R;
        private static readonly float BoardYHeight = Mathf.Cos(Deg1) * R - Mathf.Cos(Deg3) * R;
        private static readonly Color[] Colors = Enumerable.Range(0, (R2 + 1) * (R2 + 1)).Select(i => Color.white).ToArray();

        public static void CreateField(Field field, BoardView boardView) {
            GameObject fieldObject = new GameObject("Field-" + field.X + "-" + field.Y);
            fieldObject.transform.parent = boardView.transform;
            FieldView fieldView = fieldObject.AddComponent<FieldView>();
            SpriteRenderer fieldRenderer = fieldView.AddComponent<SpriteRenderer>();
            fieldRenderer.color = Color.white;

            Vector2[] vertices = Vertices();
            Texture2D texture = new Texture2D((int) (R * 2 + 1), (int) (R * 2 + 1));
            texture.SetPixels(Colors);
            texture.Apply();
            fieldRenderer.sprite = Sprite.Create(texture, new Rect(0, 0, 100, 100), Vector2.zero, 1);
            fieldRenderer.sprite.OverrideGeometry(vertices, Triangles);
            fieldObject.transform.position = BoardPosition(field.X, field.Y);
        }

        private static Vector2[] Vertices() {
            return new[] {
                new Vector2(R, R),
                new Vector2(Mathf.Sin(Deg1) * R + R, Mathf.Cos(Deg1) * R + R),
                new Vector2(Mathf.Sin(Deg2) * R + R, Mathf.Cos(Deg2) * R + R),
                new Vector2(Mathf.Sin(Deg3) * R + R, Mathf.Cos(Deg3) * R + R),
                new Vector2(Mathf.Sin(Deg4) * R + R, Mathf.Cos(Deg4) * R + R),
                new Vector2(Mathf.Sin(Deg5) * R + R, Mathf.Cos(Deg5) * R + R),
                new Vector2(Mathf.Sin(Deg6) * R + R, Mathf.Cos(Deg6) * R + R),
            };
        }

        private static Vector3 BoardPosition(uint x, uint y) {
            float vX = x * (BoardXLength + 1);
            float vY = -y * (BoardYHeight + 1) - (x % 2 == 1 ? BoardYHeight / 2 + 0.5F : 0);
            return new Vector3(vX, vY);
        }
    }
}