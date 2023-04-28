using TestHelpers.Attributes;
using TestHelpers.Common;
using TestHelpers.IO;

namespace Tests
{
    [TargetAssembly("Task1")]
    public class Tests : TestFixtureBase<Tests>
    {
        private Type subjectType;

        [SetUp]
        public void Setup() 
        {
            subjectType = ReflectionHelper.FindType("Program");
        }

        [Test]
        [TestCase(10, 20, TestName = "Вычисление площади прямоугольника 10 х 20")]
        public void SquareOf10By20ShouldBe200(int width, int height)
        {
            InputPlanner planner = new InputPlanner();
            planner.ScheduleLine(width.ToString());
            planner.ScheduleLine(height.ToString());
            using var consoleMock = new ConsoleMock();
            consoleMock.Schedule(planner);

            ReflectionHelper.ExecuteMain(subjectType);
            var expected = width * height;
            var actual = consoleMock.ReadOutputLines().Last();
            Assert.AreEqual(expected.ToString(), actual, $"Площадь прямоугольника {width} x {height}. Ожидалось {expected}, но было {actual}");
        }
    }
}