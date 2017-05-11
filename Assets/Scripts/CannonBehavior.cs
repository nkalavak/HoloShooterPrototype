using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class CannonBehavior : MonoBehaviour {
    public float ForceMagnitude = 300f;
    private GestureRecognizer _gestureRecognizer;
    public GameObject GazeCursor;

	// Use this for initialization
	void Start () {
        _gestureRecognizer = new GestureRecognizer(); //Provides method to access gestures
        _gestureRecognizer.TappedEvent += GestureRecognizerOnTappedEvent; // Triggered when user taps
        _gestureRecognizer.SetRecognizableGestures(GestureSettings.Tap); //Define type of gestures
        _gestureRecognizer.StartCapturingGestures(); //Start and stop gesture recognition as desired
		
	}

    private void GestureRecognizerOnTappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        Shoot();
    }

    public void Shoot()
    {
        var eyeball = GameObject.CreatePrimitive(PrimitiveType.Sphere); // On tap, create sphere
        eyeball.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        var rigidBody = eyeball.AddComponent<Rigidbody>();
        rigidBody.mass = 0.5f;
        rigidBody.position = transform.position;
        rigidBody.AddForce(transform.forward * ForceMagnitude);
    }

    private void Update()
    {
        if (GazeCursor == null) return;
        //RayCast definition here is generally not recommended
        var raycastHits = Physics.RaycastAll(transform.position, transform.forward); //Assign the transform
        var firstHit = raycastHits.OrderBy(raycastHits => r.distance).FirstOrDefault(); //Use rayCastHit for the closest object
        //Position and orient correctly according to the surface
        //Apply point of ray caster as a tranform position for gaze
        GazeCursor.transform.position = firstHit.point;
        GazeCursor.transform.forward = firstHit.normal;
   
    }
pdate()

}
