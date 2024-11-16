using Microsoft.VisualStudio.TestTools.UnitTesting;
using stp9;

namespace stp9
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAdd1()
        {
            TPolynom tpoly = new TPolynom();
            tpoly.Members.Add(new TMember(1, 0));
            Assert.AreEqual(tpoly.Show(), "1x^0");
        }

        [TestMethod]
        public void TestAdd2()
        {
            TPolynom tpoly = new TPolynom();
            tpoly.Members.Add(new TMember(1, 0));
            tpoly.Members.Add(new TMember(1, 1));
            Assert.AreEqual(tpoly.Show(), "1x^1+1x^0");
        }

        [TestMethod]
        public void TestMul1()
        {
            TPolynom tpoly = new TPolynom();
            TPolynom newtpoly = new TPolynom();
            tpoly.Members.Add(new TMember(1, 0));
            tpoly.Members.Add(new TMember(1, 1));
            newtpoly.Members.Add(new TMember(1, 0));
            newtpoly.Members.Add(new TMember(1, 1));

            TPolynom addpoly = tpoly.Add(newtpoly);
            addpoly = tpoly.Mul(newtpoly);

            Assert.AreEqual(addpoly.Show(), "1x^2+2x^1+1x^0");
        }

        [TestMethod]
        public void TestMul2()
        {
            TPolynom tpoly = new TPolynom();
            TPolynom newtpoly = new TPolynom();
            tpoly.Members.Add(new TMember(1, 0));
            tpoly.Members.Add(new TMember(1, 2));
            newtpoly.Members.Add(new TMember(2, 0));
            newtpoly.Members.Add(new TMember(1, 1));

            TPolynom addpoly = tpoly.Add(newtpoly);
            addpoly = tpoly.Mul(newtpoly);

            Assert.AreEqual(addpoly.Show(), "1x^3+2x^2+1x^1+2x^0");
        }

        [TestMethod]
        public void TestClear()
        {
            TPolynom tpoly = new TPolynom();
            tpoly.Members.Add(new TMember(1, 0));
            tpoly.Clear();
            Assert.AreEqual(tpoly.Show(), "");
        }

        [TestMethod]
        public void TestCalc1()
        {
            TPolynom tpoly = new TPolynom();
            tpoly.Members.Add(new TMember(1, 2));
            tpoly.Members.Add(new TMember(3, 3));
            tpoly.Members.Add(new TMember(4, 2));

            Assert.AreEqual(tpoly.Calculate(2), 44);
        }

        [TestMethod]
        public void TestCalc2()
        {
            TPolynom tpoly = new TPolynom();
            tpoly.Members.Add(new TMember(1, 2));
            tpoly.Members.Add(new TMember(3, 0));
            tpoly.Members.Add(new TMember(4, 0));

            Assert.AreEqual(tpoly.Calculate(2), 11);
        }

        [TestMethod]
        public void TestEquals1()
        {
            TPolynom tpoly1 = new TPolynom();
            tpoly1.Members.Add(new TMember(1, 2));

            TPolynom tpoly2 = new TPolynom();
            tpoly2.Members.Add(new TMember(1, 2));


            Assert.AreEqual(tpoly1.Equals(tpoly2), true);
        }

        [TestMethod]
        public void TestEquals2()
        {
            TPolynom tpoly1 = new TPolynom();
            tpoly1.Members.Add(new TMember(1, 2));

            TPolynom tpoly2 = new TPolynom();
            tpoly2.Members.Add(new TMember(0, 2));


            Assert.AreEqual(tpoly1.Equals(tpoly2), false);
        }

        [TestMethod]
        public void TestDiff1()
        {
            TPolynom tpoly1 = new TPolynom();
            tpoly1.Members.Add(new TMember(1, 3));

            Assert.AreEqual(tpoly1.Diff().Show(), "3x^2");
        }

        [TestMethod]
        public void TestElementAt()
        {
            TPolynom tpoly1 = new TPolynom();
            tpoly1.Members.Add(new TMember(11, 11));
            tpoly1.Members.Add(new TMember(22, 22));

            Assert.AreEqual(new System.Tuple<int, int>(11, 11), tpoly1.ElementAt(1));
        }

        [TestMethod]
        public void TestRetDegree()
        {
            TPolynom tpoly1 = new TPolynom();
            tpoly1.Members.Add(new TMember(11, 11));
            tpoly1.Members.Add(new TMember(22, 22));

            Assert.AreEqual(tpoly1.RetDegree(), 22);
        }

        [TestMethod]
        public void TestRetCoeff()
        {
            TPolynom tpoly1 = new TPolynom();
            tpoly1.Members.Add(new TMember(11, 11));
            tpoly1.Members.Add(new TMember(22, 33));

            Assert.AreEqual(tpoly1.RetCoeff(33), 22);
        }

        [TestMethod]
        public void TestRetCoeff2()
        {
            TPolynom tpoly1 = new TPolynom();
            tpoly1.Members.Add(new TMember(11, 11));
            tpoly1.Members.Add(new TMember(22, 33));
            tpoly1.Members.Add(new TMember(20, 33));

            Assert.AreEqual(tpoly1.RetCoeff(33), 42);
        }

        [TestMethod]
        public void TestRev()
        {
            TPolynom tpoly1 = new TPolynom();
            tpoly1.Members.Add(new TMember(11, 1));
            tpoly1.Members.Add(new TMember(22, 3));
            tpoly1.Members.Add(new TMember(20, 2));

            Assert.AreEqual(tpoly1.Rev().Show(), "-22x^3-20x^2-11x^1");
        }
    }
}
