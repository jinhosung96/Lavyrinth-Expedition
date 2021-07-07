using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cave;
namespace Cave{
	public class MainCameraFollow : MonoBehaviour {
		public float yOffset = 0;
		public float xOffset = 0;
		public float smoothTime = 0.05f; 

		public Transform target; 
		private Vector3 cameraVelocity = Vector3.zero;

		public  Camera cam ;

		[SerializeField]
		void Awake () { 
			cam = transform.GetComponent<Camera> ();
		}

		void Start() {

		}

		void Update(){

		}
			
		void FixedUpdate(){
			if (target.position.x > 8.2 && target.position.x < 187) {
				Vector3 targetPosition = new Vector3 (target.position.x + xOffset, transform.position.y, transform.position.z);
				transform.position = Vector3.SmoothDamp (transform.position, targetPosition, ref cameraVelocity, smoothTime);
			}
		}

	}
}