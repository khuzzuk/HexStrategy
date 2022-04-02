using System;
using Midway.Model;
using UnityEngine;

namespace Midway.Controller {
    public class GameController : MonoBehaviour {
        public Game Game;
        
        public BoardController boardController;

        private void Start() {
            Game = new Game();
            Game.NewBoard();
            boardController.NewBoard();
        }
    }
}