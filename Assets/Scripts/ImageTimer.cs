using UnityEngine;
using UnityEngine.UI;

public class ImageTimer : MonoBehaviour
{
    [SerializeField] private float _time;

    private float _currentTime;
    private Image _img;

    private void Awake() => _currentTime = _time;

    private void Start() => _img = gameObject.GetComponent<Image>();

    private void Update() 
    {
        _currentTime -= Time.deltaTime;
         _img.fillAmount = _currentTime / _time;
    }
}
