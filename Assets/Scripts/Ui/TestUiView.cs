using UnityEngine;
using UnityEngine.UI;

namespace Scriptis.Ui
{
    public class TestUiView : MonoBehaviour
    {
        [SerializeField] private Toggle _circleToggle;
        [SerializeField] private Slider _circleSlider;
        [SerializeField] private Canvas _circleCanvas;
        [SerializeField] private Image _circleImage;
        [SerializeField] private Toggle _listToggle;
        [SerializeField] private Scrollbar _listSlider;
        [SerializeField] private Canvas _listCanvas;
    
        private TestUiPresenter _presenter;

        public void Init(TestUiPresenter presenter)
        {
            _presenter = presenter;
        }
        
        public void DisplayCircle()
        {
            _circleCanvas.enabled = true;
        }

        public void HideCircle()
        {
            _circleCanvas.enabled = false;
        }
    
        public void UpdateCircleSlider(float value)
        {
            _circleImage.fillAmount = value;
        }

        public void DisplayList()
        {
            _listCanvas.enabled = true;
        }

        public void HideList()
        {
            _listCanvas.enabled = false;
        }
    
        public void UpdateListSlider(float value)
        {
            
        }
    
        private void OnCircleTogglePressed(bool statue)
        {
            _presenter.HandleCircleTogglePressed(statue);
        }

        private void OnCircleSliderPressed(float value)
        {
            _presenter.HandleCircleSliderPressed(value);
        }

        private void OnListTogglePressed(bool status)
        {
            _presenter.HandleListTogglePressed(status);
        }

        private void OnListSliderPressed(float value)
        {
            _presenter.HandleListSliderPressed(value);
        }

        private void Awake()
        {
            _circleToggle.onValueChanged.AddListener(OnCircleTogglePressed);
            _circleSlider.onValueChanged.AddListener(OnCircleSliderPressed);
            _listToggle.onValueChanged.AddListener(OnListTogglePressed);
            _listSlider.onValueChanged.AddListener(OnListSliderPressed);
        }
    }
}
