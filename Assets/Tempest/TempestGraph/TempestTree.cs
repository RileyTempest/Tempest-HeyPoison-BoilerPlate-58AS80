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
    public class Graph<TNode> : IGraphFuncs
        where TNode : Node
    {
        //Ctor
        /*public Graph(List<TNode> _ns, List<Edge> _es)
        {
            nodes = _ns;
            edges = _es;
        }*/
        public Graph(List<XNode.Node> _ns, List<XEdge> _es)
        {
            xNodes = _ns;
            xEdges = _es;
        }

        [SerializeField] private List<TNode> nodes;
        [SerializeField] private List<XNode.Node> xNodes;
        [SerializeField] private List<XEdge> xEdges;

        //ITempestGraph
        object IGraphFuncs.CopyToSerializedObject()
        {
            throw new NotImplementedException();
        }
    }

    [Serializable]
    public class Node
    {
        //Ctor
        public Node(List<XEdge> _xedges)
        {
            xedges = _xedges.ToArray();
        }
        
        private XEdge[] xedges;
    }

    //[Serializable]
    /*public class Edge
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
    }*/
}

namespace Tempest
{
    [Serializable]
    public class TempestGraph : Tempest.Trees.Graph<TempestNode>
    {
        //Ctor
        public TempestGraph() : base(null, null) { }
        public TempestGraph(List<XNode.Node> _ns, List<XEdge> _es) : base(_ns, _es) { }
    }
    
    public class TempestNode : Node, ITempestNode
    {
        //TODO: further encapsulate Ctor by providing XEdges from TempestXNode
        // eg :base(_xNode.GetEdges)
        //Ctor
        public TempestNode(List<XEdge> _xedg, TempestXNode _xNode) : base(_xedg)
        {
            XNode = _xNode;
            NodeAttributes = new TempestNodeAttributes();
            NodeAttributes.matchLabel = _xNode.name;
            NodeAttributes.edges = _xedg;
            Debug.LogWarning("Advisory: TempestNode still needs to ingest NodeMono");
        }

        //TempestNode Fields
        public string matchLabel => NodeAttributes.matchLabel;
        public readonly TempestNodeAttributes NodeAttributes; 
        /*
        //public string matchLabel;
        //public Vector3 worldPOS;
        //public List<Tempest.XEdge> edges;
        //public Vector3[] adjacentPOS;
        */
        
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
        void ITempestNode.Ingest_NodeMono(TempestNodeMono _nm)
        {
            //throw new NotImplementedException();
            NodeMono = _nm;
            NodeMono.name = NodeAttributes.matchLabel;
            Debug.LogWarning("AdvisoryClear: NodeMono has been ingested");
        }
        
        TempestNodeAttributes ITempestNode.RegenerateNodeAttributes(ref TempestXNode _xn, ref TempestNodeMono _nm)
        {
            throw new NotImplementedException();
            
            //much the same routines as InitTempestGraph in TempestNavigationMono
            
            //IsValid
            //IngestXNode
            //IngestNodeMono
        }
    }

    [Serializable]
    public class XEdge
    {
        //Ctor
        public XEdge(XNode.Node _nodeA, XNode.Node _nodeB)
        {
            nodeA = _nodeA;
            nodeB = _nodeB;
        }
        
        //Fields
        public XNode.Node nodeA;
        public XNode.Node nodeB;
    }
    
    public interface IGraphFuncs
    {
        //Define methods for deliverables here
        
        object CopyToSerializedObject();
    }
    
    public interface ITempestNode
    {
        bool IsValid(); //TODO: try catch?

        void Ingest_XNode();
        void Ingest_NodeMono(TempestNodeMono _nm);

        TempestNodeAttributes RegenerateNodeAttributes(ref TempestXNode _xn,
            ref TempestNodeMono _nm);
    }

    public struct TempestGraphAttributes<TNode>
        where TNode : Node
    {
        private List<TNode> nodes;
        private List<XEdge> edges;
    }
    
    public struct TempestNodeAttributes
    {
        public string matchLabel;
        public Vector3 worldPOS;
        public List<Tempest.XEdge> edges;
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

