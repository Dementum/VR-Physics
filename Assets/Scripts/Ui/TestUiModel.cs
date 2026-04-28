using Scriptis.Ui;
using UnityEngine;

public class TestUiModel
{
    private bool IsCircleEnabled;
    private float CircleValue;

    private bool IsListEnabled;
    private float ListValue;
    
    private TestUiView _view;
    
    public TestUiModel(TestUiView view)
    {
        _view = view;
    }

    public void SetCircleEnabled(bool enabled)
    {
        IsCircleEnabled = enabled;
        if (enabled)
        {
            _view.DisplayCircle();
        }
        else
        {
            _view.HideCircle();
        }
    }

    public void SetCircleValue(float value)
    {
        _view.UpdateCircleSlider(value);
    }
    
    public void SetListEnabled(bool enabled)
    {
        IsListEnabled = enabled;
        if (enabled)
        {
            _view.DisplayList();
        }
        else
        {
            _view.HideList();
        }
    }

    public void SetListValue(float value)
    {
        _view.UpdateListSlider(value);
    }
}
