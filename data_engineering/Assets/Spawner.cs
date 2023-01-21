using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    public abstract bool canSpawn();

    public abstract GameObject spawn();
}
