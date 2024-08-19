using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeAsteroid : MonoBehaviour
{
    private float scaleDuration = 0.2f;

    void Start()
    {
        StartCoroutine(ScaleUpAndDestroy());
    }

    private IEnumerator ScaleUpAndDestroy()
    {
        transform.localScale = Vector3.zero;

        float elapsedTime = 0f;

        while (elapsedTime < scaleDuration)
        {
            float currentScale = Mathf.Lerp(0f, 10f, elapsedTime / scaleDuration);

            transform.localScale = new Vector3(currentScale, currentScale, currentScale);

            elapsedTime += Time.deltaTime;

            yield return null;
        }
        
        transform.localScale = Vector3.one;
        
        gameObject.GetComponent<SphereCollider>().enabled = false;
        
        Destroy(transform.parent.gameObject, 5);
    }
}
