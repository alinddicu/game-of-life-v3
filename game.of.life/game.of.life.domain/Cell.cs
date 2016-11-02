namespace game.of.life.domain
{
    using System.Linq;
    using Newtonsoft.Json;

    public class Cell
    {
        private readonly IComputeNextMutation[] _computeNextMutations =
        {
            new ShouldResurectNextMutation(),
            new ShouldStayAliveNextMutation(),
            new ShouldDieNextMutation()
        };

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

        public int X { get; }

        public int Y { get; }

        public CellState State { get; private set; }

        public CellState NextState { get; private set; }

        public bool IsAlive()
        {
            return State == CellState.Alive;
        }
        
        /*
        public void ComputeNextMutation(int aliveNeighboursCount)
        {
            if (ShouldResurect(aliveNeighboursCount))
            {
                NextState = CellState.Alive;
            }

            if (ShouldStayAlive(aliveNeighboursCount))
            {
                NextState = CellState.Alive;
            }

            if (ShouldDie(aliveNeighboursCount))
            {
                NextState = CellState.Dead;
            }
        }
        */

        public void ComputeNextMutation(int aliveNeighboursCount)
        {
            _computeNextMutations
                .FirstOrDefault(m => m.CanComputeNextMutation(this, aliveNeighboursCount))
                ?.ComputeNextMutation(this);
        }

        private interface IComputeNextMutation
        {
            bool CanComputeNextMutation(Cell cell, int aliveNeighboursCount);

            void ComputeNextMutation(Cell cell);
        }

        private class ShouldResurectNextMutation : IComputeNextMutation
        {
            public bool CanComputeNextMutation(Cell cell, int aliveNeighboursCount)
            {
                return cell.State == CellState.Dead && aliveNeighboursCount == 3;
            }

            public void ComputeNextMutation(Cell cell)
            {
                cell.NextState = CellState.Alive;
            }
        }

        private class ShouldStayAliveNextMutation : IComputeNextMutation
        {
            public bool CanComputeNextMutation(Cell cell, int aliveNeighboursCount)
            {
                return cell.State == CellState.Alive && (aliveNeighboursCount == 2 || aliveNeighboursCount == 3);
            }

            public void ComputeNextMutation(Cell cell)
            {
                cell.NextState = CellState.Alive;
            }
        }

        private class ShouldDieNextMutation : IComputeNextMutation
        {
            public bool CanComputeNextMutation(Cell cell, int aliveNeighboursCount)
            {
                return cell.State == CellState.Alive && (aliveNeighboursCount < 2 || aliveNeighboursCount >= 4);
            }

            public void ComputeNextMutation(Cell cell)
            {
                cell.NextState = CellState.Dead;
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

        private bool Equals(Cell other)
        {
            return X == other.X && Y == other.Y;
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
