using UnityEngine;
using System.Collections;

public class Stepmotor : MonoBehaviour
{
		/* http://www.electrokit.com/stegmotor-200-steg-varv-bipolar.45270
		Maximum Speed	 1.89 (revolutions/sec)
		Minium Time/Step	 2.64 (miliseconds)
		Maximum Power	  3.96(Watts)

		Wheel circumference: 20 cm		
		Distance covered during 1 second: 20 * 1.89 = 0.378 m
		v = 0.38 m/s
	 	*/

		private const float stepMotorSpeed = 1.89f; // revolutions/sec
		private const float MaximumPower = 3.96f; // Effect
		private const float WheelCircumference = 0.40f; //m

		public float v{ get { return WheelCircumference * stepMotorSpeed; } } // m/s

		public float distanceCovered = 0f;
		public Vector3 moveOneRevolution ()
		{
				distanceCovered += WheelCircumference; //meters
				return new Vector3 (0f, 0f, v);
		}

		
		private float time = 0f;
		void FixedUpdate ()
		{
				/*time += Time.fixedDeltaTime;
				if (time > 1.89 / 2) {
						Debug.Log (time);
						time = 0f;
				}*/
		}
}
