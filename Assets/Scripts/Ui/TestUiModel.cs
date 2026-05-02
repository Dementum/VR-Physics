using Scripts.Ui;

public class TestUiModel
{
    private float CircleValue;
    private float ListValue;
    
    private TestUiView _view;
    
    public TestUiModel(TestUiView view)
    {
        _view = view;
    }

    public void SetCircleEnabled(bool enabled)
    {
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
