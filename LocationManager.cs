using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

struct LocationInfo
{
    public string name;
    public Rect rect;
}
public class LocationManager : MonoBehaviour
{
    public TextMeshProUGUI guiText;
    public Transform playerTransform;

    public Transform lincolnLoc;
    public Transform reflectingPoolLoc;
    public Transform ww2Loc;
    public Transform dcWarMemLoc;
    public Transform washingtonMonumentLoc;
    public Transform ellipseLoc;
    public Transform whiteHouseLoc;
    public Transform lafayetteSquareLoc;
    public Transform washingtonCircleLoc;
    public Transform gwuLoc;
    public Transform eisenhowerLoc;
    public Transform trumanLoc;

    private List<LocationInfo> locations = new List<LocationInfo>();
    private string currentLoc = "";

    // Start is called before the first frame update
    void Start()
    {
        LocationInfo lincoln;
        lincoln.rect = new Rect(lincolnLoc.position.x, lincolnLoc.position.z, 250f, 250f);
        lincoln.name = "Lincoln Memorial";
        locations.Add(lincoln);

        LocationInfo reflecting;
        reflecting.rect = new Rect(reflectingPoolLoc.position.x, reflectingPoolLoc.position.z, 650f, 150f);
        reflecting.name = "Reflecting Pool";
        locations.Add(reflecting);

        LocationInfo ww2;
        ww2.rect = new Rect(ww2Loc.position.x, ww2Loc.position.z, 75f, 230f);
        ww2.name = "WWII Memorial";
        locations.Add(ww2);

        LocationInfo dcWarMem;
        dcWarMem.rect = new Rect(dcWarMemLoc.position.x, dcWarMemLoc.position.z, 75f, 75f);
        dcWarMem.name = "DC War Memorial";
        locations.Add(dcWarMem);

        LocationInfo washMon;
        washMon.rect = new Rect(washingtonMonumentLoc.position.x, washingtonMonumentLoc.position.z, 165f, 165f);
        washMon.name = "Washington Monument";
        locations.Add(washMon);

        LocationInfo ellipse;
        ellipse.rect = new Rect(ellipseLoc.position.x, ellipseLoc.position.z, 500f, 350f);
        ellipse.name = "The Ellipse";
        locations.Add(ellipse);

        LocationInfo whiteHouse;
        whiteHouse.rect = new Rect(whiteHouseLoc.position.x, whiteHouseLoc.position.z, 250f, 250f);
        whiteHouse.name = "The White House";
        locations.Add(whiteHouse);

        LocationInfo lafayetteSq;
        lafayetteSq.rect = new Rect(lafayetteSquareLoc.position.x, lafayetteSquareLoc.position.z, 250f, 125f);
        lafayetteSq.name = "Lafayette Square";
        locations.Add(lafayetteSq);

        LocationInfo washCirc;
        washCirc.rect = new Rect(washingtonCircleLoc.position.x, washingtonCircleLoc.position.z, 150f, 150f);
        washCirc.name = "Washington Circle";
        locations.Add(washCirc);

        LocationInfo gwu;
        gwu.rect = new Rect(gwuLoc.position.x, gwuLoc.position.z, 500f, 500f);
        gwu.name = "The George Washington University";
        locations.Add(gwu);

        LocationInfo eeob;
        eeob.rect = new Rect(eisenhowerLoc.position.x, eisenhowerLoc.position.z, 100f, 200f);
        eeob.name = "Eisenhower Executive Office Building";
        locations.Add(eeob);

        LocationInfo hstb;
        hstb.rect = new Rect(trumanLoc.position.x, trumanLoc.position.z, 325f, 275f);
        hstb.name = "Harry S Truman Building";
        locations.Add(hstb);
    }

    // Update is called once per frame
    void Update()
    {
        string newLoc = "";
        float x = playerTransform.position.x;
        float z = playerTransform.position.z;
        foreach (LocationInfo l in locations)
        {
            if (x > l.rect.xMin && x < l.rect.xMax && z > l.rect.yMin && z < l.rect.yMax)
            {
                newLoc = l.name;
                break;
            }
        }
        if (newLoc != currentLoc)
        {
            currentLoc = newLoc;
            guiText.text = currentLoc;
            guiText.alpha = 1f;
        }
        guiText.alpha -= 0.002f;
    }
}
