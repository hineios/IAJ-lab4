using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.IAJ.Unity.Pathfinding.DataStructures
{
    public class RightPriorityList : IOpenSet, IComparer<NodeRecord>
    {
        private List<NodeRecord> Open { get; set; }

        public RightPriorityList()
        {
            this.Open = new List<NodeRecord>();
            //this.Open.Sort((n1, n2) => n1.fValue >= n2.fValue ? -1 : 1);
        }
        public void Initialize()
        {
            Open.Clear();
        }

        public void Replace(NodeRecord nodeToBeReplaced, NodeRecord nodeToReplace)
        {
            Open.Remove(nodeToBeReplaced);
            AddToOpen(nodeToReplace);
        }

        public NodeRecord GetBestAndRemove()
        {
            var best = PeekBest();
            this.Open.Remove(best);
            return best;
        }

        public NodeRecord PeekBest()
        {
            return Open[Open.Count - 1];
        }

        public void AddToOpen(NodeRecord nodeRecord)
        {
            //a little help here, notice the difference between this method and the one for the LeftPriority list
            //...this one uses a different comparer with an explicit compare function (which you will have to define below)
            int index = this.Open.BinarySearch(nodeRecord, this);
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
            return this.Open.Count;
        }

        public int Compare(NodeRecord x, NodeRecord y)
        {
            if (x.fValue == y.fValue) return 0;
            else if (x.fValue < y.fValue) return 1;
            else return -1;
        }
    }
}
