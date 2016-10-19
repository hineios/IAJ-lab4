using RAIN.Navigation.Graph;
using UnityEngine;

namespace Assets.Scripts.IAJ.Unity.Pathfinding.Heuristics
{
    public class EuclideanHeuristic : IHeuristic
    {
        public EuclideanHeuristic()
        {
        }

        public float H(NavigationGraphNode node, NavigationGraphNode goalNode)
        {
            float result = 0.0f;
            float xDifference = goalNode.Position.x - node.Position.x;
            float ydifference = goalNode.Position.y - node.Position.y;
            result = Mathf.Sqrt((xDifference * xDifference) + (ydifference * ydifference));

            return (node.Position - goalNode.Position).magnitude;
        }
    }
}