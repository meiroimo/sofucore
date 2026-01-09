using System;
using UnityEngine;

public class TemporaryEvent
{
    private float duration;//効果が続く時間
    private Action applyEffect;//効果が発動した時の処理
    private Action removeEffect;//効果が解除された時の処理
    private float timer;//時間計測用
    private bool active;//今動いてるか

    public event Action OnEventFinished;

    public TemporaryEvent(float duration, Action apply, Action remove)
    {
        this.duration = duration;//効果が続く時間
        this.applyEffect = apply;//効果が発動した時の処理
        this.removeEffect = remove;//効果が解除された時の処理
    }

    public void Activate()
    {
        if(applyEffect != null)
        {
            applyEffect.Invoke();
        }
        timer = 0f;
        active = true;
    }

    public void Update(float deltaTime)
    {
        if (!active) return;

        timer += deltaTime;

        if(timer >= duration)
        {
            if(removeEffect != null)
            {
                removeEffect.Invoke();
                active = false;
                OnEventFinished?.Invoke(); // ←イベント終了を通知
            }
        }
    }

    public bool IsActive => active;//外から読める
}
