using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tempest
{
    interface ITempestNikitaNode
    {
        void Debug_RefreshNodeLines();
    }
    
    [ExecuteInEditMode]
    public class NikitaNode : MonoBehaviour, ITempestNikitaNode
    {
        
        //Properties
        public Dictionary<NikitaNode, Ray> RayLookup;
        //public List<NikitaNode> NodeCollection;
        
        

        private void Update()
        {

            //helperfuntional_DrawLine();
            //helperfuntional_DrawRay();
            //RayLookupInit(ref RayLookup, NodeCollectionInit());
            
            
            Debug.DrawLine(Vector3.zero, Vector3.up, Color.red, 30000.0f);

        }

        void helperfuntional_DrawLine() //white up (x)
        {
            Debug.DrawLine(gameObject.transform.position, (gameObject.transform.up * 2), Color.white );
        }
        
        void helperfuntional_DrawRay() //magenta forward (Z)
        {
            Debug.DrawRay(((Vector3)gameObject.transform.position * 1.5f ), (gameObject.transform.forward * 2), Color.grey);
        }
        
        //

        private void RayLookupInit(ref Dictionary<NikitaNode, Ray> _lookup, List<NikitaNode> _nodes)
        {
            _lookup = new Dictionary<NikitaNode, Ray>();
            
            foreach (NikitaNode node in _nodes)
            {
                Ray thisRay = new Ray(node.transform.position, (node.transform.forward * 6));
                _lookup.Add(node, thisRay);
            }
            
            //drawa debug
            
            Debug.DrawLine(_lookup[this].origin, Vector3.zero, Color.white);

            foreach (KeyValuePair<NikitaNode, Ray> _pair in _lookup)
            {
                Debug.DrawLine(_pair.Value.origin, Vector3.zero, Color.white);
                //Debug.DrawLine(_pair.Value.origin, _pair.Value.direction, Color.white);
            }
            
            Debug.Log("MRayLookpInit complete");
            
        }

        private List<NikitaNode> NodeCollectionInit()
        {
            List<NikitaNode> returnList = new List<NikitaNode>();
            returnList.Add(this);

            return returnList;
        }
        
        
        
        
        
        
        
        //TODO: setup interface
        void ITempestNikitaNode.Debug_RefreshNodeLines()
        {
            RayLookupInit(ref RayLookup, NodeCollectionInit());
        }


    }
}