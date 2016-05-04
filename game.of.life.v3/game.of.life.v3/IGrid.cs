﻿namespace game.of.life.v3
{
    using System.Collections.Generic;

    public interface IGrid
    {
        IEnumerable<Cell> Cells { get; }

        void AddCells(params Cell[] cells);

        Cell Get(int x, int y);

        void Discover();

        IEnumerable<Cell> GetNeighbours(Cell cell);

        void Clean();

        void Reset();
    }
}