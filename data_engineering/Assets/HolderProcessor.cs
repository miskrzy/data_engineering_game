using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolderProcessor : Processor
{
    public int framesHolding;
    private int currentFramesHolding;
    private GameObject heldObject;
    // Start is called before the first frame update
    void Start()
    {
        heldObject = null;
        currentFramesHolding = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentFramesHolding++;
    }

    public override bool canConsume()
    {
        if (heldObject == null) return true;
        else return false;
    }

    public override bool canProvide()
    {
        if (currentFramesHolding >= framesHolding && heldObject != null) return true;
        else return false;
    }

    public override void consumeElement(GameObject element)
    {
        if (heldObject != null) throw new System.Exception("Need to have space before consuming an object");
        else
        {
            heldObject = element;
            heldObject.transform.position = transform.position;
        }
        currentFramesHolding = 0;
        Debug.Log("Consumed an object");
    }

    public override GameObject provideElement()
    {
        Debug.Log("Providing an object");
        GameObject objectToProvide = heldObject;
        heldObject = null;
        return objectToProvide;
    }
}
