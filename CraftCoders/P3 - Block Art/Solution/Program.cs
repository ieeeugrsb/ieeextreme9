//
//  Program.cs
//
//  Author:
//       IEEE Student Branch of Granada
//
//  Copyright (c) 2015 IEEE Student Branch of Granada (c) 2015
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
using System.Linq;

namespace Solution
{
    public class MainClass
    {
        public static void Main()
        {
            // Create the matrix from the input.
            string[] dimensions = Console.ReadLine().Split(' ');
            int rows = Convert.ToInt32(dimensions[0]);
            int cols = Convert.ToInt32(dimensions[1]);
            var matrix = new int[cols][];
            for (int i = 0; i < cols; i++)
                matrix[i] = new int[rows];

            // Get number of queries
            int numQueries = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numQueries; i++) {
                Query query = Query.FromString(Console.ReadLine());
                ProcessQuery(matrix, query);
            }
        }

        private static void ProcessQuery(int[][] matrix, Query query)
        {
            switch (query.Operation) {
            case Operations.Add:
                AddLayer(matrix, query.Start, query.End);
                break;

            case Operations.Remove:
                RemoveLayer(matrix, query.Start, query.End);
                break;

            case Operations.Question:
                ShowLayer(matrix, query.Start, query.End);
                break;
            }
        }

        private static void AddLayer(int[][] matrix, Point start, Point end)
        {
            for (int x = start.X; x <= end.X; x++)
                for (int y = start.Y; y <= end.Y; y++)
                    matrix[x][y]++;
        }

        private static void RemoveLayer(int[][] matrix, Point start, Point end)
        {
            for (int x = start.X; x <= end.X; x++)
                for (int y = start.Y; y <= end.Y; y++)
                    matrix[x][y]--;
        }

        private static void ShowLayer(int[][] matrix, Point start, Point end)
        {
            int count = 0;
            for (int x = start.X; x <= end.X; x++)
                for (int y = start.Y; y <= end.Y; y++)
                    count += matrix[x][y];

            Console.WriteLine(count);
        }
    }

    public class Layer
    {
        public Layer(int value, Point start, Point end)
        {
            Value = value;
            Start = start;
            End = end;
        }

        public int Value {
            get;
            set;
        }

        public Point Start {
            get;
            private set;
        }

        public Point End {
            get;
            private set;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != typeof(Layer))
                return false;
            Layer other = (Layer)obj;
            return Start == other.Start && End == other.End;
        }

        public static bool operator !=(Layer layer1, Layer layer2)
        {
            return !layer1.Equals(layer2);
        }

        public static bool operator ==(Layer layer1, Layer layer2)
        {
            return layer1.Equals(layer2);
        }

        public override int GetHashCode()
        {
            unchecked {
                return (Start != null ? Start.GetHashCode() : 0) ^ (End != null ? End.GetHashCode() : 0);
            }
        }

        public bool Intersect(Layer other)
        {
            bool intersectVertical = (((other.End.X - Start.X) > 0) ||
                ((End.X - other.Start.X) > 0));

            bool intersectHorizontal = (((other.End.Y - Start.Y) > 0) ||
                ((End.Y - other.Start.Y) > 0));

            return intersectVertical && intersectHorizontal;
        }

        public override string ToString()
        {
            return string.Format("[Layer: Value={0}, Start={1}, End={2}]", Value, Start, End);
        }
    }

    public class Query
    {
        public Query(Operations operation, Point start, Point end)
        {
            Operation = operation;
            Start = start;
            End = end;
        }

        public Operations Operation {
            get;
            private set;
        }

        public Point Start {
            get;
            private set;
        }

        public Point End {
            get;
            private set;
        }

        public static Query FromString(string data)
        {
            string[] args = data.Split(' ');

            Operations operation = Operations.Add;
            switch (args[0]) {
            case "a":
                operation = Operations.Add;
                break;

            case "r":
                operation = Operations.Remove;
                break;

            case "q":
                operation = Operations.Question;
                break;
            }

            Point start = new Point(
                              Convert.ToInt32(args[2]) - 1,
                              Convert.ToInt32(args[1]) - 1);
            Point end = new Point(
                Convert.ToInt32(args[4]) - 1,
                Convert.ToInt32(args[3]) - 1);

            return new Query(operation, start, end);
        }

        public override string ToString()
        {
            return string.Format("[Query: Operation={0}, Start={1}, End={2}]", Operation, Start, End);
        }
    }

    public enum Operations {
        Add,
        Remove,
        Question
    }

    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X {
            get;
            private set;
        }

        public int Y {
            get;
            private set;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != typeof(Point))
                return false;
            Point other = (Point)obj;
            return X == other.X && Y == other.Y;
        }

        public static bool operator !=(Point point1, Point point2)
        {
            return !point1.Equals(point2);
        }

        public static bool operator ==(Point point1, Point point2)
        {
            return point1.Equals(point2);
        }

        public override int GetHashCode()
        {
            unchecked {
                return X.GetHashCode() ^ Y.GetHashCode();
            }
        }

        public override string ToString()
        {
            return string.Format("[Point: X={0}, Y={1}]", X, Y);
        }
    }
}
