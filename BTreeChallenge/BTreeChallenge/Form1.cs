using System;
using System.Drawing;
using System.Windows.Forms;

/****************************************
* Mattersight Binary Tree Challenge
* Author: Ethan Hailey
* Purpose: A visual representation of an
*          algorithm finding the closest
*          parent of any two nodes.
*****************************************/
namespace BTreeChallenge
{

    public partial class Form1 : Form
    {
        //Variables used for drawing
        Graphics g;
        private const int NODE_RADIUS = 25;

        //The set of nodes that will be in the BTree
        Node[] nodes = new Node[]{
                new Node(10), new Node(7), new Node(13),
                new Node(23), new Node(16), new Node(25),
                new Node(15), new Node(20), new Node(4),
                new Node(5), new Node(3), new Node(2),
                new Node(8), new Node(14), new Node(19),
                new Node(21)
            };

        //Nodes used for drawing
        Node root;
        Node n1;
        Node n2;
        Node parent;

        /*****************************************************************************************
		* Function : ParentFinder(ref Node root, ref Node n1, ref Node n2);
		* Arguments: ref Node root - The root node of the tree passed into the function.
		* 			  ref Node n1   - A node to find the nearest common parent of, relative to n2.
		* 			  ref Node n2   - A node to find the nearest common parent of, relative to n1.
		* Returns  : The nearest common parent node of n1 and n2, or null if the BTree is invalid.
		*****************************************************************************************/
        public static Node ParentFinder(ref Node root, ref Node n1, ref Node n2)
        {
            //Return null if there is no root node
            if (root == null)
            {
                return null;
            }

            //If the root node has n1 or n2 as direct child then return the root
            if (root.left == n1 || root.left == n2 || root.right == n1 || root.right == n2)
            {
                return root;
            }

            //Search subtrees
            Node leftTree = ParentFinder(ref root.left, ref n1, ref n2);
            Node rightTree = ParentFinder(ref root.right, ref n1, ref n2);

            //If both subtrees contain one of the nodes, then return the root.
            if (leftTree != null && rightTree != null)
            {
                return root;
            }

            //If left tree isn't null, then it is the parent
            if (leftTree != null)
            {
                return leftTree;
            }
            //Otherwise, the right tree is the parent
            else
            {
                return rightTree;
            }
        }

        public Form1()
        {
            InitializeComponent();

            //Set up the tree with some values
            BinaryTree tree = new BinaryTree();

            //Insert the nodes into the tree
            for (int i = 0; i < nodes.Length; i++)
            {
                tree.insert(ref nodes[i]);
            }

            //Set up variables for use in visualization
            root = nodes[0];
            n1 = nodes[5];
            n2 = nodes[6];
            parent = ParentFinder(ref nodes[0], ref nodes[5], ref nodes[6]);

        }

        //Variables used for drawing the legend
        Rectangle legend_parent = new Rectangle(10, 10, 25, 25);
        Rectangle legend_child = new Rectangle(10, 45, 25, 25);


        private void PnlDrawTree_Paint(object sender, PaintEventArgs e)
        {
            g = PnlDrawTree.CreateGraphics();
            
            //Draw Legend
            g.FillRectangle(Brushes.Red, legend_parent);
            g.FillRectangle(Brushes.GreenYellow, legend_child);
            g.DrawString("- Parent Node", new Font(this.Font.FontFamily, (NODE_RADIUS / 2) - 1),
                Brushes.Black, new PointF(45, 10));
            g.DrawString("- Child Node", new Font(this.Font.FontFamily, (NODE_RADIUS / 2) - 1),
                Brushes.Black, new PointF(45, 45));
            
            //Draw Nodes
            drawNode(ref root, PnlDrawTree.Size.Width/2, 25, ref n1, ref n2, ref parent);
        }

        private void drawNode(ref Node root, int x, int y, ref Node n1, ref Node n2, ref Node parent)
        {
            //Recursively draw left nodes
            Point nodePos = new Point(x, y);
            if (root.left != null)
            {
                Point newNodePos = new Point(x - 50, y + 50);
                g.DrawLine(Pens.Black, nodePos, newNodePos);
                drawNode(ref root.left, newNodePos.X, newNodePos.Y, ref n1, ref n2, ref parent);
            }

            //Recursively draw right nodes
            if (root.right != null)
            {
                Point newNodePos = new Point(x + 50, y + 50);
                g.DrawLine(Pens.Black, nodePos, newNodePos);
                drawNode(ref root.right, newNodePos.X, newNodePos.Y, ref n1, ref n2, ref parent);
            }

            //Select a color for the node if applicable
            Color color = Color.White;
            if (root == n1 || root == n2) { color = Color.GreenYellow; }
            if (root == parent) { color = Color.Red; }

            //Draw the node
            Rectangle nodeRect = new Rectangle(x - (NODE_RADIUS / 2), y - (NODE_RADIUS / 2), NODE_RADIUS, NODE_RADIUS);
            SolidBrush brush = new SolidBrush(color);
            g.DrawEllipse(Pens.Black, nodeRect);
            g.FillEllipse(brush, new Rectangle(nodeRect.X + 1, nodeRect.Y + 1, nodeRect.Width - 1, nodeRect.Height - 1));

            //Draw the node value
            string value = root.getData().ToString();
            g.DrawString(value, new Font(this.Font.FontFamily, (NODE_RADIUS / 2) - 1),
                Brushes.Black, new PointF(x - (NODE_RADIUS / 2), y - (NODE_RADIUS / 2)));
        }
        
        private void btnRandomNodes_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            n1 = nodes[rand.Next(1, nodes.Length)];
            //Don't let n1 and n2 be the same node. While technically true, it's obvious.
            while (n2 == n1)
            {
                n2 = nodes[rand.Next(1, nodes.Length)];
            }
            parent = ParentFinder(ref root, ref n1, ref n2);
            PnlDrawTree.Refresh();
        }
    }

    //A node in the BTree
    public class Node
    {
        private int data;
        public Node left;
        public Node right;

        public Node(int val)
        {
            data = val;
            left = null;
            right = null;
        }

        public int getData()
        {
            return data;
        }

        public void insert(ref Node node, ref Node n)
        {
            if (node == null)
            {
                node = n;
            }
            else if (n.data > node.data)
            {
                insert(ref node.right, ref n);
            }
            else if (n.data < node.data)
            {
                insert(ref node.left, ref n);
            }
        }

    }

    //BTree contains nodes
    public class BinaryTree
    {
        private Node root;

        public BinaryTree()
        {
            root = null;
        }

        public void insert(ref Node node)
        {
            if (root == null)
            {
                root = node;
            }
            else
            {
                root.insert(ref root, ref node);
            }
        }

    }

}
