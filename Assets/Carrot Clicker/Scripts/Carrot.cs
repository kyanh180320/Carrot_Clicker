using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carrot : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Elements")]
    [SerializeField] private Transform carrotRendererTransform;

    [Header("Setting")]
    [SerializeField] private Image fillImage;
    [SerializeField] private float fillRate;
    private void Awake()
    {
        InputManager.onCarrotClicked += CarrotClickedCallback;
    }
    private void OnDestroy()
    {
        InputManager.onCarrotClicked -= CarrotClickedCallback;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void CarrotClickedCallback()
    {
        Animate();
        Fill();
       
       
       
    }
    private void Animate()
    {
        carrotRendererTransform.localScale = Vector3.one * .8f;
        LeanTween.cancel(carrotRendererTransform.gameObject);
        LeanTween.scale(carrotRendererTransform.gameObject, Vector3.one * .7f, .15f).setLoopPingPong(1);
    }
    private void Fill()
    {
        fillImage.fillAmount += fillRate;
        if (fillImage.fillAmount >= 1)
            StartFenzyMode();
    }
    private void StartFenzyMode()
    {
        LeanTween.value(1, 0, 5).setOnUpdate((value) => fillImage.fillAmount = value);
    }
}

