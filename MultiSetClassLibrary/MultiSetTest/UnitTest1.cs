using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MultiSetClassLibrary;
using Assert = NUnit.Framework.Assert;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow(8, 8)]
        [DataRow(80, 80)]
        public void TestCount(int intCount, int expected)
        {
            var list = new List<int>();
            for (int i = 0; i < intCount; i++)
            {
                list.Add('a');
            }
            var ms = new MultiSet<int>(list);
            NUnit.Framework.Assert.AreEqual(expected, ms.Count);
        }

        [DataTestMethod]
        [DataRow(200, false)]
        [DataRow(0, true)]
        [DataRow(10, false)]
        public void TestIsEmpty(int intCount, bool expected)
        {
            var list = new List<int>();
            for (int i = 0; i < intCount; i++)
            {
                list.Add('a');
            }
            var ms = new MultiSet<int>(list);
            Assert.AreEqual(expected, ms.IsEmpty);
        }

        [TestMethod]
        public void AddTest()
        {
            char[] chars = new char[] { 'a', 'a', 'a', 'b', 'c', 'c', 'd', 'e', 'e' };
            MultiSet<char> mschar = new MultiSet<char>();
            foreach (char c in chars)
                mschar.Add(c);
            string output = "{a:3, b:1, c:2, d:1, e:2}";
            Assert.AreEqual(output, mschar.ToString());
            Assert.AreEqual(9, mschar.Count);
        }

        [TestMethod]
        public void AddStringBuilderTest()
        {
            StringBuilder sb = new StringBuilder("aaa");
            StringBuilder sb1 = new StringBuilder("bbb");
            StringBuilder sb2 = new StringBuilder("ccc");
            List<StringBuilder> list = new List<StringBuilder>() { sb, sb1, sb2 };
            MultiSet<StringBuilder> ms = new MultiSet<StringBuilder>();
            foreach (var s in list)
            {
                ms.Add(s);
            }
            string output = "{aaa:1, bbb:1, ccc:1}";
            Assert.AreEqual(output, ms.ToString());
            Assert.AreEqual(3, ms.Count);
        }

        [TestMethod]
        public void ClearTest()
        {
            MultiSet<char> mschar = new MultiSet<char>();
            mschar.Add('a');
            mschar.Clear();
            Assert.AreEqual(0, mschar.Count);
        }

        [TestMethod]
        public void TestContains()
        {
            MultiSet<char> mschar = new MultiSet<char>();
            mschar.Add('a');
            Assert.AreEqual(true, mschar.Contains('a'));
        }

        [TestMethod]
        public void TestNotContains()
        {
            MultiSet<char> mschar = new MultiSet<char>();
            mschar.Add('a');
            Assert.AreEqual(false, mschar.Contains('b'));
        }

        [TestMethod]
        public void ConstructorTest1()
        {
            MultiSet<char> mschar = new MultiSet<char>();
            Assert.AreEqual(true, mschar.IsEmpty);
            Assert.AreEqual(0, mschar.Count);
            MultiSet<StringBuilder> ms = new MultiSet<StringBuilder>();
            Assert.AreEqual(true, ms.IsEmpty);
            Assert.AreEqual(0, ms.Count);
        }

        [TestMethod]
        public void ConstructorTest2()
        {
            char[] chars = new char[] { 'a', 'a', 'a', 'b', 'c', 'c', 'd', 'e', 'e' };
            MultiSet<char> mschar = new MultiSet<char>(chars);
            Assert.AreEqual(9, mschar.Count);
        }

        [TestMethod]
        public void StringBuilderListAdd()
        {
            StringBuilder sb = new StringBuilder("aaa");
            StringBuilder sb1 = new StringBuilder("bbb");
            StringBuilder sb2 = new StringBuilder("ccc");
            List<StringBuilder> list = new List<StringBuilder>() { sb, sb1, sb2 };
            MultiSet<StringBuilder> ms = new MultiSet<StringBuilder>(list);
            string output = "{aaa:1, bbb:1, ccc:1}";
            Assert.AreEqual(output, ms.ToString());
        }

        [TestMethod]
        public void IsSubsetTest()
        {
            char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var ms = new MultiSet<char>(chars);
            char[] chars2 = new char[] { 'a', 'b', 'c' };
            var ms2 = new MultiSet<char>(chars2);
            Assert.AreEqual(true, ms2.IsSubsetOf(ms));
        }

        [TestMethod]
        public void IsNotSubsetTest()
        {
            char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var ms = new MultiSet<char>(chars);
            char[] chars2 = new char[] { 'a', 'b', 'x' };
            var ms2 = new MultiSet<char>(chars2);
            Assert.AreEqual(false, ms2.IsSubsetOf(ms));
        }

        [TestMethod]
        public void IsProperSubsetTest()
        {
            char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var ms = new MultiSet<char>(chars);
            char[] chars2 = new char[] { 'a', 'b', 'c' };
            var ms2 = new MultiSet<char>(chars2);
            Assert.AreEqual(true, ms2.IsProperSubsetOf(ms));
        }

        [TestMethod]
        public void IsNotProperSubsetTest()
        {
            char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var ms = new MultiSet<char>(chars);
            char[] chars2 = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var ms2 = new MultiSet<char>(chars2);
            Assert.AreEqual(false, ms2.IsProperSubsetOf(ms));
        }

        [TestMethod]
        public void IsSupersetTest()
        {
            char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var ms = new MultiSet<char>(chars);
            char[] chars2 = new char[] { 'a', 'b', 'c' };
            var ms2 = new MultiSet<char>(chars2);
            Assert.AreEqual(true, ms.IsSupersetOf(ms2));
        }

        [TestMethod]
        public void IsNotSupersetTest()
        {
            char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var ms = new MultiSet<char>(chars);
            char[] chars2 = new char[] { 'a', 'b', 'x' };
            var ms2 = new MultiSet<char>(chars2);
            Assert.AreEqual(false, ms.IsSupersetOf(ms2));
        }

        [TestMethod]
        public void IsProperSupersetTest()
        {
            char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var ms = new MultiSet<char>(chars);
            char[] chars2 = new char[] { 'a', 'b', 'c' };
            var ms2 = new MultiSet<char>(chars2);
            Assert.AreEqual(true, ms.IsProperSupersetOf(ms2));
        }

        [TestMethod]
        public void IsNotProperSupersetTest()
        {
            char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var ms = new MultiSet<char>(chars);
            char[] chars2 = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var ms2 = new MultiSet<char>(chars2);
            Assert.AreEqual(false, ms.IsProperSupersetOf(ms2));
        }

        [TestMethod]
        public void CopyToTest()
        {
            char[] chars = new char[] { 'a', 'a', 'b', 'c', 'd', 'e' };
            var ms = new MultiSet<char>(chars);
            char[] outputArr = new char[chars.Length];
            ms.CopyTo(outputArr, 0);
            Assert.AreEqual(string.Concat(chars), string.Concat(outputArr));
        }

        [TestMethod]
        public void OverlapsTest()
        {
            char[] chars = new char[] { 'a', 'a', 'b', 'c', 'd', 'e' };
            var ms = new MultiSet<char>(chars);
            char[] testChar = new char[] { 'a' };
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(true, ms.Overlaps(testChar));
        }

        [TestMethod]
        public void NotOverlapsTest()
        {
            char[] chars = new char[] { 'a', 'a', 'b', 'c', 'd', 'e' };
            var ms = new MultiSet<char>(chars);
            char[] testChar = new char[] { 'x' };
            Assert.AreEqual(false, ms.Overlaps(testChar));
        }

        [TestMethod]
        public void MultiSetEqualsTest()
        {
            char[] chars = new char[] { 'a', 'a', 'b', 'c', 'd', 'e' };
            var ms = new MultiSet<char>(chars);
            char[] chars2 = new char[] { 'e', 'd', 'c', 'b', 'a', 'a' };
            var ms2 = new MultiSet<char>(chars);
            Assert.AreEqual(true, ms.MultiSetEquals(ms2));
        }

        [TestMethod]
        public void EmptyTest()
        {
            var ms = MultiSet<char>.Empty;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(true, ms.IsEmpty);
        }
    }
}