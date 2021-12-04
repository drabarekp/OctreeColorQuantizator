using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GK3
{
    public class OctreeNode
    {   
        public OctreeNode[] pointers = new OctreeNode[8];
        private Octree parent;
        public Color color;
        public int pixelCount;

        public int GetPointerIndex((byte r, byte g, byte b) colorBits)
        {
            return colorBits.r * 4 + colorBits.g * 2 + colorBits.b;
        }
        public int GetSumOfChildrenPixelCount()
        {
            return pointers.Sum(p => p==null?0:p.pixelCount);
        }
        public OctreeNode Next(int i)
        {
            return pointers[i];
        }
        
        public int ChildrenCount => pointers.Count(c => c != null);

        public OctreeNode(Octree parent)
        {
            this.parent = parent;
        }

        public int CountLeaves()
        {
            if (ChildrenCount == 0) return 1;

            int sum = 0;
            foreach(var child in pointers)
            {
                if (child == null) continue;
                sum += child.CountLeaves();
            }
            return sum;
        }

        public void AddColour(Color color, byte level)
        {
            this.color = color;
            if (level < 8)
            {
                var index = GetPointerIndex(parent.GetBitsFromColor(level, color));
                if (pointers[index] == null)
                {
                    if (level == 7)
                    {
                        parent.colorCount++;
                    }

                    var newNode = new OctreeNode(parent);
                    pointers[index] = newNode;
                    parent.AddLevelNode(newNode, level);
                    
                }
                pointers[index].AddColour(color, (byte)(level + 1));
            }
            else
            {
                this.color = color;
                pixelCount++;
            }
        }

        public Color GetColour(Color colour, byte level)
        {
            if (ChildrenCount == 0)
            {
                return color;
            }
            else
            {
                var index = GetPointerIndex(parent.GetBitsFromColor(level, color));
                return pointers[index].GetColour(colour, (byte)(level + 1));
            }
        }

        public void Merge(int level, bool dynamicRemoving)
        {
            if (ChildrenCount == 0) return;
            int count = 0;
            int red = 0;
            int green = 0;
            int blue = 0;
            int howManyChilren = 0;

            foreach(var node in pointers)
            {
                if (node == null) continue;
                red += node.color.R;
                green += node.color.G;
                blue += node.color.B;
                count += node.pixelCount;
                howManyChilren++;
            }

            this.color = Color.FromArgb(red / howManyChilren, green / howManyChilren, blue / howManyChilren);
            this.pixelCount = count;

            if(dynamicRemoving)
                foreach(var p in pointers)
                {
                    parent.levelNodes[level].Remove(p);
                }

            pointers = new OctreeNode[8];
            parent.colorCount -= (howManyChilren - 1);
        }
        public void MergeNChildren(int level, int numOfChildrenToMerge, bool dynamicRemoving)
        {
            int count = 0;
            int red = 0;
            int green = 0;
            int blue = 0;
            int howManyChilren = 0;

            OctreeNode[] sortedPointers = pointers.OrderBy((p)=> {
                return p==null?0:p.pixelCount;
            }).ToArray();

            int[] permutationOfPointers = Enumerable.Range(0, 8).ToArray();
            permutationOfPointers = permutationOfPointers.OrderBy(j => pointers[j] == null?0:pointers[j].pixelCount).ToArray();

            for(int i=0;i<8;i++)
            {
                if (sortedPointers[i] == null) continue;
                red += sortedPointers[i].color.R;
                green += sortedPointers[i].color.G;
                blue += sortedPointers[i].color.B;
                count += sortedPointers[i].pixelCount;
                pointers[permutationOfPointers[i]] = null;

                if(dynamicRemoving)
                    parent.levelNodes[level].Remove(sortedPointers[i]);

                howManyChilren++;
                
                if (howManyChilren >= numOfChildrenToMerge) break;
            }

            this.color = Color.FromArgb(red / howManyChilren, green / howManyChilren, blue / howManyChilren);
            this.pixelCount = count;

            if (this.ChildrenCount == 0) parent.colorCount -= (howManyChilren - 1);
            else parent.colorCount -= howManyChilren; //REMOVED -1
        }
    }
}
