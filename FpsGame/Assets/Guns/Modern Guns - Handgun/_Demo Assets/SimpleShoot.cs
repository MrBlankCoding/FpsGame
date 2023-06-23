using UnityEngine;
using System.Collections;


[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour
{
    public int maxAmmo = 10;
    private int currentAmmo = -1;
    public float reloadTime = 1f;
    private bool isReloading = false;


    [Header("Prefab Refrences")]
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;


    [Header("Location Refrences")]
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;


    [Header("Settings")]
    [Tooltip("Specify time to destory the casing object")] [SerializeField] private float destroyTimer = 2f;
    [Tooltip("Bullet Speed")] [SerializeField] private float shotPower = 1000f;
    [Tooltip("Casing Ejection Speed")] [SerializeField] private float ejectPower = 150f;




    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;


        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        if(isReloading)
        return;
        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }


        if (Input.GetButtonDown("Fire1"))
        {
            gunAnimator.SetTrigger("Fire");
        }
    }


    IEnumerator Reload()
    {


        isReloading = true;
        Debug.Log("Reloading....")


        yield return new WaitForSeconds(reloadTime);


        currentAmmo = maxAmmo;
        isReloading = false;
    }
   


    void Shoot()
    {
        currentAmmo--;


        if (muzzleFlashPrefab)
        {
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);


            Destroy(tempFlash, destroyTimer);
        }


        if (!bulletPrefab)
        { return; }


        Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);


    }


    void CasingRelease()
    {
        if (!casingExitLocation || !casingPrefab)
        { return; }


        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;


        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
       
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);


        Destroy(tempCasing, destroyTimer);
    }
}
