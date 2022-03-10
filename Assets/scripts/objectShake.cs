using UnityEngine;
using System.Collections;

/// http://www.mikedoesweb.com/2012/camera-shake-in-unity/

public class objectShake : MonoBehaviour {

	private Vector3 originPosition;
	private Quaternion originRotation;
	public float shake_decay = 0.002f;
	public float shakePositionIntensity = 30f;
	public float shake_intensity = .3f;

	private float temp_shake_intensity = 0;

    private RectTransform rectTransform;

    void Start() {
        rectTransform = GetComponent<RectTransform>();
        originPosition = rectTransform.position;
        originRotation = rectTransform.rotation;
        

    }

	void Update (){
		if (temp_shake_intensity > 0){
            rectTransform.position = originPosition + shakePositionIntensity * Random.insideUnitSphere * temp_shake_intensity;
            rectTransform.rotation = new Quaternion(
				originRotation.x + Random.Range (-temp_shake_intensity,temp_shake_intensity) * .2f,
				originRotation.y + Random.Range (-temp_shake_intensity,temp_shake_intensity) * .2f,
				originRotation.z + Random.Range (-temp_shake_intensity,temp_shake_intensity) * .2f,
				originRotation.w + Random.Range (-temp_shake_intensity,temp_shake_intensity) * .2f);
			temp_shake_intensity -= shake_decay;
		}
	}

    

    public void Shake(){
		
		temp_shake_intensity = shake_intensity;

	}
}