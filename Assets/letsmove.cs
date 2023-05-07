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
        
        teknogrl.transform.LookAt(targetNode);
        //teknogrl.transform.position = slerpslerpslerp;

        Vector3 nowPOS = teknogrl.transform.position;
        Vector3 mouPOS = targetNode.transform.position;
        //nowmeowmemewoohwoovoodoo Dont worry its a prodigy song. 

        float dontforget = Time.deltaTime;

        Vector3 mewnewv3 = Vector3.Slerp(nowPOS, mouPOS, dontforget);

        teknogrl.transform.position = mewnewv3;
        
        //TODO: trigger proximity bump/collision. 


    }
    
    //helpers
    Transform gettargetnode()
    {
        return nodepathloopup[nodepatharray[currentnodepointer]].GetComponent<Transform>();
    }
    
}
