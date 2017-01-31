using System;
using UnityEngine;
using UnityEngine.UI;

public class AutoShiftUV : MonoBehaviour
{
    public Vector2 uvShiftPerSecond = Vector2.zero;

    private RawImage rawImage;
    private float currentX = 0.0f, currentY = 0.0f;

	private void Awake()
    {
        this.rawImage = this.GetComponent<RawImage>();
	}
	
	private void Update()
    {
        this.currentX = Mathf.Repeat(this.currentX + (uvShiftPerSecond.x * Time.deltaTime), 1.0f);
        this.currentY = Mathf.Repeat(this.currentY + (uvShiftPerSecond.y * Time.deltaTime), 1.0f);

        this.rawImage.uvRect = new Rect(new Vector2(currentX, currentY), this.rawImage.uvRect.size);
	}

}