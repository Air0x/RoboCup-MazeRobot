using UnityEngine;
using System.Collections;

public class Debugdata : MonoBehaviour
{
		public Stepmotor L = null;
		public Stepmotor R = null;

		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				guiText.text = 
						"Distance: " + L.distanceCovered + 
						"\nStepmotor-L" +

						"\nDistance: " + R.distanceCovered +
						"\nStepmotor-R";
		}
}
