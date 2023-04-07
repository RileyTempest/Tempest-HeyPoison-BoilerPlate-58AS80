using System;
using System.Collections.Generic;
using UnityEngine;
using Tempest;
using XNode;


//neleex 
namespace Tempest.Trees.Mono
{
    [Serializable]
    public class TempestNavigationMono : TempestNavigationBuss
    {
        //Fields
        [SerializeField] private XNode.SceneGraph SceneGraphComponent;
        [SerializeField] private XNode.NodeGraph XGraph;
        [SerializeField] private GameObject NodeGOPrefab;
        [SerializeField] private Tempest.TempestGraph navigationGraph;

        private IGraphFuncs _graphFuncs => navigationGraph;

        //Event Handlers
        private void InitNavMono()
        {
            if (NodeGOPrefab == null) throw new MissingReferenceException();
            
            navigationGraph = new TempestGraph(); 
            Debug.LogWarning("Navigation Graph is empty/default/ctor parameterless", this);
            SceneGraphComponent = gameObject.GetComponent<XNode.SceneGraph>();
            XGraph = SceneGraphComponent.graph;

        }
        private void RegenerateTempestGraph() { }

        //Init
        public void InitSubscriptions()
        {
            TempestNavigationBuss.TempestGraph_test += InitTempestGraph;
            TempestNavigationBuss.InitSystem += InitNavMono;
            TempestNavigationBuss.Regenerate += RegenerateTempestGraph;
        }
        
        private void InitTempestGraph()
        {
            //TODO:
            Debug.Log("entered InitTempestGraph method", this);

            /*navigationGraph = new TempestGraph(
                AcquireNodes(), 
                AcquireEdges());*/
            
            //running tests
            Debug.Log(
                AcquireXEdgesFromSingleNode(XGraph.nodes[0], "output01")[0].nodeA + "<A B>" +
                AcquireXEdgesFromSingleNode(XGraph.nodes[0], "output01")[0].nodeB + " 2) " +
                AcquireXEdgesFromSingleNode(XGraph.nodes[0], "output01")[1].nodeA + "<A B>" +
                AcquireXEdgesFromSingleNode(XGraph.nodes[0], "output01")[1].nodeB);

        }
        
        //Helpers - graph test
        private List<TempestNode> AcquireNodes(XNode.SceneGraph _sceneGraph, IGraphFuncs _graphFuncs)
        {
            List<TempestNode> returnList = new List<TempestNode>();
            
            //foreach node in Xgraph, 
            //
            //..to make new edge list and pass..
            //..to construct new TempestNode
            //that gets added to the returnList.
            
            return returnList;
        }

        private List<Edge> AcquireEdges(IGraphFuncs _graphFuncs)
        {
            List<Edge> returnList = new List<Edge>();
            
            //crawl ports
            //etc...
            
            return returnList;
        }

        private List<XEdge> AcquireXEdgesFromSingleNode(XNode.Node _node, string _outpuFieldName)
        {
            List<XEdge> returnList = new List<XEdge>();

            List<XNode.NodePort> portList = _node.GetOutputPort(_outpuFieldName).GetConnections();
            Dictionary<XNode.NodePort, XNode.Node> portLookup = new Dictionary<XNode.NodePort, XNode.Node>();

            foreach (NodePort _portal in portList)
            {
                //Debug.Log(_portal.node.name);
                returnList.Add(new XEdge(_node, _portal.node));
            }
            
            return returnList;
        }

        //Override
        public override void EventRefresh_Resubscribe()
        {
            Debug.Log(this.name + " is calling ResubTobuss, override in child");
            InitSubscriptions();
        }
    }
    
    
    /*
     *
     * Maybe I'm a prawn.
     * I like Crawdads. nifty dudes.
     * There always seemed to be a small creek
     * or swamp or lagoon near where I lived
     * The neighborhood kids and I would 'hunt'
     * for them in a drainage ditch for a creek
     * when I was a tiny, not-adult person.
     *
     * I am the borrower of flesh
     * For I wear the skin of my kin.
     * Say this; 'Surely, she is dead.
     * For she eats dead things."
     *
     * How many legs do I have?
     * for me, its difficult to count
     * the days where they stilt.
     * further down, more blurred
     * I've about 12 fount
     * The rest ex'oed, only filt.
     * Down here, they all fit
     * slit'd, seg'men'urr'd.
     *
     *
     * grapes, pitted cherries
     * make a wine or syrup
     * brinned. Mother too.
     * when we're done they'll be
     * easy to chew and take with
     * open oats from dead eyes
     * putrify! putrify! putrify!
     * even Muscadines
     * they all have something to remind...
     * ...infanticide. Hail Betrayer!
     * 
     * 
     */
}