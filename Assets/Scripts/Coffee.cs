using UnityEngine;
using System.Collections;

public class Coffee : MonoBehaviour {

    // SET FILL RATE IN UNITY

    public GameObject coffeeLiquid;
    VRThrowable coffeeThrowable;
    Transform coffeeLiquidTransform;
    AudioSource coffeeAudioSource;
    public float fillRate;
    float fillAmount;
    Vector3 initialScale;

    public AudioClip[] sip;
    public AudioClip spill;

    void Update() {
        if(fillAmount >= 0 && Vector3.Dot(coffeeLiquidTransform.up, Vector3.down) > 0)
        {
            // EMPTY CUP
            fillAmount = 0;
            coffeeLiquidTransform.localScale = initialScale;
            if( coffeeThrowable.attached )
            {
                coffeeAudioSource.clip = sip[Random.Range(0, sip.Length)];
            } else {
                coffeeAudioSource.clip = spill;
            }

            coffeeAudioSource.Play();
        }
    }

    void Start () {
        fillAmount = 0;
        coffeeThrowable = this.GetComponent<VRThrowable>();
        coffeeLiquidTransform = coffeeLiquid.GetComponent<Transform>();
        initialScale = coffeeLiquidTransform.localScale;
    }

    // void OnTriggerEnter(Collider other) {
    //     if(other.gameObject.tag == "CoffeeCollider")
    //     {
    //         Debug.Log("Coffee Mug Entered Trigger");
    //     }
    // }

    void OnTriggerStay(Collider other) {
        if(other.gameObject.tag == "CoffeeCollider")
        {
            fillAmount += fillRate;
            coffeeLiquidTransform.localScale = initialScale + (Vector3.up * (fillAmount / 100));
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "CoffeeCollider")
        {
            Debug.Log("Coffee Mug Exited Trigger: Total Fill = " + fillAmount);
        }
    }
}
