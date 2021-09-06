//Sofia Castro :)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Player : MonoBehaviour {
	private Rigidbody2D rb2; //variable que contendrá el componente Rigidbody de la nave
	public float speed;
	public GameObject r1;
	public GameObject r2;
	public GameObject r3;
	public GameObject o1;
	public GameObject o2;
	public GameObject o3;
	public GameObject a1;
	public GameObject a2;
	public GameObject a3;
	public GameObject win;
	private string riddles="";
	private string answers="";
	private int collected = 1;
	public Button oks;
	// Use this for initialization
	void Start () {
		win = GameObject.Find ("th");
		win.SetActive (false);
		rb2 = gameObject.GetComponent<Rigidbody2D>();
		r1 = GameObject.Find ("rid1");
		r1.SetActive (false);
		r2 = GameObject.Find ("rd2");
		r2.SetActive (false);
		r3 = GameObject.Find ("rd3");
		r3.SetActive (false);
		o1 = GameObject.Find ("Obj1");
		o2 = GameObject.Find ("Obj2");
		o3= GameObject.Find ("Obj3");
		a1 = GameObject.Find ("Bat");
		a2 = GameObject.Find ("Cat");
		a3 = GameObject.Find ("Dragon");

		Button okss = oks.GetComponent<Button>();
		okss.onClick.AddListener (TaskonClick);

		Debug.Log ("You are the ladybug, run into an emblem to get a riddle and click ok when you are done.");
		Debug.Log ("Then run into the animal that is the asnwer.");
		Debug.Log ("Watch out, you have to get them in order otherwise you will only start again.");
		Debug.Log("Be careful not to run over an animal before you have seen the riddle");
	}
	
	// Update is called once per frame
	void Update () {
		if (collected > 6) {
			if (riddles==answers) {
				win.SetActive (true);
			} else {
				collected = 0;
				Vector3 reset = new Vector3 (0, 0, 0);
				transform.position = reset;
				o1.SetActive (true);
				o2.SetActive (true);
				o3.SetActive (true);
				a1.SetActive (true);
				a2.SetActive (true);
				a3.SetActive (true);
				}
			}
		
	}
	private void FixedUpdate()
	{
		float movHorizontal = Input.GetAxis("Horizontal"); 
		float movVertical = Input.GetAxis("Vertical");


		Vector3 movement = new Vector3(movHorizontal, movVertical, 0f);

		rb2.AddForce(movement * speed); // se aniade una fuerza al componente rigidbody para que la nave se mueva


	}
	private void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.tag=="Rd1"){
			r1.SetActive (true);
			collected += 1;
			riddles = riddles + "1";
			o1.SetActive (false);
		}
		else if(collision.tag=="Rd2"){
			r2.SetActive (true);
			collected += 1;
			riddles = riddles + "2";
			o2.SetActive (false);
		}
		else if(collision.tag=="Rd3"){
			r3.SetActive (true);
			collected += 1;
			riddles = riddles + "3";
			o3.SetActive (false);
		}
		else if(collision.tag=="B"){
			collected += 1;
			answers = answers + "1";
			a1.SetActive (false);
		}
		else if(collision.tag=="C"){
			collected += 1;
			answers = answers + "2";
			a2.SetActive (false);
		}
		else if(collision.tag=="D"){
			collected += 1;
			answers = answers + "3";
			a3.SetActive (false);
		}

	}
	void TaskonClick(){
		if (r1.activeSelf == true) {
			r1.SetActive (false);
		}
		else if (r2.activeSelf == true) {
			r2.SetActive (false);
		}
		else if (r3.activeSelf == true) {
			r3.SetActive (false);
		}
	}
}
