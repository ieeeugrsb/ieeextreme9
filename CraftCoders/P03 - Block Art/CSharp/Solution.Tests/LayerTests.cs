//
//  LayerTests.cs
//
//  Author:
//       Benito Palacios Sánchez (aka pleonex) <benito356@gmail.com>
//
//  Copyright (c) 2015 Benito Palacios Sánchez (c) 2015
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using NUnit.Framework;

namespace Solution.Tests
{
    [TestFixture]
    public class LayerTests
    {
        [Test]
        public void IntersectLT()
        {
            Layer layer1 = new Layer(0, new Point(4, 4), new Point(7, 6));
            Layer layer2 = new Layer(0, new Point(3, 3), new Point(5, 5));

            Assert.IsTrue(layer1.Intersect(layer2));
            Assert.IsTrue(layer2.Intersect(layer1));
        }

        [Test]
        public void IntersectLB()
        {
            Layer layer1 = new Layer(0, new Point(4, 4), new Point(7, 6));
            Layer layer2 = new Layer(0, new Point(3, 6), new Point(4, 7));

            Assert.IsTrue(layer1.Intersect(layer2));
            Assert.IsTrue(layer2.Intersect(layer1));
        }

        [Test]
        public void IntersectRT()
        {
            Layer layer1 = new Layer(0, new Point(4, 4), new Point(7, 6));
            Layer layer2 = new Layer(0, new Point(6, 3), new Point(8, 5));

            Assert.IsTrue(layer1.Intersect(layer2));
            Assert.IsTrue(layer2.Intersect(layer1));
        }

        [Test]
        public void IntersectRB()
        {
            Layer layer1 = new Layer(0, new Point(4, 4), new Point(7, 6));
            Layer layer2 = new Layer(0, new Point(6, 6), new Point(8, 7));

            Assert.IsTrue(layer1.Intersect(layer2));
            Assert.IsTrue(layer2.Intersect(layer1));
        }

        [Test]
        public void IntersectInside()
        {
            Layer layer1 = new Layer(0, new Point(4, 4), new Point(7, 6));
            Layer layer2 = new Layer(0, new Point(5, 5), new Point(5, 5));

            Assert.IsTrue(layer1.Intersect(layer2));
            Assert.IsTrue(layer2.Intersect(layer1));
        }

        [Test]
        public void IntersectCornerLT()
        {
            Layer layer1 = new Layer(0, new Point(4, 4), new Point(7, 6));
            Layer layer2 = new Layer(0, new Point(3, 3), new Point(4, 4));

            Assert.IsTrue(layer1.Intersect(layer2));
            Assert.IsTrue(layer2.Intersect(layer1));
        }

        [Test]
        public void IntersectBorderTop()
        {
            Layer layer1 = new Layer(0, new Point(4, 4), new Point(7, 6));
            Layer layer2 = new Layer(0, new Point(5, 6), new Point(6, 7));

            Assert.IsTrue(layer1.Intersect(layer2));
            Assert.IsTrue(layer2.Intersect(layer1));
        }

        [Test]
        public void IntersectedAreaSame()
        {
            Layer layer1 = new Layer(0, new Point(1, 1), new Point(6, 5));
            Layer layer2 = new Layer(0, new Point(1, 1), new Point(6, 5));

            Assert.AreEqual(30, layer1.IntersectedArea(layer2));
            Assert.AreEqual(30, layer2.IntersectedArea(layer1));
        }

        [Test]
        public void NotIntersected()
        {
            Layer layer1 = new Layer(0, new Point(1, 1), new Point(6, 5));
            Layer layer2 = new Layer(0, new Point(0, 0), new Point(0, 6));

            Assert.AreEqual(0, layer1.IntersectedArea(layer2));
            Assert.AreEqual(0, layer2.IntersectedArea(layer1));
        }

        [Test]
        public void IntersectedAreaLT()
        {
            Layer layer1 = new Layer(0, new Point(1, 1), new Point(6, 5));
            Layer layer2 = new Layer(0, new Point(1, 0), new Point(3, 3));

            Assert.AreEqual(9, layer1.IntersectedArea(layer2));
            Assert.AreEqual(9, layer2.IntersectedArea(layer1));
        }

        [Test]
        public void IntersectedAreaLT2()
        {
            Layer layer1 = new Layer(0, new Point(1, 1), new Point(6, 5));
            Layer layer2 = new Layer(0, new Point(0, 0), new Point(3, 3));

            Assert.AreEqual(9, layer1.IntersectedArea(layer2));
            Assert.AreEqual(9, layer2.IntersectedArea(layer1));
        }

        [Test]
        public void IntersectedAreaInsideTop()
        {
            Layer layer1 = new Layer(0, new Point(1, 1), new Point(6, 5));
            Layer layer2 = new Layer(0, new Point(2, 0), new Point(3, 3));

            Assert.AreEqual(6, layer1.IntersectedArea(layer2));
            Assert.AreEqual(6, layer2.IntersectedArea(layer1));
        }

        [Test]
        public void IntersectedAreaInside()
        {
            Layer layer1 = new Layer(0, new Point(1, 1), new Point(6, 5));
            Layer layer2 = new Layer(0, new Point(4, 4), new Point(4, 5));

            Assert.AreEqual(2, layer1.IntersectedArea(layer2));
            Assert.AreEqual(2, layer2.IntersectedArea(layer1));
        }

        [Test]
        public void IntersectedAreaLB()
        {
            Layer layer1 = new Layer(0, new Point(1, 1), new Point(6, 5));
            Layer layer2 = new Layer(0, new Point(0, 5), new Point(2, 6));

            Assert.AreEqual(2, layer1.IntersectedArea(layer2));
            Assert.AreEqual(2, layer2.IntersectedArea(layer1));
        }

        [Test]
        public void IntersectedAreaRight()
        {
            Layer layer1 = new Layer(0, new Point(1, 1), new Point(6, 5));
            Layer layer2 = new Layer(0, new Point(6, 0), new Point(9, 6));

            Assert.AreEqual(5, layer1.IntersectedArea(layer2));
            Assert.AreEqual(5, layer2.IntersectedArea(layer1));
        }
    }
}

