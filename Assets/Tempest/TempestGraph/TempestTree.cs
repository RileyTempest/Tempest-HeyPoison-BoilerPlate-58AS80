using System;
using System.Collections.Generic;
using System.Numerics;
using Tempest;

//using UnityEngine; //DO NOT USE!!
// using XNode; // Try not to use...

namespace Tempest.Trees
{
    [Serializable]
    public class Graph<TNode> : ITempestGraph
        where TNode : Node
    {
        //Ctor
        public Graph(List<TNode> _ns, List<Edge> _es)
        {
            nodes = _ns;
            edges = _es;
        }

        private List<TNode> nodes;
        private List<Edge> edges;

        //ITempestGraph
        void ITempestGraph.RegenerateTempestGraph()
        {
            throw new NotImplementedException();
        }
        object ITempestGraph.CopyToSerializedObject()
        {
            throw new NotImplementedException();
        }
    }

    [Serializable]
    public class Node
    {
        //Ctor
        public Node(Edge[] _edges)
        {
            edges = _edges;
        }
        public Node(List<Edge> _edges)
        {
            edges = _edges.ToArray();
        }
        
        private Edge[] edges;
    }

    [Serializable]
    public class Edge
    {
        //Ctor
        public Edge(TempestNode _nodeA, TempestNode _nodeB)
        {
            nodeA = _nodeA;
            nodeB = _nodeB;
        }
        
        //Fields
        public TempestNode nodeA;
        public TempestNode nodeB;
    }
}

namespace Tempest.Trees
{
    public class TempestGraph : Tempest.Trees.Graph<TempestNode>
    {
        //Ctor
        public TempestGraph() : base(null, null) { }
        protected TempestGraph(List<TempestNode> _ns, List<Edge> _es) : base(_ns, _es) { }
    }
    
    public class TempestNode : Node, ITempestNode
    {
        //Ctor
        public TempestNode(TempestXNode _xNode, 
            TempestNodeMono _nodeMono, 
            NodeCtorEdge _init, 
            string _matchlabel) : base(new Edge[(int)_init])
        {
            matchLabel = _matchlabel;
            XNode = _xNode;
            NodeMono = _nodeMono;
        }
        public TempestNode(TempestXNode _xNode, 
            TempestNodeMono _nodeMono, 
            Edge[] _edges, 
            string _matchlabel) : base(_edges)
        {
            matchLabel = _matchlabel;
            XNode = _xNode;
            NodeMono = _nodeMono;
        }

        //TempestNode Fields
        public string matchLabel { get; private set; }
        
        //XNode Fields
        private TempestXNode XNode;
        
        //MonoScene Fields
        private TempestNodeMono NodeMono;
        
        //ITempestNode
        bool ITempestNode.IsValid()
        {
            throw new NotImplementedException();
        }
        void ITempestNode.Ingest_XNode()
        {
            throw new NotImplementedException();
        }
        void ITempestNode.Ingest_NodeMono()
        {
            throw new NotImplementedException();
        }

        TempestNodeAttributes ITempestNode.RegenerateNodeAttributes(ref TempestXNode _xn, ref TempestNodeMono _nm)
        {
            throw new NotImplementedException();
        }
    }

    public interface ITempestGraph
    {
        void RegenerateTempestGraph();
        object CopyToSerializedObject();
    }
    
    public interface ITempestNode
    {
        bool IsValid(); //TODO: try catch?

        void Ingest_XNode();
        void Ingest_NodeMono();

        TempestNodeAttributes RegenerateNodeAttributes(ref TempestXNode _xn,
            ref TempestNodeMono _nm);
    }

    public struct TempestGraphAttributes<TNode>
        where TNode : Node
    {
        private List<TNode> nodes;
        private List<Edge> edges;
    }
    
    public struct TempestNodeAttributes
    {
        public string matchLabel;
        public Vector3 worldPOS;
        public List<Tempest.Trees.Edge> edges;
        public Vector3[] adjacentPOS;
    }

    public enum NodeCtorEdge
    { 
        NoEdges = 0,
        OneEdge = 1,
        EightEdges = 8,
        TwelveEdges = 12
    }


    
    /*****
     *
     *Its true, we need an outlet.
     * Seething is its own agony.
     * We need to be still.
     * Let the wheel spin.
     * Don't forget who you are.
     * What we've seen.
     * It was never a vessel.
     * We know how to take a dive.
     * My nose is noise. 
     * Awe in Hell.
     * 
     */
    
}

