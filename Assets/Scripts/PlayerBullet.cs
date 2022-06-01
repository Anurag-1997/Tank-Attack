using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject gunBarrel;
    [SerializeField] Rigidbody2D bulletRb2d;
    [SerializeField] Transform shootPosition;
    GameObject bulletTemp;
    List<GameObject> bulletTempList;
    [SerializeField] float bulletVelocity = 1f;
    [SerializeField] Vector2 bulletDir;
    [SerializeField] Transform bulletsEmptyObj;
    [SerializeField] float bulletDestroySeconds = 5f;
    //int firePressCount = 0;
    DefaultInputActions defaultInputActions;
    private bool firePressed = false;
    AudioSource audiosource;
    [SerializeField] AudioClip shootSound;
    private void Awake()
    {
        defaultInputActions = new DefaultInputActions();
        audiosource = GetComponent<AudioSource>();
        
    }
    private void Start()
    {
        //bulletRb2d = bulletPrefab.GetComponent<Rigidbody2D>();
        bulletTempList = new List<GameObject>();
        
    }
    private void OnEnable()
    {
        defaultInputActions.Player.Enable();
    }
    private void OnDisable()
    {
        defaultInputActions.Player.Disable();
    }
    private void Update()
    {
        Fire();

    }
    private void Fire()
    {
        firePressed = defaultInputActions.Player.Fire.WasPressedThisFrame();
        if (firePressed)
        {
            //firePressCount += 1;
            bulletTemp = Instantiate(bulletPrefab, shootPosition.position, gunBarrel.transform.rotation);
            bulletTempList.Add( bulletTemp);
            bulletTemp.transform.parent = bulletsEmptyObj.transform;
            bulletRb2d = bulletTemp.gameObject.GetComponent<Rigidbody2D>();
            bulletDir = shootPosition.position - gunBarrel.transform.position;
            audiosource.PlayOneShot(shootSound);
            bulletRb2d.velocity = bulletDir * bulletVelocity;

            //for (int i = 0; i < firePressCount; i++) 
            //{
            //    StartCoroutine(bulletDestroyDelay());
            //}
            foreach (GameObject bullet in bulletTempList)
            {
                StartCoroutine(bulletDestroyDelay(bullet));
            }
            

        }
    }

    IEnumerator bulletDestroyDelay(GameObject bullet)
    {
        yield return new WaitForSeconds(bulletDestroySeconds);
        Destroy(bullet);
    }

}
