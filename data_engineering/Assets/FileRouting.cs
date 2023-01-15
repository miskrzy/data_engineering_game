using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileRouting : MonoBehaviour
{
    public GameObject fileRouting;
    public float movementSpeed;
    private Dictionary<int, Vector3> checkpointsPositions;
    private int checkpointsPassed;


    // Start is called before the first frame update
    void Start()
    {
        checkpointsPositions = new Dictionary<int, Vector3>();
        int cnt = 1;
        foreach (Transform childTransform in fileRouting.transform)
        {
            checkpointsPositions[cnt] = childTransform.position;
            Debug.Log("Found " + cnt + " position of a checkpoint: " + childTransform.name + ", position: " + childTransform.position);
            cnt += 1;
        }

        transform.position = checkpointsPositions[1];
        checkpointsPassed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkpointsPositions.Count > checkpointsPassed)
        {
            Vector3 startPoint = checkpointsPositions[checkpointsPassed];
            Vector3 endPoint = checkpointsPositions[checkpointsPassed + 1];
            Vector3 direction = (endPoint - startPoint).normalized;

            transform.position += (direction * movementSpeed) * Time.deltaTime;

            float pathToPass = (endPoint - startPoint).magnitude;
            float pathPassed = (transform.position - startPoint).magnitude;

            if (pathPassed >= pathToPass)
            {
                transform.position = endPoint;
                checkpointsPassed += 1;
            }
        }
    }
}
