namespace game.of.life.domain
{
    using Newtonsoft.Json;

    public class Cell
    {
        public Cell(int x, int y, CellState state = CellState.Dead)
            : this(x, y, state, CellState.Unknown)
        {
        }

        [JsonConstructor]
        public Cell(int x, int y, CellState state, CellState nextState)
        {
            X = x;
            Y = y;
            State = state;
            NextState = nextState;
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        public CellState State { get; private set; }

        public CellState NextState { get; private set; }

        public bool IsAlive()
        {
            return State == CellState.Alive;
        }

        public void ComputeNextMutation(int aliveNeighboursCount)
        {
            if (State == CellState.Dead && aliveNeighboursCount == 3)
            {
                NextState = CellState.Alive;
            }

            if (State == CellState.Alive && (aliveNeighboursCount == 2 || aliveNeighboursCount == 3))
            {
                NextState = CellState.Alive;
            }

            if (State == CellState.Alive
                && (aliveNeighboursCount < 2 || aliveNeighboursCount >= 4))
            {
                NextState = CellState.Dead;
            }
        }

        public void CompleteMutation()
        {
            if (NextState == CellState.Unknown)
            {
                return;
            }

            State = NextState;
            NextState = CellState.Unknown;
        }

        private bool Equals(Cell other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((Cell)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}
