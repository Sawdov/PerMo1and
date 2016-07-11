using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

//    int health = 100;
    int cash = 100;
//    int score;

	void Start () {
	
	}
	
	void Update () {
	
	}
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "1cash")
        {
            Destroy(other.transform.parent.gameObject);
            cash += 1;
        }
    }
}
