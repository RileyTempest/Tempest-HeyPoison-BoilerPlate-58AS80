using System;
using System.Collections.Generic;
using UnityEngine;
using Tempest;
using XNode;

namespace Tempest.Trees.Mono
{
    [Serializable]
    public class TempestNavigationMono : TempestNavigationBuss 
    {
        //Fields
        [SerializeField] private XNode.SceneGraph SceneGraphComponent;
        [SerializeField] private XNode.NodeGraph XGraph;
        [SerializeField] private GameObject NodeGOPrefab;
        [SerializeField] private Tempest.Trees.Graph NavigationGraph;
        
        public List<TempestNodePayload> Payloads;
        public Dictionary<string, TempestNodePayload> NodeLookup;
        public Dictionary<TempestXNode, Edge[]> EdgeLookup;
        public List<Edge> EdgeList = new List<Edge>();
        //Globals
        private Transform[] NodeGOs = null;
        
        //Events/Subs
        public void InitSubscriptions()
        {
            TempestNavigationBuss.SetTransforms += Handler_PullTransformData;
            TempestNavigationBuss.Regenerate += Handler_Regenerate;
            TempestNavigationBuss.CrawlPorts += Handler_CrawlPorts;
        }
        
        //Unity Messages
        private void Awake()
        {
            //throw new NotImplementedException();
        }

        private void Update()
        {
            //throw new NotImplementedException();
        }
        
        //Helper
        private void CountChildrenForGraphUpdate(ref Transform[] _nodegos)
        { 
            _nodegos = GetComponentsInChildren<Transform>();
            foreach (Transform trans in _nodegos)
            {
                Debug.Log(trans + " " + trans.name);
            }
        }
        private void SetChildrenWithPrefab()
        {
            for (int i = NodeGOs.Length - 1; i > 0; i--)
            {
                Debug.Log( " forloop SetChildrenPrefab" + i);
                Instantiate(NodeGOPrefab, 
                    NodeGOs[i].position, 
                    Quaternion.identity.normalized,
                    this.transform);
            }
        }
        private void DestroyOldChildren()
        {
            for (int i = NodeGOs.Length - 1; i > 0; i--)
            {
                DestroyImmediate(NodeGOs[i].gameObject);
            }
        }
        private void InitGlobalFields() //eeewww. This feels gross.
        {
            NodeGOs = null;
        }

        //Helper - EventHandlers
        private void Handler_PullTransformData()
        {
            //update payloads
            SceneGraphComponent = GetComponent<SceneGraph>();
            XGraph = SceneGraphComponent.graph;
            Payloads = new List<TempestNodePayload>();
            foreach (TempestXNode node in XGraph.nodes) //meh fix later
            {
                Payloads.Add(node.payload);
            }

            NodeLookup = new Dictionary<string, TempestNodePayload>();
            foreach (TempestNodePayload payload in Payloads)
            {
                NodeLookup.Add(payload.matchLabel, payload);
            }
            
            
            //
            
            
            List<TempestNodeMono> nodeMonos = new List<TempestNodeMono>();
            nodeMonos.AddRange(GetComponentsInChildren<TempestNodeMono>());
            
            foreach (TempestNodeMono nodemono in nodeMonos)
            {
                Debug.Log(nodemono);
                Debug.Log(nodemono.GetComponent<TempestNodeMono>());
                //Debug.Log(_trans.GetComponent<TempestNodeMono>().Payload.worldPOS);
                nodemono.GetComponent<TempestNodeMono>().Payload.worldPOS = nodemono.transform.position;
                nodemono.GetComponent<TempestNodeMono>().Payload.matchLabel = nodemono.name;

                if (NodeLookup.ContainsKey(nodemono.name)) //need graph.nodes instead
                {
                    foreach (TempestXNode nodey in XGraph.nodes)
                    {
                        if (nodey.payload.matchLabel == nodemono.Payload.matchLabel)
                        {
                            nodey.payload.worldPOS = nodemono.Payload.worldPOS;
                        }
                    }
                }
            }
        }
        private void Handler_Regenerate()
        {
            Debug.Log("entered HandlerRgen method in NavMono");
            
            //update payloads
            SceneGraphComponent = GetComponent<SceneGraph>();
            XGraph = SceneGraphComponent.graph;
            Payloads = new List<TempestNodePayload>();
            foreach (TempestXNode node in XGraph.nodes) //meh fix later
            {
                Payloads.Add(node.payload);
            }

            NodeLookup = new Dictionary<string, TempestNodePayload>();
            foreach (TempestNodePayload payload in Payloads)
            {
                NodeLookup.Add(payload.matchLabel, payload);
            }
            
            //search children for label, add transform to payload
            List<TempestNodeMono> GONodes = new List<TempestNodeMono>();
            GONodes.AddRange(this.GetComponentsInChildren<TempestNodeMono>());
            foreach (TempestNodeMono GONode in GONodes)
            {
                if(GONode.Payload.matchLabel != GONode.name) Debug.Log("Figure out how to name tese");
                
                if (NodeLookup.ContainsKey(GONode.Payload.matchLabel))
                {
                    
                    GONode.Payload.worldPOS = GONode.transform.position;
                    GONode.Payload = NodeLookup[GONode.Payload.matchLabel];

                    NodeLookup[GONode.Payload.matchLabel] = GONode.Payload;
                    
                    //push back to XNode payload
                    foreach (TempestXNode node in XGraph.nodes)
                    {
                        node.payload = NodeLookup[GONode.Payload.matchLabel];
                    }
                    
                } else Debug.Log("matchLable not found in nodelookup. prolly extra Node in Scene -->v" + " " + GONode.name);
                
            }

            CountChildrenForGraphUpdate(ref NodeGOs);
            DestroyOldChildren();
            
            foreach (KeyValuePair<string, TempestNodePayload> pair in NodeLookup)
            {
                GameObject GO = Instantiate(NodeGOPrefab, this.transform);
                GO.name = pair.Value.matchLabel;
                GO.transform.position = pair.Value.worldPOS;
                
                
            }
            
        }

        private void Handler_CrawlPorts()
        {
            EdgeList = new List<Edge>();
            
            SceneGraphComponent = GetComponent<SceneGraph>();
            XGraph = SceneGraphComponent.graph;
            EdgeLookup = new Dictionary<TempestXNode, Edge[]>();

            foreach (TempestXNode _n in XGraph.nodes)
            {
                List<NodePort> nports = new List<NodePort>();
                nports.AddRange(_n.Outputs);
                foreach (NodePort _p in nports)
                {
                    List<NodePort> connections = new List<NodePort>();
                    connections = _n.GetOutputPort("output01")
                        .GetConnections();

                    foreach (NodePort _conn in connections)
                    {
                        Edge _e = new Edge(_n, (TempestXNode)_conn.node);
                        EdgeList.Add(_e);
                    }
                }
                
                
                
                NavigationGraph = new Graph(null, EdgeList);
                
                List<TempestNodeMono> nodeMonos = new List<TempestNodeMono>();
                nodeMonos.AddRange(GameObject.FindObjectsOfType<TempestNodeMono>());

                foreach (Edge _ed in EdgeList)
                {

                    Debug.DrawLine(_ed.nodeA.position,
                        Vector3.zero, Color.magenta, 5.0f);
                    
                    
                }
            }
        }
    }
}