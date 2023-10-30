using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerShoot : MonoBehaviour {
    public GameObject laser;
    public float delay;
    private bool canShoot = true;
 
    void Update() {
        if (canShoot && Input.GetMouseButton(1)) {
            Instantiate(laser, transform.position, transform.rotation);
            StartCoroutine(Reload());
        }
    }
 
    IEnumerator Reload() {
        canShoot = false;
        yield return new WaitForSeconds(delay);
        canShoot = true;
    }
}