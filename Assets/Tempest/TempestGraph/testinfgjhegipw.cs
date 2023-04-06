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
        //list of nodes
        //dictionary lookup for node attributes
        [SerializeField] private List<Node> nodes = new List<Node>();
        [SerializeField] private List<Edge> edges = new List<Edge>();
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
        [SerializeField] private Node[] nodes = new Node[2];
    }
}

