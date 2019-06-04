using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicFootSteps : MonoBehaviour
{
    private AudioSource source;
    //public AudioClip cllip;

    private double time;
    private float filterTime;

    public AudioClip defaultSound;
    public AudioClip grassSound;
    public AudioClip bricksSound;
    public AudioClip dodgeSound;

    private string colliderType;

    void Start()
    {
        source = GetComponent<AudioSource>();
        time = AudioSettings.dspTime;
        filterTime = 0.2f;
    }

    private void OnCollisionEnter(Collision col)
    {
        SurfaceColliderType act = col.gameObject.GetComponent<Collider>().gameObject.GetComponent<SurfaceColliderType>();
        if (act)
        {
            colliderType = act.GetTerrainType();
        }
    }

    void PlayStaticFoitsteoSound(int foot_number)
    {
        if (AudioSettings.dspTime < time + filterTime)
        {
            return;
        }

        switch (colliderType)
        {
            case "Grass":
                source.PlayOneShot(grassSound);
                break;
            case "Bricks":
                source.PlayOneShot(bricksSound);
                break;
            default:
                source.PlayOneShot(defaultSound);
                break;
        }
        time = AudioSettings.dspTime;
    }

    void PlayDodge(int foot_number)
    {
        source.PlayOneShot(dodgeSound);
    }


    void Update()
    {
        
    }
}
