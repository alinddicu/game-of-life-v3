namespace game.of.life.tools.test
{
    using domain;
    using NFluent;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ObjectToJsonFileConverterTest
    {
        [TestMethod]
        public void WhenLoadThenObjectIsTheSame()
        {
            var fileSystemMock = new Mock<IFileSystem>();
            fileSystemMock.Setup(o => o.DirectoryExists(It.IsAny<string>())).Returns(true);
            fileSystemMock.Setup(o => o.FileExists(It.IsAny<string>())).Returns(true);
            const string oneCellGrid = @"[{""X"":5,""Y"":3,""State"":1,""NextState"":2}]";
            fileSystemMock.Setup(o => o.FileReadAllText(It.IsAny<string>())).Returns(oneCellGrid);

            var loader = new ObjectToJsonFileConverter(fileSystemMock.Object, string.Empty);

            var cell = loader.Load<IEnumerable<Cell>>().Single();

            Check.That(cell.X).IsEqualTo(5);
            Check.That(cell.Y).IsEqualTo(3);
            Check.That(cell.NextState).IsEqualTo(CellState.Unknown);
            Check.That(cell.State).IsEqualTo(CellState.Alive);
        }
    }
}
