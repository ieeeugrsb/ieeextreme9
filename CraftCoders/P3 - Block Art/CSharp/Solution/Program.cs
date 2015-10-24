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
using System.Collections.Generic;

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

            Dictionary<int, Cube> cubes = new Dictionary<int, Cube>(rows * cols);

            // Get number of queries
            int numQueries = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numQueries; i++) {
                Query query = Query.FromString(Console.ReadLine());
                ProcessQuery(cubes, cols, query);
            }
        }

        private static void ProcessQuery(Dictionary<int, Cube> cubes, int cols,
            Query query)
        {
            switch (query.Operation) {
            case Operations.Add:
            case Operations.Remove:
                IntersectLayer(cubes, cols, query);
                break;

            case Operations.Question:
                PrintCount(cubes, query);
                break;
            }
        }

        private static void IntersectLayer(Dictionary<int, Cube> cubes, int cols,
            Query query)
        {
            foreach (Cube cube in query.GetCubes()) {
                int idx = cube.Y * cols + cube.X;
                if (!cubes.ContainsKey(idx))
                    cubes.Add(idx, cube);
                
                cubes[idx].Value += (int)query.Operation;
            }
        }

        private static void PrintCount(Dictionary<int, Cube> cubes, Query query)
        {
            int count = 0;
            foreach (Cube cube in cubes.Values)
                if (cube.X >= query.Start.X && cube.X <= query.End.X &&
                        cube.Y >= query.Start.Y && cube.Y <= query.End.Y)
                    count += cube.Value;

            Console.WriteLine(count);
        }
    }

    public class Cube
    {
        public Cube(Point position, int value)
        {
            Value = value;
            Position = position;
        }

        public int Value {
            get;
            set;
        }

        public int X {
            get { return Position.X; }
        }

        public int Y {
            get { return Position.Y; }
        }

        public Point Position {
            get;
            private set;
        }
    }

    public class Query
    {
        private List<Cube> cubes = new List<Cube>();

        public Query(Operations operation, Point start, Point end)
        {
            Operation = operation;
            Start = start;
            End = end;

            for (int y = start.Y; y < end.Y + 1; y++)
                for (int x = start.X; x < end.X + 1; x++)
                    cubes.Add(new Cube(new Point(x, y), 0));
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

        public List<Cube> GetCubes()
        {
            return cubes;
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

    public enum Operations : int {
        Add = 1,
        Remove = -1,
        Question = 0
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
