namespace game.of.life.domain
{
    using System.Collections.Generic;

    public interface IGrid
    {
        IEnumerable<Cell> Cells { get; }

        void AddCells(params Cell[] cells);
        
        void Discover();

        IEnumerable<Cell> GetNeighbours(Cell cell);

        void Clean();

        void Reset();
    }
}