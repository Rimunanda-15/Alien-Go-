using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    private GvrBasePointer gvrPointer;
    private Vector3 raycastPosition;
    private GameManagerX gameManagerX;
    private float bulletSpeed = 200f;
    public GameObject bulletExplosion;
    private int damage = 1;
    private GameObject player;
    private AudioSource bulletExplosionSfx;

    // Start is called before the first frame update
    void Start()
    {
        bulletExplosionSfx = GameObject.Find("EnemyDiedSfx").GetComponent<AudioSource>();
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
        player = GameObject.Find("Player");
        // Get a reference to the active GvrBasePointer
        gvrPointer = GvrPointerInputModule.Pointer;

        Vector3 shootingDirection = new Vector3(0, 0, 0);

        // Check if the raycaster is valid
        if (gvrPointer != null)
        {
            // Get the position of the GvrPointerPhysicsRaycaster
            Vector3 raycastPosition = gvrPointer.GetPointAlongPointer(0f);
            shootingDirection = (raycastPosition - transform.position);
        } else {
            Debug.Log("Pointer is not valid");
        }

        rb = GetComponent<Rigidbody>();
        Vector3 shootingForce = shootingDirection * bulletSpeed;
        rb.AddForce(shootingForce, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > 80)
        {
            Destroy(gameObject);
        }

        if(player.GetComponent<Player>().GetPowerUpStatus())
        {
            damage = 5;
        } else
        {
            damage = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            bulletExplosionSfx.Play();
            other.GetComponent<EnemyMove>().healthPoint -= damage;
            StartCoroutine(ExplodeCoroutine());
        }
    }

    IEnumerator ExplodeCoroutine()
    {
        GameObject instantiatedBulletExplosion = Instantiate(bulletExplosion, transform.position, bulletExplosion.transform.rotation);
        yield return new WaitForSeconds(0.3f);
        Destroy(instantiatedBulletExplosion);
        Destroy(gameObject);
    }
}
