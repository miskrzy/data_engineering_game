using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orchestrator : MonoBehaviour
{
    public GameObject spawnerObject;
    private Spawner spawner;

    public List<GameObject> processorObjects;
    private List<Processor> processors;

    public GameObject dumperObject;
    private Dumper dumper;


    void Start()
    {
        spawner = spawnerObject.GetComponent<Spawner>();
        if (spawner != null) Debug.Log("Sucessfully retrieved spawner object from " + spawnerObject.name + " game object");
        else throw new System.Exception("Could not retrieve spawner object for " + spawnerObject.name + " game object");

        processors = new List<Processor>();
        foreach (GameObject processorObject in processorObjects)
        {
            Processor processor = processorObject.GetComponent<Processor>();
            if (processor != null) Debug.Log("Sucessfully retrieved processor object from " + processorObject.name + " game object");
            else throw new System.Exception("Could not retrieve processor object for " + processorObject.name + "game object");
            processors.Add(processor);
        }

        dumper = dumperObject.GetComponent<Dumper>();
        if (dumper != null) Debug.Log("Sucessfully retrieved dumper object from " + dumperObject.name + " game object");
        else throw new System.Exception("Could not retrieve dumper object for " + dumperObject.name + "game object");
    }


    void FixedUpdate()
    {
        //spawn element
        Processor firstProcessor = processors[0];
        if(spawner.canSpawn() && firstProcessor.canConsume())
        {
            firstProcessor.consumeElement(spawner.spawn());
        }

        //switch elements between processors
        for (int i = 0; i < processors.Count - 1; i++)
        {
            Processor formerProcessor = processors[i];
            Processor latterProcessor = processors[i + 1];

            if(formerProcessor.canProvide() && latterProcessor.canConsume())
            {
                latterProcessor.consumeElement(formerProcessor.provideElement());
            }
        }

        //dump element
        Processor lastProcessor = processors[^1];
        if (lastProcessor.canProvide() && dumper.canDump())
        {
            dumper.dump(lastProcessor.provideElement());
        }
    }
}
