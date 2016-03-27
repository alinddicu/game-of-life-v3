namespace game.of.life.v3
{
    public class Cell
    {
        public Cell(CellState cellState = CellState.Dead)
        {
            State = cellState;
        }

        public void Mutate(int aliveNeighboursCount)
        {
            if (State == CellState.Dead && aliveNeighboursCount == 3)
            {
                State = CellState.Alive;
            }

            if (State == CellState.Alive
                && (aliveNeighboursCount < 2 || aliveNeighboursCount >= 4))
            {
                State = CellState.Dead;
            }
        }

        public CellState State { get; private set; }
    }
}
