using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingMeter : MonoBehaviour
{
    private Transform carTransform;
    private GameObject beaconPrefab;
    private GameObject audioManager;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(carTransform.position, transform.position) < 3.0f)
        {
            gameObject.SetActive(false);
            ParkingMeterManager.numParkingMeters--;
            ScoreManager.score += 10;
            // audioManager.GetComponent<AudioManager>().PlayNextSongClip();
        }
    }

    public void SetCarTransform(Transform t)
    {
        carTransform = t;
    }
    public void SetBeaconPrefab(GameObject g)
    {
        beaconPrefab = g;
    }
    public void SetAudioManager(GameObject g)
    {
        audioManager = g;
    }

    public void Initialize()
    {
        GameObject beacon = Instantiate(beaconPrefab);
        beacon.transform.SetParent(transform);
        beacon.transform.localPosition = Vector3.zero;
    }
}
