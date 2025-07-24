using System.Collections;
using UnityEngine;

public class ShatteredCube : MonoBehaviour
{
    [SerializeField] float shrinkSpeed = 0.25f;
    public float minScale = 0.1f;

    private void Start()
    {
        StartCoroutine(Shrink());
    }

    public IEnumerator Shrink()
    {
        while (transform.localScale.x > minScale)
        {
            transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
            yield return null;
        }

        // Optional: destroy object after shrinking
        Destroy(gameObject);
    }
}
