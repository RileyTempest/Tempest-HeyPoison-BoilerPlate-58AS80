using System;
using System.Collections.Generic;
using Tempest;
using Tempest.Trees;
using UnityEngine;
using XNode;

[Serializable]
public class TempestSceneGraph : SceneGraph
{
    //Fields
    [SerializeField] private List<TempestXNode> TempestNodes;
    [SerializeField] private NodeGraph NodeGraph;
    [SerializeField] private static string OutputFieldName = "output01";
    
    public static List<Edge> AcquireEdgesFromSingle(TempestXNode _xNode)
    {
        List<Edge> returnList = new List<Edge>();
        
        foreach (NodePort _p in _xNode.GetOutputPort(OutputFieldName).GetConnections())
        {
            Edge _xEdge = new Edge(_xNode, _p.node);
            Debug.Log("These should never be the same >:" + _xNode.Get_MatchLabel() + " " + _p.node.name);
        }
        
        //throw new NotImplementedException();
        return returnList;
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    /*public static Dictionary<string, XEdge> AcquireEdgesFromAllNodes(List<Node> _nodes)
    {
        Dictionary<string, XEdge> returnLookup = new Dictionary<string, XEdge>();
        
        foreach (Node _n in (_nodes))
        {
            
        }
        
        
        throw new NotImplementedException();
        return returnLookup;
    }*/
    
    //Context menu item. 
    /*
     * TODO:
     * Load Prefab
     * Field for loading SO graphs, different levels.
     * context menu item for  refreshing, loading
     * Edit graph. XNode
     * 
     *
     *
     * 
     */
}
