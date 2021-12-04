using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace GK3
{
    public class Octree
    {
        OctreeNode root;
        public List<OctreeNode>[] levelNodes = new List<OctreeNode>[8];
        public int colorCount; 
        private int x = 0;
        private int imgWidth=1; 
        public double Progress { get => (double)x / (double)imgWidth; }

        public Octree()
        {
            root = new OctreeNode(this);
            colorCount = 0;
            for (int i = 0; i < 8; i++)
            {
                levelNodes[i] = new List<OctreeNode>();
            }
        }
        public void Insert(Color color)
        {
            root.AddColour(color, 0);
        }

        public (byte r, byte g, byte b) GetBitsFromColor(byte bitNum/* 0 - 7 */, Color color)
        {   
            byte mask = 0b_0000_0001;
            var modifiedMask = mask << (7 - bitNum);
            mask = (byte)modifiedMask;

            (byte r, byte g, byte b) result;
            result.r = (byte)((color.R & mask) >> (7 - bitNum));
            result.g = (byte)((color.G & mask) >> (7 - bitNum));
            result.b = (byte)((color.B & mask) >> (7 - bitNum));

            return result;
        }

        public void AddLevelNode(OctreeNode node, int level)
        {
            levelNodes[level].Add(node);
        }
        public void Reduce(int colorsLeft, bool dynamicRemoving)
        {
            var nodesToRemove = colorCount - colorsLeft;
            int level = 6;
            var toBreak = false;

            while (level >= -1 && nodesToRemove > 0)
            {
                if (level == -1)
                {
                    root.MergeNChildren(level + 1, nodesToRemove, dynamicRemoving);
                    return;
                }

                var leaves = levelNodes[level]
                    .Where(n => n.ChildrenCount - 1 <= nodesToRemove)
                    .OrderBy(n => n.ChildrenCount);

                foreach (var leaf in leaves)
                {
                    if (leaf.ChildrenCount > nodesToRemove)
                    {
                        //merging some children
                        toBreak = true;
                        leaf.MergeNChildren(level+1, nodesToRemove, dynamicRemoving);
                        break;
                    }

                    //merging all children
                    if(leaf.ChildrenCount>0)
                        nodesToRemove -= (leaf.ChildrenCount - 1);

                    leaf.Merge(level + 1, dynamicRemoving);
                    
                    if (nodesToRemove <= 0)
                    {
                        toBreak = true;
                        break;
                    }
                }

                if (toBreak)
                {
                    break;
                }

                levelNodes[level + 1] = new List<OctreeNode>();
                level--;
            }
        }

        public Color GetColorFromTree(Color color)
        {
            byte level = 0;
            var current = root;

            while (level < 8)
            {
                var colorBits = GetBitsFromColor(level, color);
                int index = current.GetPointerIndex(colorBits);
                if(current.Next(index) != null)
                {
                    current = current.Next(index);
                }
                else
                {
                    return current.color;
                }
                level++;
            }
            return current.color;
        }
        public void BuildTree(Bitmap bitmap)
        {
            imgWidth = bitmap.Width;
            for(x = 0; x < bitmap.Width; x++)
            {
                for(int y = 0; y < bitmap.Height; y++)
                {
                    Color colorFromPixel = bitmap.GetPixel(x, y);
                    Insert(colorFromPixel);
                }
                if (x % 20 == 0)
                {
                    Form1.UpdateProgressAfter();
                    Form1.form.Refresh();
                }
            }
        }

        public void BuildTreeWithReducing(Bitmap bitmap, int numOfReduceColors)
        {
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color colorFromPixel = bitmap.GetPixel(x, y);
                    Insert(colorFromPixel);
                    colorCount = CountLeaves();

                    if (colorCount>numOfReduceColors)
                        Reduce(numOfReduceColors, true);
                    
                }
                if (x % 20 == 0)
                {
                    Form1.UpdateProgressAlong();
                    Form1.form.Refresh();
                }
            }
        }

        public int CountLeaves()
        {
            return root.CountLeaves();
        }
        public Bitmap RecreateImageFromOctree(Bitmap bitmap)
        {
            Bitmap after = new Bitmap(bitmap);

            for (int x = 0; x < after.Width; x++)
            {
                for (int y = 0; y < after.Height; y++)
                {
                    Color colorFromPixel = after.GetPixel(x, y);
                    Color colorFromTree = GetColorFromTree(colorFromPixel);
                    after.SetPixel(x, y, colorFromTree);
                }
            }
            return after;
        }
    }
}
