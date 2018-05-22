using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spawns a building in a radius +- radiusDelta around the player
public class BuildingSpawnController : MonoBehaviour {
    public float distanceForward;
    public float distanceLeft;
    public float spawnMinSecs;
    public float spawnMaxSecs;
    public GameObject building;
    public Transform headTransform;
    public float cooldownTimeSecs;

    private bool readyToSpawn = true;

    void Start()
    {
        building.SetActive(false);
    }

    void Update() {
        // if (readyToSpawn) {
        //     StartCoroutine(SpawnBuilding());
        // }
    }

    private IEnumerator SpawnBuilding()
    {
        readyToSpawn = false;
        yield return new WaitForSeconds(Random.Range(spawnMinSecs, spawnMaxSecs));

        PositionBuildingInFrontOfPlayer(building.transform);
        building.SetActive(true);

        ThisGameManager.canTeleport = false;

        // Cooldown
        yield return new WaitForSeconds(cooldownTimeSecs);
        building.SetActive(false);
        readyToSpawn = true;

        ThisGameManager.canTeleport = true;
    }

    public void PositionBuildingInFrontOfPlayer(Transform buildingTransform)
    {
        Vector3 forward = headTransform.forward;
        forward.y = 0f;
        buildingTransform.rotation = Quaternion.LookRotation(forward);

        Vector3 headForward = headTransform.forward;
        Vector3 headLeft = -headTransform.right;
        headForward.y = 0f;
        headLeft.y = 0f;
        headForward.Normalize();
        headLeft.Normalize();
        buildingTransform.position = headTransform.position + headForward * distanceForward + headLeft * distanceLeft;
    }

}
