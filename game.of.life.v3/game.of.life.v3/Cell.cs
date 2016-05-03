namespace game.of.life.v3
{
    using System.Collections.Generic;

    public class Cell
    {
        public Cell(int x, int y, CellState cellState = CellState.Dead)
        {
            State = cellState;
            NextState = CellState.Unknown;
            X = x;
            Y = y;
        }

        public CellState State { get; private set; }

        public CellState NextState { get; private set; }

        public int X { get; private set; }

        public int Y { get; private set; }

        public bool IsAlive
        {
            get
            {
                return State == CellState.Alive;
            }
        }

        public void ComputeMutation(int aliveNeighboursCount)
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

        private bool Equals(Cell other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;

            if (ReferenceEquals(this, obj)) return true;

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
            return "(" + X + "," + Y + ") : " + State;
        }

        public void CompleteMutation()
        {
            State = NextState;
            NextState = CellState.Unknown;
        }
    }
}
