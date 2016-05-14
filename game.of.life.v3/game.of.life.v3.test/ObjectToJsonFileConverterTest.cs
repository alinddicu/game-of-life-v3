namespace game.of.life.v3.test
{
    using Newtonsoft.Json;
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
        public void WhenLoadThenObjectIsTheSame()
        {
            var fileSystemMock = new Mock<IFileSystem>();
            fileSystemMock.Setup(o => o.DirectoryExists(It.IsAny<string>())).Returns(true);
            fileSystemMock.Setup(o => o.FileExists(It.IsAny<string>())).Returns(true);
            const string oneCellGrid = @"[{""X"":5,""Y"":3,""State"":1,""NextState"":2}]";
            fileSystemMock.Setup(o => o.FileReadAllText(It.IsAny<string>())).Returns(oneCellGrid);

            var loader = new ObjectToJsonFileConverter(fileSystemMock.Object, string.Empty);

            var cell = loader.Load<IEnumerable<Cell>>("").Single();

            Check.That(cell.X).IsEqualTo(5);
            Check.That(cell.Y).IsEqualTo(3);
            Check.That(cell.NextState).IsEqualTo(CellState.Unknown);
            Check.That(cell.State).IsEqualTo(CellState.Alive);
        }

        [TestMethod]
        [DeploymentItem("Resources/cell.json", "Resources")]
        public void WhenSaveThenJsonIsCorrect()
        {
            var loader = new ObjectToJsonFileConverter(new FileSystem(), "Resources");

            loader.Save("cell", new Cell(0, 1));

            var jsonCell = File.ReadAllText("Resources/cell.json");

            Check.That(jsonCell).IsEqualTo(@"{""X"":0,""Y"":1,""State"":0,""NextState"":2}");
        }

        [TestMethod]
        public void JsonDeserialzeTest()
        {
            var cell = JsonConvert.DeserializeObject<Cell>(@"{""X"":5,""Y"":3,""NextState"":1,""State"":1}");

            Check.That(cell.State).IsEqualTo(CellState.Alive);
            Check.That(cell.NextState).IsEqualTo(CellState.Alive);
        }
    }
}
