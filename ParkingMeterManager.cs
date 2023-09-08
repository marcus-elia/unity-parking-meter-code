using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParkingMeterManager : MonoBehaviour
{
    public GameObject geopipe;
    public Transform carTransform;
    public GameObject beaconPrefab;
    public GameObject audioManager;
    public Slider progressBar;
    public TMPro.TextMeshProUGUI percentText;


    public static int numParkingMeters = 0;
    private int totalNumParkingMeters = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in geopipe.transform)
        {
            if (IsParkingMeter(child.gameObject))
            {
                numParkingMeters++;
                GameObject parkingMeter = child.gameObject;
                parkingMeter.AddComponent<ParkingMeter>();
                parkingMeter.GetComponent<ParkingMeter>().SetBeaconPrefab(beaconPrefab);
                parkingMeter.GetComponent<ParkingMeter>().SetCarTransform(carTransform);
                parkingMeter.GetComponent<ParkingMeter>().SetAudioManager(audioManager);
                parkingMeter.GetComponent<ParkingMeter>().Initialize();
            }
            if (IsTree(child.gameObject))
            {
                GameObject inno = child.gameObject;
                inno.AddComponent<InnocentEntity>();
                inno.GetComponent<InnocentEntity>().SetCarTransform(carTransform);
                inno.GetComponent<InnocentEntity>().SetRadius(5);
            }
            if (IsStreetLight(child.gameObject))
            {
                GameObject inno = child.gameObject;
                inno.AddComponent<InnocentEntity>();
                inno.GetComponent<InnocentEntity>().SetCarTransform(carTransform);
                inno.GetComponent<InnocentEntity>().SetRadius(3);
            }
            if (IsBench(child.gameObject))
            {
                GameObject inno = child.gameObject;
                inno.AddComponent<InnocentEntity>();
                inno.GetComponent<InnocentEntity>().SetCarTransform(carTransform);
                inno.GetComponent<InnocentEntity>().SetRadius(3.5f);
            }
        }

        totalNumParkingMeters = numParkingMeters;
    }

    // Update is called once per frame
    void Update()
    {
        progressBar.value = (totalNumParkingMeters - numParkingMeters) / (float)totalNumParkingMeters;
        percentText.text = ((int)((totalNumParkingMeters - numParkingMeters) / (float)totalNumParkingMeters * 100)).ToString();
    }

    private bool StartsWithString(GameObject obj, string s)
    {
        if (obj.name.StartsWith(s))
        {
            return true;
        }


        // Loop through each child
        foreach (Transform child in obj.transform)
        {
            if (StartsWithString(child.gameObject, s))
            {
                return true;
            }
        }
        return false;
    }

    private bool IsParkingMeter(GameObject obj)
    {
        return StartsWithString(obj, "parking_meter");
    }
    private bool IsTree(GameObject obj)
    {
        return StartsWithString(obj, "tree");
    }
    private bool IsStreetLight(GameObject obj)
    {
        return StartsWithString(obj, "street_light");
    }
    private bool IsBench(GameObject obj)
    {
        return StartsWithString(obj, "bench");
    }
}
