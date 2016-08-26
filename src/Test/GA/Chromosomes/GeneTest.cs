using System.ComponentModel;
using CoolNameGenerator.PGA.Chromosomes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.GA.Chromosomes
{
    [TestClass]
    [Category("Chromosomes")]
    public class GeneTest
    {
        [TestMethod]
        public void ToString_NoArgs_Value()
        {
            var target = new Gene<int?>();
            Assert.AreEqual("", target.ToString());

            target = new Gene<int?>(1);
            Assert.AreEqual("1", target.ToString());
        }

        [TestMethod]
        public void Equals_OtherNotGene_False()
        {
            var target = new Gene<int>(1);
            var other = 1;
            Assert.IsFalse(target.Equals(other));
        }

        [TestMethod]
        public void Equals_OtherAsObjectOtherValue_False()
        {
            var target = new Gene<int>(1);
            var other = new Gene<int>(2); ;
            Assert.IsFalse(target.Equals((object) other));
        }

        [TestMethod]
        public void Equals_OtherAsObjectSameValue_True()
        {
            var target = new Gene<int>(1);
            var other = new Gene<int>(1); ;
            Assert.IsTrue(target.Equals(other as object));
        }

        [TestMethod]
        public void Equals_OtherValue_False()
        {
            var target = new Gene<int>(1);
            var other = new Gene<int>(2);
            Assert.IsFalse(target.Equals(other));
        }

        [TestMethod]
        public void Equals_SameValue_True()
        {
            var target = new Gene<int>(1);
            var other = new Gene<int>(1);
            Assert.IsTrue(target.Equals(other));
        }

        [TestMethod]
        public void GetHashCode_NoValue_Zero()
        {
            var target = new Gene<int>();
            Assert.AreEqual(0, target.GetHashCode());
        }

        [TestMethod]
        public void OperatorEquals_SameValue_True()
        {
            var target = new Gene<int>(1);
            var other = new Gene<int>(1);
            Assert.IsTrue(target == other);
        }

        [TestMethod]
        public void OperatorEquals_DiffValue_False()
        {
            var target = new Gene<int>(1);
            var other = new Gene<int>(2);
            Assert.IsFalse(target == other);
        }

        [TestMethod]
        public void OperatorDiff_Diff_True()
        {
            var target = new Gene<char>('1');
            var other = new Gene<char>('2');
            Assert.IsTrue(target != other);
        }
    }
}
