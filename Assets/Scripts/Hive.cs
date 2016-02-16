using UnityEngine;
using System.Collections;
using System.Linq;

public class Hive : MonoBehaviour {

    public bool Wall_North {
        get {
            return wallNorth.GetComponent<Renderer>().enabled;
        }
        set {
            wallNorth.GetComponent<Renderer>().enabled = value;
            updateCorners();
        }
    }
    public bool Wall_NorthEast {
        get {
            return wallNorthEast.GetComponent<Renderer>().enabled;
        }
        set {
            wallNorthEast.GetComponent<Renderer>().enabled = value;
            updateCorners();
        }
    }
    public bool Wall_NorthWest {
        get {
            return wallNorthWest.GetComponent<Renderer>().enabled;
        }
        set {
            wallNorthWest.GetComponent<Renderer>().enabled = value;
            updateCorners();
        }
    }
    public bool Wall_South {
        get {
            return wallSouth.GetComponent<Renderer>().enabled;
        }
        set {
            wallSouth.GetComponent<Renderer>().enabled = value;
            updateCorners();
        }
    }
    public bool Wall_SouthEast {
        get {
            return wallSouthEast.GetComponent<Renderer>().enabled;
        }
        set {
            wallSouthEast.GetComponent<Renderer>().enabled = value;
            updateCorners();
        }
    }
    public bool Wall_SouthWest {
        get {
            return wallSouthWest.GetComponent<Renderer>().enabled;
        }
        set {
            wallSouthWest.GetComponent<Renderer>().enabled = value;
            updateCorners();
        }
    }

    private GameObject wallNorth;
    private GameObject wallNorthEast;
    private GameObject wallNorthWest;
    private GameObject wallSouth;
    private GameObject wallSouthEast;
    private GameObject wallSouthWest;
    private GameObject cornerEast;
    private GameObject cornerNorthEast;
    private GameObject cornerNorthWest;
    private GameObject cornerWest;
    private GameObject cornerSouthEast;
    private GameObject cornerSouthWest;

    public Hive Hive_North = null;
    public Hive Hive_NorthEast = null;
    public Hive Hive_NorthWest = null;
    public Hive Hive_South = null;
    public Hive Hive_SouthEast = null;
    public Hive Hive_SouthWest = null;

    public bool QueueNeighborUpdate = false;

    public bool Corner_East { get { return (Wall_NorthEast || Wall_SouthEast); } }
    public bool Corner_NorthEast { get { return (Wall_North || Wall_NorthEast); } }
    public bool Corner_SouthEast { get { return (Wall_South || Wall_SouthEast); } }
    public bool Corner_West { get { return (Wall_NorthWest || Wall_SouthWest); } }
    public bool Corner_NorthWest { get { return (Wall_North || Wall_NorthWest); } }
    public bool Corner_SouthWest { get { return (Wall_South || Wall_SouthWest); } }

    // Use this for initialization
    void Start () {
        wallNorth = transform.Find("Entrance_N").gameObject;
        wallNorthEast = transform.Find("Entrance_NE").gameObject;
        wallNorthWest = transform.Find("Entrance_NW").gameObject;
        wallSouth = transform.Find("Entrance_S").gameObject;
        wallSouthEast = transform.Find("Entrance_SE").gameObject;
        wallSouthWest = transform.Find("Entrance_SW").gameObject;
        cornerEast = transform.Find("Corner_E").gameObject;
        cornerNorthEast = transform.Find("Corner_NE").gameObject;
        cornerNorthWest = transform.Find("Corner_NW").gameObject;
        cornerWest = transform.Find("Corner_W").gameObject;
        cornerSouthEast = transform.Find("Corner_SE").gameObject;
        cornerSouthWest = transform.Find("Corner_SW").gameObject;
        UpdateNeighbors();
    }
    public void UpdateNeighbors() {
        var cols = Physics.OverlapSphere(transform.position, .75f).Except(new[] { GetComponent<Collider>() }).Select(c => c.gameObject).ToArray();
        foreach (GameObject g in cols) {
            Hive h = g.GetComponent<Hive>();
            if (h != null) {
                Transform t = g.transform;
                if (t.position.x < transform.position.x) {
                    if (t.position.z < transform.position.z) {
                        h.Hive_SouthWest = this;
                        Hive_NorthEast = h;
                        h.UpdateSides();
                    } else {
                        h.Hive_NorthWest = this;
                        Hive_SouthEast = h;
                        h.UpdateSides();
                    }
                } else if (t.position.x > transform.position.x) {
                    if (t.position.z < transform.position.z) {
                        h.Hive_SouthEast = this;
                        Hive_NorthWest = h;
                        h.UpdateSides();
                    } else {
                        h.Hive_NorthEast = this;
                        Hive_SouthWest = h;
                        h.UpdateSides();
                    }
                } else {
                    if (t.position.z < transform.position.z) {
                        h.Hive_South = this;
                        Hive_North = h;
                        h.UpdateSides();
                    } else {
                        h.Hive_North = this;
                        Hive_South = h;
                        h.UpdateSides();
                    }
                }
            }
        }
        UpdateSides();
    }
    public void UpdateSides() {
        if (Hive_South != null) Wall_South = false;
        if (Hive_North != null) Wall_North = false;
        if (Hive_NorthEast != null) Wall_NorthEast = false;
        if (Hive_NorthWest != null) Wall_NorthWest = false;
        if (Hive_SouthEast != null) Wall_SouthEast = false;
        if (Hive_SouthWest != null) Wall_SouthWest = false;
    }
	
    private void updateCorners() {
        cornerEast.GetComponent<Renderer>().enabled = Corner_East;
        cornerNorthEast.GetComponent<Renderer>().enabled = Corner_NorthEast;
        cornerNorthWest.GetComponent<Renderer>().enabled = Corner_NorthWest;
        cornerWest.GetComponent<Renderer>().enabled = Corner_West;
        cornerSouthWest.GetComponent<Renderer>().enabled = Corner_SouthWest;
        cornerSouthEast.GetComponent<Renderer>().enabled = Corner_SouthEast;
    }

	void Update () {
	    if(QueueNeighborUpdate) {
            UpdateNeighbors();
            QueueNeighborUpdate = false;
        }
	}
}
