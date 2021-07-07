using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cave;

namespace Cave{

	public enum AnimalType{
		horizontal,   
		rotate,         
	}

	public class Animal : MonoBehaviour {
		public AnimalType animalType=AnimalType.horizontal;
		public RectTransform moveLimite;
		private Vector3 targetPos=new Vector3();
		public float speed;
		private Animator animator;
		private float widthLimite;
		private bool isOn = false;
		public float front=1;
		public float radius = 1f;
		private int i = 0;

		void Start(){
			animator = gameObject.GetComponent<Animator> ();
			if (animalType == AnimalType.horizontal) {
				widthLimite = moveLimite.sizeDelta.x / 2f;
				targetPos = new Vector3 (transform.position.x, transform.position.y, 0f);
				StartCoroutine (SetMovePosition ());
			} else if (animalType == AnimalType.rotate) {
				StartCoroutine (RotateMove ());
			}
		}

		void Update(){
			if (animalType == AnimalType.horizontal) {
				RandomMove ();
			}
		}

		public void RandomMove(){
			if (transform.localPosition != targetPos) {
				if (!isOn) {
					isOn = true;
					animator.SetBool ("on", true);
				}
				transform.localPosition = Vector3.MoveTowards (transform.localPosition, targetPos, speed / 400f);
			} else {
				if (isOn) {
					isOn = false;
					animator.SetBool ("on", false);
				}
			}
		}

		//freedom move
		private IEnumerator SetMovePosition(){
			while (true) {
				float randomX = UnityEngine.Random.Range (-widthLimite, widthLimite);
				targetPos = new Vector3 (randomX, transform.localPosition.y, 0f);
				if (targetPos.x > transform.localPosition.x) {
					transform.localScale = new Vector3 (front, 1, 1);
				} else if (targetPos.x < transform.localPosition.x) {
					transform.localScale = new Vector3 (-front, 1, 1);
				}
				yield return new WaitForSeconds (10f);
			}
		}

		//turn back 
		private IEnumerator RotateMove(){
			while (true) {
				float x = radius * Mathf.Cos (Mathf.PI * i / 180);
				float y = radius * Mathf.Sin (Mathf.PI * i / 180);
				transform.localPosition = new Vector3 (x, y, 0);
				i += 1;
				if (i >= 360) {
					i = 0;
				}
				yield return new WaitForFixedUpdate ();
			}
		} 
	}
}
