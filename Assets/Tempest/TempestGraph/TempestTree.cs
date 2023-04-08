using System;
using System.Collections.Generic;
using Tempest;
using Tempest.Trees;
using UnityEngine;

//using UnityEngine; //DO NOT USE!!
// using XNode; // Try not to use...

namespace Tempest.Trees
{
    [Serializable]
    public class Graph<TNode> 
        where TNode : Node
    {
        public Graph(List<TNode> _ns, List<Edge> _es)
        {
            nodes = _ns;
            edges = _es;
        }

        [SerializeField] private List<TNode> nodes;
        [SerializeField] private List<Edge> edges;
    }

    [Serializable]
    public class Node
    {
        //Ctor
        public Node(List<Edge> _edges) => edges = _edges.ToArray();

        protected Edge[] edges;
    }
    
    [Serializable]
    public class Edge
    {
        public Edge(XNode.Node _nodeA, XNode.Node _nodeB)
        {
            nodeA = _nodeA;
            nodeB = _nodeB;
        }
        
        public XNode.Node nodeA;
        public XNode.Node nodeB;
    }
}

