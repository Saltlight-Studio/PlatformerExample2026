using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] AnimationCurve curve;
    [SerializeField] Transform platform;
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;

    [SerializeField] float maxTime = 2.0f;
    float timer = 0.0f;
    float dir = 1.0f;

    void Update()
    {
        timer += Time.deltaTime * dir;
        
        if (dir == 1.0f && timer >= maxTime)
        {
            dir = -1.0f;
        }
        else if (dir == -1.0f && timer <= 0.0f)
        {
            dir = 1.0f;
        }

        float timeRatio = timer / maxTime;
        timeRatio = curve.Evaluate(timeRatio);
        platform.position = Vector2.Lerp(pointA.position, pointB.position, timeRatio); // 0.0 - 1.0
    }
}
