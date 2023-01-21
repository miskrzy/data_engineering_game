using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaDumper : Dumper
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool canDump()
    {
        return true;
    }

    public override void dump(GameObject element)
    {
        Destroy(element);
        Debug.Log("Dumped an object");
    }
}
