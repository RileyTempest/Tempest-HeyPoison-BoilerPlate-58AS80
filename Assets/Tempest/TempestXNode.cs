using System;
using Tempest.Trees;
using UnityEngine;
using XNode;

namespace Tempest
{
    [Serializable]
    public class TempestXNode : XNode.Node
    {
        [SerializeField] private string matchLabel;
        
        [Input] public float input01;
        [Output] public float output01;

        public override object GetValue(NodePort port)
        {
 
            //Debug.Log(port);
            //Debug.Log(port.Connection.ValueType);
            return null;
        }
    }
}