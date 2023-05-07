using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class letsmove : MonoBehaviour
{
    //Ctor, properties
    [SerializeField] public GameObject teknogrl;
    [SerializeField] public GameObject node1;
    [SerializeField] public GameObject node2;
    [SerializeField] public GameObject node3;

    [SerializeField] public int[] nodepatharray;
    [SerializeField] public Dictionary<int, GameObject> nodepathloopup;
    [SerializeField] public int currentnodepointer;
    [SerializeField] public Transform targetNode => gettargetnode();
    
    //Unity Messages
    void Start() => init();
    void Update() => runready();

    //Init
    void init()
    {
        if (nodepatharray == null)
        {
            nodepatharray = new[]
            {
                0, 1, 2, 0, 2, 1, 2, 1, 0, 1, 0, 2 //TODO: seed randomly. 
            };
        }

        nodepathloopup = new Dictionary<int, GameObject>()
        {
            { 0, node1 },
            { 1, node2 },
            { 2, node3 }
        };

        if (teknogrl == null)
        {
            Debug.Log("Set teknogirl with inspector to walk nodepath");
        }
    }

    void runready()
    {
        //lerp xy transform or figure out how to call the navmesh. 
        //I'll need to make a navmesh later anyway. YAGNI for time - YAGNIN.
        
        /*//teknogrl.transform.position = slerpslerpslerp;

        Vector3 nowPOS = teknogrl.transform.position;
        Vector3 mouPOS = nowPOS - targetNode.transform.position;
        //nowmeowmemewoohwoovoodoo Dont worry its a prodigy song. 

        float dontforget = Time.deltaTime;

        Vector3 mewnewv3 = Vector3.Lerp(nowPOS, targetNode.transform.position, (dontforget * 0.4f));

        teknogrl.transform.position = mewnewv3;*/


        
        
        
        


        /*Rigidbody tkrb = teknogrl.GetComponent<Rigidbody>();

        Vector3 nowPOS = teknogrl.transform.position;
        Vector3 tarPOS = targetNode.position;
        Vector3 mouPOS = tarPOS - nowPOS;
        
        tkrb.MovePosition(mouPOS);*/


        float dontforget = Time.deltaTime;
        
        Vector3 nowPOS = teknogrl.transform.position;
        Vector3 tarPOS = targetNode.position;
        //Vector3 mouPOS = tarPOS - nowPOS;
        Vector3 ewwPOS = nowPOS + tarPOS;
            
        //Vector3.Scale(tarPOS, nowPOS);
        
        teknogrl.transform.position = Vector3.Lerp(nowPOS, tarPOS, (dontforget * 0.4f));


        float diff = Vector3.Distance(teknogrl.transform.position, tarPOS);
        if( (diff <= 0.5f) )
        {
            Debug.Log("limit reached, changing node target");
            currentnodepointer++;
        }
        
        //
        
        //Vector3 newpos = new Vector3(transform.position.x -2.5f, transform.position.y, transform.position.z);
        
        
        //TODO: trigger proximity bump/collision. 
        //Debug.Log("current target: " + targetNode.name);
        //Debug.Log("");
    }
    
    //helpers
    Transform gettargetnode()
    {
        return nodepathloopup[nodepatharray[currentnodepointer]].GetComponent<Transform>();
    }
    
}
