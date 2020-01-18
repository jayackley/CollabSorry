using UnityEngine;

public class RPGGameManager : MonoBehaviour {

    public SpawnPoint playerSpawnPoint;
    public static RPGGameManager sharedInstance = null;
    public RPGCameraManager cameraManager;

    private void Update()
    {
        {
            if (Input.GetKey("escape"))
            {
                Application.Quit();
            }
        }
    }

    void Awake () {
        if (sharedInstance != null && sharedInstance != this)
        {
            Destroy(gameObject);

        }
        else 
        {
            sharedInstance = this;
        }
    }

    void Start()
    {
        SetupScene();
    }

    public void SetupScene()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        if (playerSpawnPoint != null)
        {
            GameObject player = playerSpawnPoint.SpawnObject();
            cameraManager.virtualCamera.Follow = player.transform;
        }
    }


}
