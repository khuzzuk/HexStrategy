using Midway.Model;
using Midway.Viewer;
using UnityEngine;

namespace Midway.Controller {
    public class BoardController : MonoBehaviour {
        public GameController gameController;
        public BoardView boardView;

        public void NewBoard() {
            gameController.Game.NewBoard();
            boardView.ShowBoard();
        }
    }
}