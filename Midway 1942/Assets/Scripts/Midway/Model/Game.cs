namespace Midway.Model {
    public class Game {
        public Board Board;

        public void NewBoard() {
            Board = new Board();
            Board.Draw(100, 100);
        }
    }
}