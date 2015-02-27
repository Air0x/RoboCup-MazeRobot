using UnityEngine;
using System.Collections;

public class Ultrasound : MonoBehaviour
{			
		RaycastHit Sensor;
		void FixedUpdate ()
		{
				Physics.Raycast (transform.position, Vector3.forward, out Sensor);	
		}
	
		public float sensorDistance { 
				get { return Sensor.distance; }
		}
}
