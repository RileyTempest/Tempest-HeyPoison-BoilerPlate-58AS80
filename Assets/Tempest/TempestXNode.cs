using UnityEngine;
using XNode;

namespace Tempest
{
    public class TempestXNode : XNode.Node, ITempestNode //Use this as a diff concrete in Xnode editing. 
    {
        //ITempestNode
        public Transform Transform { get; set; }
        public bool hasPlayerRB { get; set; }

        //XNode
        public XNode.Node xNode { get; }
        
        //XNode Fields //TODO: split into diff classes?
        
        [Input] public float input01;
        [Input] public float input02;
        [Output] public float output01;
        [Output] public float output02;

        public override object GetValue(NodePort port)
        {
            Debug.Log("TempestNode - GetValue was called IDK");
            return null;
        }

    }
    
    public interface ITempestNode
    {
        //Identity Data
        public Transform Transform { get; }
        
        //Relational Data - Actors/Agents
        public bool hasPlayerRB { get; }
        
        
    }

    //TODO: write out transform positions. 
    //Setup with nodeX, save to SO, load from SO with static command...look up flags/attributes
    public class TempestGraph : XNode.SceneGraph
    {
        
    }
    
}