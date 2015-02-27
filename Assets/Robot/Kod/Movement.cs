using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

		//General data
		private float robotRotation = 0f;
		//

		//Sensors
		private Ultrasound ultraSoundL = null;
		private Ultrasound ultraSoundR = null;
		private Ultrasound ultraSoundF = null;
		private bool ultrasoundEnable = false;
		//

		//Stepmotor
		private Stepmotor stepmotorL = null;
		private Stepmotor stepmotorR = null;
		//

		void Start ()
		{
				ultraSoundL = GameObject.Find ("AvståndssensorL").GetComponent<Ultrasound> ();
				ultraSoundR = GameObject.Find ("AvståndssensorR").GetComponent<Ultrasound> ();
				ultraSoundF = GameObject.Find ("AvståndssensorF").GetComponent<Ultrasound> ();
				
				stepmotorL = GameObject.Find ("StepmotorL").GetComponent<Stepmotor> ();
				stepmotorR = GameObject.Find ("StepmotorR").GetComponent<Stepmotor> ();

				if (ultraSoundF && ultraSoundL && ultraSoundR) {
						Debug.Log ("[+] All ultrasound sensors init");
						ultrasoundEnable = true;		
				}
		}
		private RaycastHit hitInfoL;
		private RaycastHit hitInfoR;
		private RaycastHit hitInfoF;

		private float time = 0f;
		void FixedUpdate ()
		{
				time += Time.fixedDeltaTime;
				if (time > 1f) {
						time = 0f;
						rigidbody.velocity = stepmotorL.moveOneRevolution ();
						rigidbody.velocity = stepmotorR.moveOneRevolution ();
				}
		
				//Ultrasound sensors
				if (ultrasoundEnable) {
			
						Debug.DrawRay (ultraSoundL.transform.position, transform.TransformDirection (Vector3.left), Color.red);
						Debug.DrawRay (ultraSoundR.transform.position, transform.TransformDirection (Vector3.right), Color.red);
						Debug.DrawRay (ultraSoundF.transform.position, transform.TransformDirection (Vector3.forward), Color.red);
			
						Physics.Raycast (ultraSoundL.transform.position, transform.TransformDirection (Vector3.left), out hitInfoL);
						Physics.Raycast (ultraSoundR.transform.position, transform.TransformDirection (Vector3.right), out hitInfoR);
						Physics.Raycast (ultraSoundF.transform.position, transform.TransformDirection (Vector3.forward), out hitInfoF);
				}

		}


		//v * t = x(rot velocity)
		//v = 3,96 (1.98 * 2) / 7,5 cm = 0,528 rad/s
		private const float rad = 0.528f;
		private void rotate (float degrees)
		{
				robotRotation += degrees;
				transform.RotateAround (transform.position, transform.up, degrees);
		}

		void logic ()
		{
		
				//Kalibrera i sidled
				if (hitInfoL.distance > hitInfoR.distance) 
						transform.position -= new Vector3 (0.01f, 0f, 0f);
				else 
						transform.position += new Vector3 (0.01f, 0f, 0f);
		}


		private float timeCal = 0f;
		void Update ()
		{

				//rotate (Mathf.Rad2Deg * rad * Time.deltaTime);

				//Ultrasound sensors
				if (ultrasoundEnable) {
						timeCal += Time.fixedDeltaTime;

						//Kalibrera varje sekund
						if (timeCal > 0.25f) {
								timeCal = 0f;
								logic ();
						}

				}
		}
}
