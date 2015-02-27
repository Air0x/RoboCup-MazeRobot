using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}

		void record ()
		{
				SendMessage ("addSnapshot", transform.position);
		}
	
		private float time = 0f;
		void FixedUpdate ()
		{
				time += Time.fixedDeltaTime;
				if (time > 1) {
						time = 0f;
						record ();
				}
		}
}
