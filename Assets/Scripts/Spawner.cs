using System.Collections;
using UnityEngine;

public class Spwaner : MonoBehaviour
{
    private Collider spwanArea;

    public GameObject[] fruitPrefabs;

    public float minSpwanDelay = 0.25f;
    public float maxSpwanDelay = 1f;

    public float minAngle = -15f;
    public float maxAngle = 15f;

    public float minForce = 18f;
    public float maxForce = 22f;

    public float maxLifetime = 5f;



    private void Awake()
    {

        spwanArea = GetComponent<Collider>();

    }

    private void OnEnable()
    {
        StartCoroutine(Spwan());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Spwan()
    {

        yield return new WaitForSeconds(2f);

        while (enabled)
        {
            GameObject prefab = fruitPrefabs[Random.Range(0, fruitPrefabs.Length)];

            Vector3 position = new Vector3();
            position.x = Random.Range(spwanArea.bounds.min.x, spwanArea.bounds.max.x);
            position.y = Random.Range(spwanArea.bounds.min.y, spwanArea.bounds.max.y);
            position.z = Random.Range(spwanArea.bounds.min.z, spwanArea.bounds.max.z);

            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));

            GameObject fruit = Instantiate(prefab, position, rotation);

            Destroy(fruit, maxLifetime);

            float force = Random.Range(minForce, maxForce);
            fruit.GetComponent<Rigidbody>().AddForce(fruit.transform.up * force, ForceMode.Impulse);

            yield return new WaitForSeconds(Random.Range(minSpwanDelay, maxSpwanDelay));
        }
    }

}
