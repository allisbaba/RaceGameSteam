using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCarController : MonoBehaviour
{
    // D�zeltme i�in kullanaca��m�z tu�
    public KeyCode resetKey = KeyCode.R;

    // Arac�n ilk pozisyonu ve rotasyonu
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        // Oyunun ba��nda arac�n ilk pozisyonunu ve rotasyonunu kaydediyoruz
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // Reset tu�una bas�ld���nda arac�n pozisyonunu ve rotasyonunu s�f�rl�yoruz
        if (Input.GetKeyDown(resetKey))
        {
            ResetCar();
        }
    }

    void ResetCar()
    {
        // Arac�n dikey pozisyonunu koruyarak yatay eksendeki rotasyonunu s�f�rl�yoruz
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

        // Arac�n h�z�n� s�f�rl�yoruz
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
