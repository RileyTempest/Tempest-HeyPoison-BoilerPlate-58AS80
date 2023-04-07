using Tempest.Trees;
using UnityEngine;
using XNode;

namespace Tempest
{
    public class TempestXNode : XNode.Node //Use this as a diff concrete in Xnode editing. 
    {
        //XNode
        public XNode.Node xNode { get; }

        public TempestNodePayload payload
        {
            get
            {
                if (m_payload.node == null) m_payload = new TempestNodePayload(); 
                
                m_payload.matchLabel = this.name;
                m_payload.node = this;

                return m_payload;
            }
            set //This is dangerous lul. not clean or secure. just for testing TODO:
            {
                if (value.matchLabel != payload.matchLabel) return;
                
                //m_payload.Transform = value.Transform;
                m_payload.worldPOS = value.worldPOS;
            }
        }
        private TempestNodePayload m_payload;

        //XNode Fields //TODO: split into diff classes?
        
        [Input] public float input01;
        [Output] public float output01;

        public override object GetValue(NodePort port)
        {
 
            //Debug.Log(port);
            //Debug.Log(port.Connection.ValueType);

            return null;
        }
    }

    //TODO: write out transform positions. 
    //Setup with nodeX, save to SO, load from SO with static command...look up flags/attributes
    public class TempestGraph : XNode.SceneGraph {
    
    
     }

}