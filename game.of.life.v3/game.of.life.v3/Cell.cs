namespace game.of.life.v3
{
    public class Cell
    {
        public void Mutate(int aliveNeighboursCount)
        {
            if (aliveNeighboursCount == 2 || aliveNeighboursCount == 3)
            {
                State = CellState.Alive;
            }
        }

        public CellState State { get; private set; }
    }
}
