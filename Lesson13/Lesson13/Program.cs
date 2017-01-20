using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    class Program
    {
        static void Main(string[] args)
        {
            Vertex v1 = new Vertex(1);
            Vertex v2 = new Vertex(2);
            Vertex v3 = new Vertex(3);
            Vertex v4 = new Vertex(4);
            Vertex v5 = new Vertex(5);
            Vertex v6 = new Vertex(6);
            Vertex v7 = new Vertex(7);
            Vertex v8 = new Vertex(8);
            Vertex v9 = new Vertex(9);
            Vertex v10 = new Vertex(10);
            Vertex v11 = new Vertex(11);

            v1.right = v2;
            v1.left = v3;
            v2.right = v4;
            v2.left = v5;
            v3.right = v6;
            v3.left = v7;
            v4.right = v8;
            v4.left = v9;
            v6.right = v10;
            v6.left = v11;

            Console.WriteLine(Vertex.IsSymmetric(v2, v3));
            v1.printTree();
            Console.WriteLine();
            //Vertex.DeepestTree(v2, v3);

            Console.ReadKey();
        }
    }
    /*
        There are 2 abstract ways to search/traverse a binary tree:
        (A)Traverse - > Depth First Traversal (or Depth First Search)
        The 3 methods for depth first are: 1.Inorder 2. Preorder 3.Postorder
         (1) Inorder  - put the active part of the code (printing, finding max etc) between two nodes.
         (2) Preoder - the active part is before the two nodes
         (3) Postorder - the active part is after the two nodes.
         Example:      1         
                     /   \
                    2     3
                   / \
                  4   5
        
         Printing the values:
         inorder: 42513 , preorder: 12453 , postorder: 45231
        
        (B)Breadth First Traversal / Level order Traversal                
        BFS breadth saves the members on the same level in a stack. Example: Stack(0) = [1], stack(1) = 3,2
    */

    class Vertex
    {
        public Vertex right;
        public Vertex left;
        int value;

        public Vertex(int value)
        {
            right = null;
            left = null;
            this.value = value;
        }
        public void printTree()
        {
            Console.Write(value);
            if (right != null)
            {
                Console.Write(", ");
                right.printTree();
            }
            if (left != null)
            {
                Console.Write(", ");
                left.printTree();
            }
        }

        public static bool IsSymmetric(Vertex right, Vertex left)
        {
            if (right == null && left == null)
                return true;
            if (right == null && left != null)
                return false;
            if (right != null && left == null)
                return false;
            if (right.value != left.value)
                return false;
            else
            {
                if (IsSymmetric(right.right, left.right) == false)
                    return false;
                return IsSymmetric(right.left, left.left);
            }
        }

        //Teacher solution
        public static bool isSymmetric2(Vertex a, Vertex b)
        {
            if (a == null && b == null)
                return true;
            if (a != null && b != null)
                return (a.value == b.value &&
                    isSymmetric2(a.left, b.left) &&
                    isSymmetric2(a.right, b.right));
            return false;
        }
    }


    class Stack
    {
        string[] values;
        int pos;

        public Stack()
        {
            values = new string[100];
            pos = 0;
        }
        public void push(string s)
        {
            values[pos++] = s;
        }
        public string pop()
        {
            if (pos == 0)
                return null;
            return values[pos--];
        }
    }

    // Homework: 
    // (A) Binary tree which is perfectly symmetrical both in structure and value (left and right are identical)
    //          Find the longest (deepest) tree in the entire vertex.
    // (B)Create a stack class without arrays
}
 