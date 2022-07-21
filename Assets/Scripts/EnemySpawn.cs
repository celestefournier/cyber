using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Enemy robotPrefab;
    [SerializeField] GameController gameController;
    [SerializeField] Timer timer;

    Camera cam;
    Vector2 cameraSize;
    float spawnIntervalBase = 0.4f;

    void Start()
    {
        cam = Camera.main;
        float margin = 0.2f;

        cameraSize = new Vector2(
            cam.orthographicSize * cam.aspect + margin,
            cam.orthographicSize + margin);

        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (!gameController.gameOver)
        {
            var spawnInterval = (1 - timer.totalSeconds / 300) * spawnIntervalBase;

            yield return new WaitForSeconds(spawnInterval);

            Vector3 position = Vector3.zero;
            int side = Random.Range(0, 4);

            if (side == 0) // up
                position = new Vector3(Random.Range(-cameraSize.x, cameraSize.x), cameraSize.y);
            else if (side == 1) // right
                position = new Vector3(cameraSize.x, Random.Range(-cameraSize.y, cameraSize.y));
            else if (side == 2) // down
                position = new Vector3(Random.Range(-cameraSize.x, cameraSize.x), -cameraSize.y);
            else if (side == 3) // left
                position = new Vector3(-cameraSize.x, Random.Range(-cameraSize.y, cameraSize.y));

            position = new Vector3(
                position.x + cam.transform.position.x,
                position.y + cam.transform.position.y, 0);

            Instantiate(robotPrefab, position, Quaternion.identity, transform).Init(player);
        }
    }
}
