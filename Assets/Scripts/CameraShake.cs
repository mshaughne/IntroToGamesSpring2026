using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Camera cam;
    Vector3 originPos;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        originPos = cam.transform.localPosition;
    }

    public void CamShakeStart(float duration, float intensity)
    {
        StartCoroutine(CamShake(duration, intensity));
    }

    IEnumerator CamShake(float duration, float intensity)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float xPos = Random.Range(-intensity, intensity);
            float yPos = Random.Range(-intensity, intensity);
            cam.transform.localPosition = originPos + new Vector3(xPos, yPos, 0f);
            elapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        cam.transform.localPosition = originPos;
    }
}
