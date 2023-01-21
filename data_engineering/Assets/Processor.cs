using UnityEngine;

public abstract class Processor : MonoBehaviour
{
    public abstract bool canProvide();

    public abstract bool canConsume();

    public abstract void consumeElement(GameObject element);

    public abstract GameObject provideElement();
}
