using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;

    MouseController mouseCon;
    PlayerController playerCon;
    Transform spawnPointTran;
    SpriteRenderer muzzleFlash;

    public float mzFlashTime;
    private float mzFlashTimer;

    // Start is called before the first frame update
    void Start()
    {
        mouseCon = GameObject.Find("Main Camera").GetComponent<MouseController>();
        playerCon = transform.GetComponentInParent<PlayerController>();
        spawnPointTran = transform.Find("SpawnPoint").GetComponent<Transform>();
        muzzleFlash = spawnPointTran.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 shotDir = mouseCon.getWorldMousePos() - transform.position;
        if(playerCon.facingRight) {
            transform.right = shotDir;
        }
        else {
            transform.right = -shotDir;
        }

        if(Input.GetButtonDown("Fire1")) {
            GameObject g = Instantiate(bulletPrefab, spawnPointTran.position, Quaternion.identity);
            //Example of 1 script using another
            g.GetComponent<BulletController>().shoot(shotDir);
            muzzleFlash.enabled = true;
            mzFlashTimer = mzFlashTime;
        }
        
        //turn off muzzle flash after timer
        mzFlashTimer -= Time.deltaTime;
        if(mzFlashTimer <= 0) {
            muzzleFlash.enabled = false;
        }

        
    }
}
