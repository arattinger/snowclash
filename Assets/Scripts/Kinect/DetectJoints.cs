using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class DetectJoints : MonoBehaviour {
    public GameObject BodySrcManager;
    public JointType TrackedJoint;
    private BodySourceManager bodyManager;

    public float multiplier;

    private Body[] bodies;

    public GameObject cursor;
    // Use this for initialization
    void Start () {
        bodyManager = BodySrcManager.GetComponent<BodySourceManager>();

        if (KinectSensor.GetDefault().IsOpen)
            Debug.Log("ima kinekta");
        else
            Debug.Log("nema kinekta");
    }
	
	// Update is called once per frame
	void Update () {
        if (bodyManager == null)
        {
            return;
        }
        bodies = bodyManager.GetData();

        if(bodies == null)
        {
            return;
        }

        foreach(var body in bodies)
        {
            if(body == null)
            {
                continue;
            }

            if (body.IsTracked)
            {
                if (body.HandRightState == HandState.Open)
                {
                    var pos = body.Joints[TrackedJoint].Position;
                    gameObject.transform.position = new Vector3(multiplier * (pos.X - 0.1f), gameObject.transform.position.y, multiplier * pos.Y);

                    if (!cursor.activeSelf)
                        cursor.SetActive(true);
                }
                else if (body.HandRightState == HandState.Closed)
                {
                    var pos = body.Joints[TrackedJoint].Position;
                    Player.KinectInput(new Vector3(multiplier * (pos.X - 0.1f), gameObject.transform.position.y, multiplier * pos.Y));
                }
            }
        }
	}
}
