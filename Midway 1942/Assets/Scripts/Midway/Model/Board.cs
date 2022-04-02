using System.Collections.Generic;

namespace Midway.Model {
    public class Board {
        public List<Field> Fields = new List<Field>();

        public void Draw(uint xSize, uint ySize) {
            for (uint i = 0; i < ySize; i++) {
                for (uint j = 0; j < xSize; j++) {
                    Fields.Add(new Field{X = j, Y = i});
                }
            }
        }
    }
}