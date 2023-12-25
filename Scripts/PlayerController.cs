using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletGO;
    public Transform bulletSpawnTransform;
    private float bulletSpeed = 13f;
    bool isShootingOn;
    Animator playerAnimator;
    Transform playerSpawnerCenter;
    float goingToCenterSpeed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        playerSpawnerCenter = transform.parent.gameObject.transform;
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerSpawnerCenter.position, Time.fixedDeltaTime * goingToCenterSpeed);
    }

    public void StartShooting()
    {
        StartShootingAnim();
        isShootingOn = true;
        StartCoroutine(Shooting());
    }

    public void StopShooting()
    {
        isShootingOn = false;
        StartRunAnim();
    }

    IEnumerator Shooting()
    {
        while (isShootingOn)
        {
            yield return new WaitForSeconds(0.5f);
            Shoot();
            yield return new WaitForSeconds(2f);
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletGO, bulletSpawnTransform.position, Quaternion.identity);
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
        bulletRB.velocity = transform.forward * bulletSpeed;
    }

    private void StartShootingAnim()
    {
        playerAnimator.SetBool("isShootingOn", true);
        playerAnimator.SetBool("isRunning", false);
    }

    private void StartRunAnim()
    {
        playerAnimator.SetBool("isShootingOn", false);
        playerAnimator.SetBool("isRunning", true);
    }

    public void StartIdleAnim()
    {
        playerAnimator.SetBool("isRunning", false);
        playerAnimator.SetBool("isLevelFinished", true);
    }
}
