using UnityEngine;

public abstract class Dumper: MonoBehaviour
{
    public abstract bool canDump();

    public abstract void dump(GameObject element);
}
