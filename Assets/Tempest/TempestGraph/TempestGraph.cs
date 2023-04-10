using System;
using System.Collections.Generic;
using UnityEngine;
using Tempest.Trees;
using Tempest.Trees.Mono;


namespace Tempest.Trees
{
    [Serializable]
    public class TempestGraph : Tempest.Trees.Graph<TempestNode>, ITempestGraph
    {
        //Ctor
        public TempestGraph() : base(null, null) { }
        public TempestGraph(List<TempestNode> _ns, List<Edge> _es) : base(_ns, _es) { }

        private TempestGraphAttributes<TempestNode> GraphAttributes; //TODO:
        //ITempestGraph
        object ITempestGraph.CopyToSerializedObject()
        {
            throw new NotImplementedException();
        }
    }
    
    [Serializable]
    public class TempestNode : Node, ITempestNode
    {
        //Ctor
        public TempestNode(IXNodeAttributes _nodeInterface) : base(_nodeInterface.Get_Edges())
        {
            XNode = (TempestXNode)_nodeInterface.Get_XNode();
            m_NodeAttributes = new TempestNodeAttributes
            {
                matchLabel = _nodeInterface.Get_MatchLabel(),
                worldPOS = _nodeInterface.Get_WorldPOS(),
                edges = _nodeInterface.Get_Edges()
            };
            Debug.LogWarning("Advisory: TempestNode still needs to ingest NodeMono");
        }
        
        //Node Fields
        public TempestXNode XNode { get; private set; }
        public TempestNodeMono NodeMono { get; private set; }
        
        public TempestNodeAttributes NodeAttributes => m_NodeAttributes; 
        [SerializeField] private TempestNodeAttributes m_NodeAttributes; //Keep a concrete field. 

        //Interfaces - ITempestNode
        bool ITempestNode.IsValid() => throw new NotImplementedException();
        void ITempestNode.Ingest_XNode() => throw new NotImplementedException();
        void ITempestNode.Ingest_NodeMono(TempestNodeMono _nm)
        {
            //throw new NotImplementedException(); //TODO:
            NodeMono = _nm;
            //NodeMono.name = NodeAttributes.matchLabel;
            //Debug.LogWarning("AdvisoryClear: NodeMono has been ingested");
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
    
    public interface ITempestGraph
    {
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
        private List<Edge> edges;
    }
    public struct TempestNodeAttributes
    {
        public string matchLabel;
        public Vector3 worldPOS;
        public List<Tempest.Trees.Edge> edges;
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