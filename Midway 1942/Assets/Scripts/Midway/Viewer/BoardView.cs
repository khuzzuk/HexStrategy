using System.Collections.Generic;
using Midway.Controller;
using Midway.Model;
using UnityEngine;

namespace Midway.Viewer {
    public class BoardView : MonoBehaviour {
        public GameController gameController;
        public Dictionary<Field, FieldView> FieldViews = new Dictionary<Field, FieldView>();

        public void ShowBoard() {
            List<Field> fields = gameController.Game.Board.Fields;
            foreach (Field field in fields) {
                FieldView.CreateField(field, this);
            }
        }
    }
}