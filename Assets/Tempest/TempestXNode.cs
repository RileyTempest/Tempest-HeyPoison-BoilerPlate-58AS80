using Tempest.Trees;
using UnityEngine;
using XNode;

namespace Tempest
{
    public class TempestXNode : XNode.Node, ITempestNode //Use this as a diff concrete in Xnode editing. 
    {
        //ITempestNode
        public Transform Transform { get; set; } //TODO: wat? for Review
        public bool hasPlayerRB { get; set; }

        //XNode
        public XNode.Node xNode { get; }

        public TempestNodePayload payload
        {
            get
            {
                m_payload = new TempestNodePayload();

                m_payload.matchLabel = this.name;
                m_payload.node = this;

                return m_payload;
            }
            set //This is dangerous lul. not clean or secure. just for testing TODO:
            {
                if (m_payload.Transform == null)
                {
                    m_payload = new TempestNodePayload();

                    m_payload.matchLabel = this.name;
                    m_payload.node = this;
                    m_payload.Transform = value.Transform;
                    m_payload.worldPOS = value.worldPOS;
                }
                else
                {
                    m_payload.Transform = value.Transform;
                    m_payload.worldPOS = value.worldPOS;
                }
            }
        }
        private TempestNodePayload m_payload;

        //XNode Fields //TODO: split into diff classes?
        
        [Input] public float input01;
        [Input] public float input02;
        [Output] public float output01;
        [Output] public float output02;

        public override object GetValue(NodePort port)
        {
            //TODO: What is a line but a dot, smeared. Connect the dots. 
            Debug.Log("TODO: AH FUCK we have to crawl the outputs to make edges. Shit. What is a line but a  dot, smeared?");
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