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
    [SerializeField] float bulletVelocity = 1f;
    [SerializeField] Vector2 bulletDir;
    DefaultInputActions defaultInputActions;
    bool firePressed = false;
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
        firePressed = defaultInputActions.Player.Fire.WasPressedThisFrame();
        if(firePressed)
        {
            bulletTemp = Instantiate(bulletPrefab, shootPosition.position, gunBarrel.transform.rotation);
            bulletRb2d = bulletTemp.gameObject.GetComponent<Rigidbody2D>();
            bulletDir = shootPosition.position - gunBarrel.transform.position;
            audiosource.PlayOneShot(shootSound);
            bulletRb2d.velocity = bulletDir * bulletVelocity;

        }

    }

}
