using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    private GvrBasePointer gvrPointer;
    private Vector3 raycastPosition;
    private GameManagerX gameManagerX;
    private float bulletSpeed = 150f;
    public GameObject bulletExplosion;
    private int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
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
