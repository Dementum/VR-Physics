using System;
using UnityEngine;

namespace Scripts.Ui
{
    public class TestUiPresenter : MonoBehaviour
    {
        private TestUiModel _model;
        
        public void HandleCircleTogglePressed(bool status)
        {
            _model.SetCircleEnabled(status);
        }

        public void HandleCircleSliderPressed(float value)
        {
            _model.SetCircleValue(value);
        }

        public void HandleListTogglePressed(bool status)
        {
            _model.SetListEnabled(status);
        }

        public void HandleListSliderPressed(float value)
        {
            _model.SetListValue(value);
        }

        public void Init(TestUiModel model)
        {
            _model = model;
        }
    }
}
