using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using XNode;
using Tempest;


//Maybe use a Serialized Object?

namespace Tempest.Trees
{
    [Serializable]
    public class TempestNodePayload
    {
        //XNode Refs
        public TempestXNode node
        {
            get
            {
                return m_node;
            }
            set
            {
                if (m_node == null)
                {
                    m_node = value;
                    return;
                }else Debug.LogWarning("Whoops! that node is already set. Review Code");
            }
        }
        private TempestXNode m_node;
        
        //Scene Refs
        //public Transform Transform;
        
        //Copy Value
        public string matchLabel;
        public Vector3 worldPOS;

        //Properties
        public IEnumerable<NodePort> ports => node.Ports;
        
        //Methods
        public void SetWorldPOS(Vector3 _v3)
        {
            worldPOS = _v3;
        }
        
        /* Xx
         *
         * My initials. ,rtx
         * What is my cipher?
         * What is my code?
         * I like war,
         * Wails like mantras
         * I like contra.
         * Did you know hell is hot?
         * circle circle dot dot.
         * 
         */
    }
}