using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orchestrator : MonoBehaviour
{
    public List<GameObject> processorObjects;
    private List<Processor> processors;


    void Start()
    {
        foreach(GameObject processorObject in processorObjects)
        {
            processors.Add(processorObject.GetComponent<Processor>());
        }
    }


    void Update()
    {
        //switch elements between processors



        //do actions in processors
        foreach(Processor processor in processors)
        {
            processor.doProcessing();
        }

    }
}
