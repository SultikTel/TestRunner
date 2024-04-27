using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private EnemyGroup[] pathPoints;
    [SerializeField] private Player player;
    [SerializeField] CameraMove mainCamera;
    [SerializeField] private int currentPointIndex;
    private void OnEnable()
    {
        player.onStatusChanged += PlayerArrived;
    }
    private void Disable()
    {
        player.onStatusChanged -= PlayerArrived;
    }

    private void Start()
    {
        player.transform.position = pathPoints[currentPointIndex].transform.position;

        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ChangeLocation();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            player.lookAt(pathPoints[currentPointIndex + 1].transform.position);
        }
    }
    public void ChangeLocation()
    {
        if (currentPointIndex + 1 < pathPoints.Length) {
            currentPointIndex++;
            player.ChangePlace(pathPoints[currentPointIndex].transform.position);
            if(currentPointIndex+1!=pathPoints.Length)
            mainCamera.pointToLook = pathPoints[currentPointIndex + 1].transform;
        }

    }

    public void PlayerArrived(bool isWalking)
    {
        
        if (isWalking) return;
        if (currentPointIndex + 1 < pathPoints.Length)
        {
            player.nextPointToLookAt = pathPoints[currentPointIndex + 1].transform;
            if(pathPoints[currentPointIndex + 1].IsAlreadyPassed())
            {
                ChangeLocation();
            }
            pathPoints[currentPointIndex + 1].onSpotCleared += ChangeLocation;
        }

        
    }

    public void CanStartShooting()
    {

    }
}
