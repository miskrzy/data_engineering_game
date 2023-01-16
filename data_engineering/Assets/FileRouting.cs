using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileRouting : MonoBehaviour
{
    public GameObject fileRouting;
    public GameObject parkingzone;
    public float movementSpeed;
    private Dictionary<int, Vector3> checkpointsPositions;
    private int checkpointsPassed;
    private bool inParkingzone;


    // Start is called before the first frame update
    void Start()
    {
        inParkingzone = false;

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
            if (inParkingzone)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    checkpointsPassed = 1;
                    transform.position = checkpointsPositions[checkpointsPassed];
                    inParkingzone = false;
                    Debug.Log("reprocessed");
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    transform.position = parkingzone.transform.position;
                    inParkingzone = true;
                    Debug.Log("moved to parkingzone");
                }
                else
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
    }
}
