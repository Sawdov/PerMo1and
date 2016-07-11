using UnityEngine;
using System.Collections;

public class WeaponBob : MonoBehaviour {

    float boby1;
    float boby2;
    float boby;
    public GameObject weapon;

	void FixedUpdate ()
    {
        if (!(Input.GetAxis("Horizontal")==0) || !(Input.GetAxis("Vertical")==0))
        {
            boby1 += 0.15f;
            boby2 = (Mathf.Sin(boby1) / 2);
            boby = boby2/10;
            weapon.transform.localPosition = new Vector3(0.254f, -0.237f, 0.518f + boby);
        }
    }
    public void Recoilvoid (float delay)
    {
        StartCoroutine(Recoil(delay));
    }
    public IEnumerator Recoil (float delay)
    {
        weapon.transform.Rotate(0, 2, 0);
        yield return new WaitForSeconds(delay);
        weapon.transform.Rotate(0, 2, 0);
        yield return new WaitForSeconds(delay);
        weapon.transform.Rotate(0, 2, 0);
        yield return new WaitForSeconds(delay);
        weapon.transform.Rotate(0, 2, 0);
        yield return new WaitForSeconds(delay);
        weapon.transform.Rotate(0, 2, 0);
        yield return new WaitForSeconds(delay);
        weapon.transform.Rotate(0, -10, 0);
    }
}
