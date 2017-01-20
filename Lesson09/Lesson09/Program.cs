using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson09
{
    class Program
    {
        // Note: a binary tree that has a loop (example: node5 right is node1) is named a graph (not the visual kind of graph)

        // Make class that can draw rectangulars in a two dimensional array.
        static void Main(string[] args)
        {
            //checking nodes
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);
            Node node5 = new Node(5);

            node1.left = node2;
            node1.right = node3;
            node2.left = node4;
            node3.right = node5;

            Console.WriteLine(node1.getMax());
            Console.WriteLine(node1.getSum());

            //checking static drawings
            PrintRectangular(4, 3, 6, 5);
            Console.WriteLine();
            PrintX(5);
            Console.WriteLine();
            PrintCircle(11);

            //checking canvas class drawing
            Canvas myCanvas = new Canvas(50);
            myCanvas.DrawRectangle(4, 5, 20, 10);
            myCanvas.DrawRectangle(1, 2, 10, 5);
            myCanvas.DrawRectangle(6, 7, 15, 12);
            myCanvas.DrawCanvas();

            Console.ReadKey();
        }

        static void PrintRectangular(int x, int y, int width, int height)
        {
            for (int i = 0; i < y; i++)
                Console.WriteLine();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < x; j++)
                    Console.Write(' ');

                if (i == 0 || i == height - 1)
                    for (int j = 0; j < width; j++)
                        Console.Write('*');

                else
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (j == 0 || j == width - 1)
                            Console.Write('*');
                        else
                            Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }

        static void PrintX(int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (j == i || j == size - i - 1)
                        Console.Write('*');
                    else
                        Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
        // Circle equation: (delta)x^2 + (delta)y^2 = radius^2
        static void PrintCircle(int radius)
        {
            int origX = radius;
            int origY = radius;
            int circleWidth = radius;
            for (int y = 0; y <= radius * 2; y++)
            {
                int deltaY = origY - y;
                for (int x = 0; x <= radius * 2; x++)
                {
                    int deltaX = origX - x;
                    if (Math.Abs(deltaX * deltaX + deltaY * deltaY - radius * radius) < circleWidth)
                        Console.Write('*');
                    else
                        Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
    }

    class Node
    {
        public int value;
        public Node right, left;

        public Node(int value)
        {
            this.value = value;
            right = null;
            left = null;
        }

        public int getMax()
        {
            int max = value;
            if (right != null)
            {
                int maxRight = right.getMax();
                if (maxRight > max)
                    max = maxRight;
            }
            if (left != null)
            {
                int maxLeft = left.getMax();
                if (maxLeft > max)
                    max = maxLeft;
            }
            return max;
        }

        public int getSum()
        {
            int sumRight = 0;
            int sumLeft = 0;
            if (right != null)
                sumRight = right.getSum();
            if (left != null)
                sumLeft = left.getSum();
            return (value + sumRight + sumLeft);
        }
    }

    class Canvas
    {
        bool[,] coordinates;

        public Canvas(int size)
        {
            coordinates = new bool[size, size];
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    coordinates[x, y] = false;
                }
            }
        }
        public Canvas()
        {
            int size = 50;
            coordinates = new bool[size, size];
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    coordinates[x, y] = false;
                }
            }
        }

        public void DrawRectangle(int x, int y, int width, int height)
        {
            for (int row = 0; row < height; row++)
            {
                if (row == 0 || row == height - 1)
                {
                    for (int column = 0; column <= width; column++)
                    {
                        coordinates[y + row, x + column] = true;
                    }
                }
                else
                {
                    coordinates[y + row, x] = true;
                    coordinates[y + row, x + width] = true;
                }
            }
        }

        public void DrawCanvas()
        {
            for (int row = 0; row < coordinates.GetLength(0); row++)
            {
                for (int column = 0; column < coordinates.GetLength(1); column++)
                {
                    if (coordinates[row, column] == true)
                        Console.Write('*');
                    else
                        Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
    }
}
