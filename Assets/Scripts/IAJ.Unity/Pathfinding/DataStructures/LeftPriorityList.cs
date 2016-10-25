using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.IAJ.Unity.Pathfinding.DataStructures
{
    public class LeftPriorityList : IOpenSet
    {
        private List<NodeRecord> Open { get; set; }

        public LeftPriorityList()
        {
            this.Open = new List<NodeRecord>();
            //this.Open.Sort((n1, n2) => n1.fValue < n2.fValue? -1 : 1);
        }
        public void Initialize()
        {
            this.Open.Clear();
        }

        public void Replace(NodeRecord nodeToBeReplaced, NodeRecord nodeToReplace)
        {
            this.Open.Remove(nodeToBeReplaced);
        }

        public NodeRecord GetBestAndRemove()
        {
            var best = this.PeekBest();
            this.Open.Remove(best);
            return best;
        }

        public NodeRecord PeekBest()
        {
            return Open[0]; 
        }
         
        public void AddToOpen(NodeRecord nodeRecord)
        {
            //a little help here
            //is very nice that the List<T> already implements a binary search method
            int index = this.Open.BinarySearch(nodeRecord);
            if (index < 0)
            {
                //Debug.Log("add to open: " + (~index >= this.Open.Count ? 0 : this.Open[~index].fValue) + " -> " + nodeRecord.fValue);
                this.Open.Insert(~index, nodeRecord);
            }
        }

        public void RemoveFromOpen(NodeRecord nodeRecord)
        {
            this.Open.Remove(nodeRecord);
        }

        public NodeRecord SearchInOpen(NodeRecord nodeRecord)
        {
            return this.Open.Find(n => n.Equals(nodeRecord));
        }

        public ICollection<NodeRecord> All()
        {
            return this.Open;
        }

        public int CountOpen()
        {
            return Open.Count;
        }
    }
}
