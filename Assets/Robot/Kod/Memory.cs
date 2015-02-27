using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class Memory : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
				
		}


		//Arduino memory: 16 KB
		List<Vector3> memory = new List<Vector3> ();
		void addSnapshot (Vector3 snapShot)
		{
				memory.Add (snapShot);	
				//Debug.Log ("Memory added: " + snapShot);
		}

		void Update ()
		{
	
		}
}
