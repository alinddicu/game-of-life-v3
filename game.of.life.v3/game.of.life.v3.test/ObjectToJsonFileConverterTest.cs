namespace game.of.life.v3.test
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using NFluent;

    [TestClass]
    public class ObjectToJsonFileConverterTest
    {
        [TestMethod]
        [Ignore]
        public void WhenLoadThenObjectIsTheSame()
        {
            var fileSystemMock = new Mock<IFileSystem>();
            fileSystemMock.Setup(o => o.DirectoryExists(It.IsAny<string>())).Returns(true);
            fileSystemMock.Setup(o => o.FileExists(It.IsAny<string>())).Returns(true);
            const string oneCellGrid = @"[{""State"":1,""NextState"":2,""X"":5,""Y"":3}]";
            fileSystemMock.Setup(o => o.FileReadAllText(It.IsAny<string>())).Returns(oneCellGrid);

            var loader = new ObjectToJsonFileConverter(fileSystemMock.Object, string.Empty);

            var cell = loader.Load<IEnumerable<Cell>>("").Single();

            Check.That(cell.X).IsEqualTo(5);
            Check.That(cell.Y).IsEqualTo(3);
            Check.That(cell.State).IsEqualTo(CellState.Alive);
            Check.That(cell.NextState).IsEqualTo(CellState.Unknown);
        }

        [TestMethod]
        [DeploymentItem("Resources/cell.json", "Resources")]
        public void WhenSaveThenJsonIsCorrect()
        {
            var loader = new ObjectToJsonFileConverter(new FileSystem(), "Resources");

            loader.Save("cell", new Cell(0, 1));

            var jsonCell = File.ReadAllText("Resources/cell.json");

            Check.That(jsonCell).IsEqualTo(@"{""State"":0,""NextState"":2,""X"":0,""Y"":1}");
        }
    }
}
