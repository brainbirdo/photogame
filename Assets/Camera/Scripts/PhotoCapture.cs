using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoCapture : MonoBehaviour
{
   [Header("Photo Taker")]
   [SerializeField] private Image photoDisplayArea;
   [SerializeField] private GameObject photoFrame;
   [SerializeField] private GameObject cameraUI;

   [Header("Flash Effect")]
   [SerializeField] private GameObject cameraFlash;
   [SerializeField] private float flashTime;

   [Header("Photo Fader Effect")]
   [SerializeField] private Animator fadingAnimation;

    [Header("Audio")]
    [SerializeField] private AudioSource cameraAudio;

    public CameraZoom cameraZoom;

    private Texture2D screenCapture;

   private bool viewingPhoto;
   public bool takingPhoto;

   private void Start()
   {
       screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
       cameraUI.SetActive(false);
   }

   private void Update()
   {
      if (Input.GetMouseButtonDown(1))
        {
            if (!takingPhoto)
            {
                takingPhoto = true;
                cameraUI.SetActive(true);
                cameraZoom.canZoom = true;
            }
            else
            {
                takingPhoto = false;
                cameraUI.SetActive(false);
                cameraZoom.canZoom = false;
            }
        }

      if (Input.GetMouseButtonDown(0))
        {
            if (takingPhoto)
            {
                if (!viewingPhoto)
                {
                    cameraUI.SetActive(true);
                    cameraZoom.canZoom = true;
                    StartCoroutine(CapturePhoto());
                }
            }
        }

      if (takingPhoto == false)
        {
            cameraUI.SetActive(false);
            cameraZoom.canZoom = false;
            cameraFlash.SetActive(false);
        }
   }

   IEnumerator CapturePhoto()
   {
       cameraUI.SetActive(false);
       viewingPhoto = true;
       yield return new WaitForEndOfFrame();

       Rect regionToRead = new Rect (0, 0, Screen.width, Screen.height);

       screenCapture.ReadPixels(regionToRead, 0, 0, false);
       screenCapture.Apply();
       ShowPhoto();
       StartCoroutine(RemovePhoto());
   }

   void ShowPhoto()
   {
       Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
       photoDisplayArea.sprite = photoSprite;

       photoFrame.SetActive(true);
       StartCoroutine(CameraFlashEffect());
       fadingAnimation.Play("PhotoFade");
   }


    IEnumerator CameraFlashEffect()
   {
       cameraAudio.Play();
       cameraFlash.SetActive(true);
       yield return new WaitForSeconds(flashTime);
       cameraFlash.SetActive(false);
   }

   IEnumerator RemovePhoto()
   {
       yield return new WaitForSeconds(2);
       viewingPhoto = false;
       photoFrame.SetActive(false);
       cameraUI.SetActive(true);
   }
}
