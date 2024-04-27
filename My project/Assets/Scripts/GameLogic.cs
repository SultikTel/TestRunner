using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private EnemyGroup[] pathPoints;
    [SerializeField] private Player player;
    [SerializeField] CameraMove mainCamera;
    [SerializeField] private int currentPointIndex;
    [SerializeField] private ShootingSystem shootingSystem;
    [SerializeField] private Curtain curtain;
    private void OnEnable()
    {
        player.onStatusChanged += PlayerArrived;
    }
    private void Disable()
    {
        player.onStatusChanged -= PlayerArrived;
    }
    private void Update()
    {
        if ((Input.GetMouseButtonDown(0)) && currentPointIndex == 0)
        {
            shootingSystem.enabled = true;
            curtain.gameObject.SetActive(false);
            ChangeLocation();
        }


    }
    public void ChangeLocation()
    {
        if (currentPointIndex + 1 < pathPoints.Length) {
            currentPointIndex++;
            player.ChangePlace(pathPoints[currentPointIndex].transform.position);
            if(currentPointIndex+1!=pathPoints.Length)
            mainCamera.NewPointToLook(pathPoints[currentPointIndex + 1].transform);
        }

    }

    public void PlayerArrived(bool isWalking)
    {
        
        if (isWalking) return;
        if (currentPointIndex + 1 < pathPoints.Length)
        {
            player.changeLookPoint(pathPoints[currentPointIndex + 1].transform.position);
            if(pathPoints[currentPointIndex + 1].IsAlreadyPassed())
            {
                ChangeLocation();
                return;
            }
            pathPoints[currentPointIndex + 1].onSpotCleared += ChangeLocation;
        }
        else
        {
            curtain.gameObject.SetActive(true);
            shootingSystem.enabled = false;
            curtain.ChangeText("You won.Level will Restart");
            StartCoroutine(ReloadScene());
        }
    }

    
    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
