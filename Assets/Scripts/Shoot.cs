using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    int weaponDamage;
    float fireInterval = 0.2f;
    float range = Mathf.Infinity;
    float accuracyOffset = 0.02f;
    public GameObject playerCam;
    bool canFire = true;
    [SerializeField]
    LayerMask mask;
    [SerializeField]
    GameObject bulletPoof;
    [SerializeField]
    GameObject cashPickup;
    [SerializeField]
    GameObject boxDestroyParticle;
    [SerializeField]
    AudioClip boxDestroySound;
//    WeaponBob bob;

	void Start () {
//       bob = GetComponent<WeaponBob>();
	}
	
	void Update () {
        //check to see if the player is pressing the mouse and if they are allowed to shoot
	    if (Input.GetButton("Fire1") && canFire)
        {
            FireWeapon();
        }
	}

    public void UpdateStats (int newDam, float newRate, float newRan, float newOff)
    {
        weaponDamage = newDam;
        fireInterval = newRate;
        range = newRan;
        accuracyOffset = newOff;
    }
    void FireWeapon ()
    {
        //special thanks to the user spuddie for pointing out how to add weapon spread
        Vector3 weaponSpread = transform.TransformDirection(Vector3.forward);
        weaponSpread.x += Random.Range(-accuracyOffset, accuracyOffset);
        weaponSpread.y += Random.Range(-accuracyOffset, accuracyOffset);
        weaponSpread.z += Random.Range(-accuracyOffset, accuracyOffset);
        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position, weaponSpread, out hit, range, mask))
        {
            if (hit.collider.tag == "CashBlock/1")
            {
                GameObject target = hit.collider.gameObject;
                Destroy(target);
                Instantiate(boxDestroyParticle, target.transform.position, Quaternion.Euler(Vector3.zero));
                Instantiate(cashPickup, target.transform.position, Quaternion.Euler(Vector3.zero));
                gameObject.GetComponent<AudioSource>().PlayOneShot(boxDestroySound);
            }
            if (hit.collider.tag == "Platform")
            {
                Instantiate(bulletPoof, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
        StartCoroutine(weaponCooloff(fireInterval));
    }
    IEnumerator weaponCooloff (float delay)
    {
        canFire = false;
//      bob.Recoilvoid(0.02f);
        yield return new WaitForSeconds(delay);
        canFire = true;
    }
}