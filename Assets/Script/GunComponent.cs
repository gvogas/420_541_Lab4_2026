using UnityEngine;

public class GunComponent : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletMaxImpulse = 100.0f;
    public float maxChargeTime = 3.0f;
    private float chargeTime = 0.0f;
    private bool isCharging = false;

    void Update()
    {

//        This will be done within the Update() function.
// 	You need to detect when the player starts holding the fire button. Use an if condition with the boolean Input.GetButtonDown("Fire1") to detect when the button is initially pressed.
// 	When a player first press down the button the chargetime should reset to 0.


        if (Input.GetButtonDown("Fire1"))
        {
            // Start charging
            chargeTime = 0.0f;
            isCharging = true;
        }

        if (Input.GetButton("Fire1"))
        {
            // Increase charge time while the button is held
            chargeTime += Time.deltaTime;
            chargeTime = Mathf.Clamp(chargeTime, 0, maxChargeTime);
        }

        // TODO add the logic to track player keeping the input down.
        if (Input.GetButtonUp("Fire1"))
        {
            ShootBullet();
            isCharging = false;
        }
    }

   
    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
       
         float bulletImpulse = (chargeTime / maxChargeTime) * bulletMaxImpulse;

        // An impulse is a force you apply on a object in a single instant.
        rb.AddForce(bulletSpawnPoint.forward * bulletImpulse, ForceMode.Impulse);
    }
}
