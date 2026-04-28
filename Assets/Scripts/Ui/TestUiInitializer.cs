using System;
using Scriptis.Ui;
using UnityEngine;

public class TestUiInitializer : MonoBehaviour
{
    [SerializeField] private TestUiModel _model;
    [SerializeField] private TestUiView _view;
    [SerializeField] private TestUiPresenter _presenter;

    private void Awake()
    {
        _model = new TestUiModel(_view);
        _presenter.Init(_model);
        _view.Init(_presenter);
    }
}
