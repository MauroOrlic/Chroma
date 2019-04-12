using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject RGBMeter;
    float bulletSpawnY = 0f;
    float bulletSpawnZ = 17f;

    public ColorRGB playerColor;
    void Start()
    {
        playerColor = new ColorRGB(0f, 0f, 0f);
        UpdateColor();
    }

    void Update()
    {

    }
    public void FireBullet()
    {
        GameObject newBullet = Instantiate(bullet, new Vector3(transform.position.x, bulletSpawnY, bulletSpawnZ), bullet.transform.rotation);
        newBullet.GetComponent<BulletBehaviour>().bulletColor = playerColor;
        newBullet.GetComponent<BulletBehaviour>().RGBMeterBehaviour = RGBMeter.GetComponent<RGBMeterBehaviour>();
    }

    void UpdateColor()
    {
        gameObject.GetComponent<Renderer>().material.color = playerColor.getColor();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "enemy(Clone)")
        {
            other.GetComponent<EnemyBehaviour>().Attack();
        }
        if (other.gameObject.name == "juggernaut(Clone)")
        {
            other.GetComponent<JuggernautBehaviour>().Attack();
        }
        if (other.gameObject.name == "splitter(Clone)")
        {
            other.GetComponent<SplitterBehaviour>().Attack();
        }
    }
    public void UpdatePlayerColor()
    {        
        gameObject.GetComponent<Renderer>().material.color = playerColor.getColor();
    }
}
