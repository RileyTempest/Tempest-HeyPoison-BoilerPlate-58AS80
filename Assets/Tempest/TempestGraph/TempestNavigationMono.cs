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
        //[SerializeField] private XNode.SceneGraph SceneGraphComponent;
        [SerializeField] private static TempestSceneGraph TempestSceneGraphComp;
        [SerializeField] private static XNode.NodeGraph XGraph;
        [SerializeField] private GameObject NodeGOPrefab;
        [SerializeField] protected Tempest.TempestGraph navigationGraph;
        
        private IGraphFuncs _graphFuncs => navigationGraph;
        private string portFieldName = "output01";

        //Event Handlers
        private void InitNavMono()
        {
            if (NodeGOPrefab == null) Debug.LogWarning("NodeGOPrefab is null. Populate with inspector");
            
            navigationGraph = new TempestGraph(); 
            Debug.LogWarning("Navigation Graph is empty/default/ctor parameterless", this);
            
            TempestSceneGraphComp = gameObject.GetComponent<TempestSceneGraph>();
            XGraph = TempestSceneGraphComp.graph;
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
            navigationGraph = new TempestGraph(new List<XNode.Node>()
            {
                XGraph.nodes[0]
            }, 
                AcquireXEdgesFromSingleNode(XGraph.nodes[0], portFieldName)
                );
            
            
            //Proof of Edges inside of TempestNodes, given by reference to TempestXNode. 
            foreach (KeyValuePair<string, TempestNode> _pair in GenerateNodeLookup(XGraph.nodes))
            {
                for (int i = 0; i < _pair.Value.NodeAttributes.edges.Count; i++)
                {
                    Debug.Log(_pair.Value.NodeAttributes.edges[i].nodeA + "<A B> " + _pair.Value.NodeAttributes.edges[i].nodeB);   
                }
            }
            
            /*//Instant TempestNodeMono
            Transform[] transArray = this.transform.GetComponentsInChildren<Transform>();
            for (int i = 0; i < ((transArray.Length) -1); i++)
            {
                Debug.Log(transArray[i].name);
                GameObject.DestroyImmediate(transArray[i].gameObject);
            }*/

            foreach (KeyValuePair<string, TempestNode> _pair in GenerateNodeLookup(XGraph.nodes))
            {
                GameObject newGO = Instantiate(NodeGOPrefab, this.transform);
                TempestNodeMono _nodeMono = newGO.GetComponent<TempestNodeMono>();
                ITempestNodeMonoInit tempestNodeMonoInit = _nodeMono;
                
                tempestNodeMonoInit.Set_TempestNodeField(_pair.Value);
            }
            
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
        private List<XEdge> AcquireEdges(IGraphFuncs _graphFuncs)
        {
            List<XEdge> returnList = new List<XEdge>();
            
            //crawl ports
            //etc...
            
            return returnList;
        }
        private Dictionary<string, TempestNode> GenerateNodeLookup(List<XNode.Node> _nodes)
        {
            Dictionary<string, TempestNode> returnlist = new Dictionary<string, TempestNode>();

            foreach (XNode.Node _n in _nodes)
            {
                returnlist.Add(_n.name, 
                    new TempestNode(AcquireXEdgesFromSingleNode(_n, portFieldName), 
                        (TempestXNode)_n));
            }
            
            return returnlist;
        }
        private List<XEdge> AcquireXEdgesFromSingleNode(XNode.Node _node, string _outpuFieldName)
        {
            List<XEdge> returnList = new List<XEdge>();

            List<XNode.NodePort> portList = _node.GetOutputPort(_outpuFieldName).GetConnections();
            Dictionary<XNode.NodePort, XNode.Node> portLookup = new Dictionary<XNode.NodePort, XNode.Node>();

            foreach (NodePort _portal in portList)
            {
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