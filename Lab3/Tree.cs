using System;
using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab3
{
    public class Tree : IEnumerable<Student>
    {
        protected Node Root;

        public Tree()
        {
            Root = null;
        }

        public void Insert(Student item)
        {
            Root = InsertRecursively(Root, item);
        }

        private Node InsertRecursively(Node root, Student item)
        {
            if (root == null)
            {
                return new Node(item);
            }

            if (item.CompareTo(root.Data) < 0)
            {
                root.Left = InsertRecursively(root.Left, item);
            }
            else if (item.CompareTo(root.Data) > 0)
            {
                root.Right = InsertRecursively(root.Right, item);
            }

            return root;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Student> GetEnumerator()
        {
            return InOrderTraversal(Root).GetEnumerator();
        }

        private class TreeEnumerator : IEnumerator
        {
            private Stack<Node> stack;
            private Node current;

            public TreeEnumerator(Tree tree)
            {
                stack = new Stack<Node>();
                current = tree.Root;
                PushLeft(current);
            }

            private void PushLeft(Node node)
            {
                while (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
            }

            public bool MoveNext()
            {
                if (stack.Count > 0)
                {
                    current = stack.Pop();
                    PushLeft(current.Right);
                    return true;
                }
                return false;
            }
            public Student Current => current.Data;

            object IEnumerator.Current => Current;

            public void Reset()
            {
                stack.Clear();
                current = null!;
            }

            public void Dispose()
            {
                stack.Clear();
            }
        }

        private IEnumerable<Student> InOrderTraversal(Node node)
        {
            if (node != null)
            {
                foreach (var item in InOrderTraversal(node.Left))
                {
                    yield return item;
                }

                yield return node.Data;

                foreach (var item in InOrderTraversal(node.Right))
                {
                    yield return item;
                }
            }
        }

        public IEnumerable<Student> CustomSearch()
        {
            return SearchRecursively(Root, s => s.Citizenship != "Ukraine" && s.AverageGrade >= 90 && s.Course == 1);
        }

        public Student Search(Predicate<Student> match)
        {
            return SearchRecursively(Root, match).First();
        }

        private IEnumerable<Student> SearchRecursively(Node root, Predicate<Student> match)
        {
            if (root == null)
            {
                yield break;
            }

            if (match(root.Data))
            {
                yield return root.Data;
            }

            foreach (var student in SearchRecursively(root.Left, match))
            {
                yield return student;
            }

            foreach (var student in SearchRecursively(root.Right, match))
            {
                yield return student;
            }
        }

        public void Remove(Predicate<Student> match)
        {
            List<Student> found = [];

            foreach (var student in SearchRecursively(Root, match))
            {
                found.Add(student);
            }

            foreach (var student in found)
            {
                Root = RemoveNodeWithData(Root, student);
            }
        }

        public void CustomRemove()
        {
            Remove(s => s.Citizenship != "Ukraine" && s.AverageGrade >= 90 && s.Course == 1);
        }

        private Node FindRightmost(Node node)
        {
            while (node.Right != null)
            {
                node = node.Right;
            }
            return node;
        }

        private Node RemoveNodeWithData(Node root, Student data)
        {
            if (root == null) return null;

            int cmp = data.CompareTo(root.Data);
            if (cmp < 0)
            {
                root.Left = RemoveNodeWithData(root.Left, data);
            }
            else if (cmp > 0)
            {
                root.Right = RemoveNodeWithData(root.Right, data);
            }
            else
            {
                return RemoveNode(root);
            }

            return root;
        }

        private Node RemoveNode(Node root)
        {
            if (root == null) return null;

            if (root.Left == null && root.Right == null)
            {
                return null;
            }

            if (root.Left == null)
            {
                return root.Right;
            }

            if (root.Right == null)
            {
                return root.Left;
            }

            Node rightmost = FindRightmost(root.Left);

            root.Data = rightmost.Data;

            root.Left = RemoveNodeWithData(root.Left, rightmost.Data);

            return root;
        }
    }
}
