using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonUI : SetupBehaviour
{
    [SerializeField] protected Slider slider;
    public Slider Slider => slider;
    [SerializeField] protected Text currentBall;
    public Text CurrentBall => currentBall;
    [SerializeField] protected Text point;
    public Text Point => point;
    [SerializeField] protected Button replay;
    public Button Replay => replay;
    public event Action OnReplay;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetSlider();
        GetCurrentBallText();
        GetPointText();
        GetReplay();
    }
    protected virtual void Start()
    {
        replay.onClick.AddListener(ReplayFunction);
    }
    protected virtual void GetReplay()
    {
        if (replay != null) return;
        replay = GetComponentInChildren<Button>();
        Debug.Log("Reset " + nameof(replay) + " in " + GetType().Name);
    }

    protected virtual void GetPointText()
    {
        if (point != null) return;
        point = transform.Find("Score").Find("Point").GetComponent<Text>();
        Debug.Log("Reset " + nameof(point) + " in " + GetType().Name);
    }

    protected virtual void GetCurrentBallText()
    {
        if (currentBall != null) return;
        currentBall = transform.Find("CannonBallStored").Find("CurrentBall").GetComponent<Text>();
        Debug.Log("Reset " + nameof(currentBall) + " in " + GetType().Name);
    }

    protected virtual void GetSlider()
    {
        if (slider != null) return;
        slider = GetComponentInChildren<Slider>();
        Debug.Log("Reset " + nameof(slider) + " in " + GetType().Name);
    }

    public virtual void ReplayFunction()
    {
        OnReplay?.Invoke();
        slider.value = 0;
    }
}
