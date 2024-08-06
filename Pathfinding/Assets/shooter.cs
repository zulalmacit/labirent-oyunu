using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public GameObject chooseshootingmaterial; // Mermi prefab'ı için referans
    public float bulletspeed = 20f; // Mermi hızı

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bulletvar = Instantiate(chooseshootingmaterial, transform.position, Quaternion.identity); // Mermiyi oluştur
        Rigidbody rb = bulletvar.AddComponent<Rigidbody>(); // Rigidbody bileşeni ekle
        rb.useGravity = false; // Shootng material'ı yerçekimi uygulanmasın
        rb.velocity = transform.forward * bulletspeed; // Shootng material'ı ileri doğru hareket ettir

        // Shootng material'ı belirli bir süre sonra yok etmek (eğer chooseabullet derseniz sorun oluyor dersten hatırlarsanız. Çünkü oluşturanı değil, runtime esnasında oluşanı sileceğiz.)
        Destroy(bulletvar, 2f); // 2 saniye sonra mermiyi yok et
    }
}
