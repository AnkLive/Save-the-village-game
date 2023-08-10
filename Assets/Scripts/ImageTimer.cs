using UnityEngine;
using UnityEngine.UI;

public class ImageTimer : MonoBehaviour
{
    [SerializeField] private float _time;
    public bool Tick { get; private set; }

    private float _currentTime;
    private Image _img;

    private void Awake() => _currentTime = _time;

    private void Start() => _img = gameObject.GetComponent<Image>();

    private void Update() 
    {
        Tick = false;
        _currentTime -= Time.deltaTime;
         _img.fillAmount = _currentTime / _time;

         if(_currentTime <= 0)
         {
            Tick = true;
            _currentTime = _time;
         }
    }
}
