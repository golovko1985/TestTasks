using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace DateStamp
{
    [TestClass]
    public class DateStampUnitTests
    {
        [DeploymentItem(@"..\..\TestFiles")]
        [TestMethod]
        public void CompareWithExpectedDocsTest()
        {
            string dirName = Directory.GetCurrentDirectory();
            string[] testFiles = Directory.GetFiles(dirName, "*test.txt");
            DateTime date = new DateTime(2021, 10, 31);
            DateTime nextWorkDay = (Calendar.GetNextWorkingDay(date));
            DateStamp.AddToFiles(testFiles, "$$18", nextWorkDay.ToString("dd.MM.yyyy"));

            string[] expectedFiles = Directory.GetFiles(dirName, "*expected.txt");

            Array.Sort(expectedFiles, StringComparer.InvariantCulture);
            Array.Sort(testFiles, StringComparer.InvariantCulture);

            for(int i = 0; i < expectedFiles.Length; i++)
            {
                Assert.AreEqual(File.ReadAllText(expectedFiles[i]),
                    File.ReadAllText(testFiles[i]));
            }
        }
    }
}
