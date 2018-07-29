using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PhoneCamera : MonoBehaviour {

	private bool isCamAvailable;
	private WebCamTexture frontCam;
	private Texture defaultBackground;


	public RawImage background;
	public AspectRatioFitter fit;

	// Use this for initialization
	void Start () {
		// Screen.orientation = ScreenOrientation.Portrait;
		defaultBackground = background.texture;
		WebCamDevice[] devices = WebCamTexture.devices;
		if (devices.Length == 0 ) {
			print("no cameras found");
			isCamAvailable = false;
			return;
		}

		foreach (WebCamDevice device in devices) {
			if(device.isFrontFacing) {
				frontCam = new WebCamTexture(device.name, Screen.width, Screen.height);
			}
		}
		if (frontCam == null) {
			print("unable to find front facing camera");
			return;
		}	
		frontCam.Play();
		background.texture = frontCam;
		isCamAvailable = true;

	}
	
	// Update is called once per frame
	void Update () {
		if (!isCamAvailable) return;
		float ratio = (float) frontCam.width / (float)frontCam.height;
		fit.aspectRatio = ratio;

		float scaleY = frontCam.videoVerticallyMirrored ? -1f : 1f;
		background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

		int orient = frontCam.videoRotationAngle;
		background.rectTransform.localEulerAngles = new Vector3(0,0, orient);
	}
}
