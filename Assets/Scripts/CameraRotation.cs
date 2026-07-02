using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float bobSpeed = 5f;      // Скорость качания
    public float bobAmount = 2f;     // Насколько поворачивается камера

    private Quaternion startRotation;
    void Start()
    {
        startRotation = transform.localRotation;
    }

    
    void Update()
    {
        float angle = Mathf.Sin(Time.time * bobSpeed) * bobAmount;
        transform.localRotation = startRotation * Quaternion.Euler(0, 0, angle);
    }
}
