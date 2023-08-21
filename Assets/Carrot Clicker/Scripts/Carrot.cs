using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Elements")]
    [SerializeField] private Transform carrotRendererTransform;
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
        print("hello");
        carrotRendererTransform.localScale = Vector3.one * 0.8f;
        LeanTween.cancel(carrotRendererTransform.gameObject);
        LeanTween.scale(carrotRendererTransform.gameObject, Vector3.one * 0.7f, 0.15f).setLoopPingPong(1);
       
       
    }
}

