using System;
using System.Collections.Generic;
using Tempest;
using Tempest.Trees;
using Tempest.Trees.Mono;
using Unity.VisualScripting;
using UnityEngine;
using XNode;
using Edge = Tempest.Trees.Edge;
using Node = XNode.Node;

[Serializable]
public class TempestSceneGraph : SceneGraph, ITempestSceneGraph
{
    //Fields
    [SerializeField] private List<TempestXNode> TempestNodes;
    [SerializeField] private static NodeGraph NodeGraph;
    [SerializeField] private static string OutputFieldName = "output01";
    
    //Init
    public static void temp_InitSeq()
    {
        //throw new NotImplementedException();

        NodeGraph = GameObject.FindObjectOfType<TempestSceneGraph>().graph;
    }

    public static ITempestSceneGraph ITempest_SceneGraph
    {
        get
        {
            if (m_ITempest_SceneGraph == null)
            {
                m_ITempest_SceneGraph = FindObjectOfType<TempestSceneGraph>();
            }

            return m_ITempest_SceneGraph;
        }
    }
    private static ITempestSceneGraph m_ITempest_SceneGraph;

    public static List<Edge> AcquireEdgesFromSingle(TempestXNode _xNode) =>
        ITempest_SceneGraph.AcquireEdgesFromSingle(_xNode);
    
    List<Edge> ITempestSceneGraph.AcquireEdgesFromSingle(TempestXNode _xNode)
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
    
    Dictionary<string, Vector3> ITempestSceneGraph.NodeLabelLookup()
    {
        Dictionary<string, Vector3> returnLookup = new Dictionary<string, Vector3>();

        Debug.Log(NodeGraph);
        foreach (TempestXNode _n in NodeGraph.nodes)
        {
            returnLookup.Add(((TempestXNode)_n).Get_MatchLabel(), Vector3.zero);
            Debug.Log("NodeLabelLookup method " + _n.name);
        }
            
        return returnLookup;
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
