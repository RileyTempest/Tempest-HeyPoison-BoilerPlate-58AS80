using System;
using System.Collections.Generic;
using Tempest;
using UnityEngine;

//using UnityEngine; //DO NOT USE!!
// using XNode; // Try not to use...


namespace Tempest.Trees
{
    [Serializable]
    public class Graph
    {
        //Ctor
        public Graph(List<TempestXNode> _ns, List<Edge> _es)
        {
            nodes = _ns;
            edges = _es;
        }

        [SerializeField] private List<TempestXNode> nodes;
        [SerializeField] private List<Edge> edges;
    }

    [Serializable]
    public class Node
    {
        //edge, list of 
        //verify edges ternary, 
        //'empty' edges? hard limit of edges to 6, 8, 12?
        [SerializeField] private Edge[] edges = new Edge[8];
    }

    [Serializable]
    public class Edge
    {
        //Ctor
        public Edge(TempestXNode _nodeA, TempestXNode _nodeB)
        {
            nodeA = _nodeA;
            nodeB = _nodeB;
        }
        
        //Fields - testing
        [SerializeField] public TempestXNode nodeA;
        [SerializeField] public TempestXNode nodeB;
        
        
        //
        //[SerializeField] private Node[] nodes = new Node[2];
    }
}

