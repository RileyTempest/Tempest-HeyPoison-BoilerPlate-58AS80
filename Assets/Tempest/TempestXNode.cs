using System;
using System.Collections.Generic;
using Tempest.Trees;
using UnityEngine;
using XNode;

namespace Tempest
{
    [Serializable]
    public class TempestXNode : XNode.Node, IXNodeAttributes
    {
        //Editor Entry
        [SerializeField] private string matchLabel;
        [SerializeField] private Vector3 m_worldPOS;

        //XNode Depend
        [Input] public float input01;
        [Output] public float output01;

        public override object GetValue(NodePort port)
        {
            //Debug.Log("GetValues on TempestXNode are not implemented, null);
            return null;
        }

        //IXNodeAttributes
        public XNode.Node Get_XNode() => this;
        public string Get_MatchLabel() => matchLabel;
        public Vector3 Get_WorldPOS() => m_worldPOS;
        public List<Edge> Get_Edges() => TempestSceneGraph.AcquireEdgesFromSingle(this);

    }
}