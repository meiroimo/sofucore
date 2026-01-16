using System;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public EventAlertUI eventAlertUI;

    private List<TemporaryEvent> activeEvents = new List<TemporaryEvent>();
    private Queue<Func<TemporaryEvent>> eventQueue = new Queue<Func<TemporaryEvent>>();

    private List<Func<TemporaryEvent>> eventPool = new List<Func<TemporaryEvent>>();


    private bool eventRunning = false;
    private float intervalBetweenEvents = 12f;//イベント間隔
    private float intervalTimer = 0f;

    private void Start()
    {
        // イベントをキューに登録
        eventQueue.Enqueue(() => CreateSmallEnemyRushEvent(8f));
        eventQueue.Enqueue(() => CreateEnemySizeBoostEvent(10f));
        //eventQueue.Enqueue(() => CreateEnemySizeDeBoostEvent(10f));
        eventQueue.Enqueue(() => CreateSpawnSpeedBoostEvent(8f));
        eventQueue.Enqueue(() => CreateSpawnCountBoostEvent(10f));
    }

    private void Update()
    {
        float dt = Time.deltaTime;

        // 全イベント更新
        foreach (var e in activeEvents)
        {
            e.Update(dt);
        }

        // 終了したイベントを削除
        activeEvents.RemoveAll(e => !e.IsActive);

        // 新しいイベントが無ければ処理しない
        if (eventRunning || eventQueue.Count == 0)
        {
            return;
        }

        // インターバル経過したら次のイベント開始
        intervalTimer += dt;
        if (intervalTimer >= intervalBetweenEvents)
        {
            intervalTimer = 0f;
            StartNextEvent();
        }
    }

    private int lastEventIndex = -1;

    private void RandomNextEvent()
    {
        if (ResultClear.Instance.isGameClear) return;
        if (eventPool.Count == 0) return;

        int index;

        while (true)
        {
            index = UnityEngine.Random.Range(0, eventPool.Count);

            if (index != lastEventIndex || eventPool.Count == 1)
                break;
        }

        lastEventIndex = index;

        var eventFactory = eventPool[index];
        TemporaryEvent ev = eventFactory.Invoke();

        ev.OnEventFinished += () => eventRunning = false;
        ev.Activate();
        activeEvents.Add(ev);
        eventRunning = true;
    }

    private void StartNextEvent()
    {
        if (ResultClear.Instance.isGameClear) return;
        if (eventQueue.Count == 0) return;

        var eventFactory = eventQueue.Dequeue();
        TemporaryEvent ev = eventFactory.Invoke();

        ev.OnEventFinished += () => eventRunning = false;
        ev.Activate();
        activeEvents.Add(ev);
        eventRunning = true;

        eventQueue.Enqueue(eventFactory);
    }

    private TemporaryEvent CreateSmallEnemyRushEvent(float duration)
    {
        float oriAttakRate = enemySpawner.enemyAttackRate;
        float oriMoveSpeedRate = enemySpawner.enemyMoveSpeedRate;

        return new TemporaryEvent(
            duration,
            apply: () =>
            {
                enemySpawner.enemyAttackRate = 0.7f;
                enemySpawner.enemyMoveSpeedRate = 1.5f;

                Vector3 rushPoint = enemySpawner.GetValidSpawnPosition();

                enemySpawner.StartSmallEnemyRush(
                    rushPoint,
                    duration: duration,
                    interval: 2.0f,
                    spawnPerWave: 7,
                    scale: 0.5f
                );

                eventAlertUI.ShowAlert("敵ラッシュ発生！");
            },
            remove: () => {
                enemySpawner.enemyAttackRate = oriAttakRate;
                enemySpawner.enemyMoveSpeedRate = oriMoveSpeedRate;

            }
        );
    }


    // --- イベント生成用関数 ---
    private TemporaryEvent CreateEnemySizeBoostEvent(float duration)
    {
        float original = enemySpawner.enemyScaleMultiplier;
        float oriAttakRate = enemySpawner.enemyAttackRate;
        float oriMoveSpeedRate = enemySpawner.enemyMoveSpeedRate;
        return new TemporaryEvent(
            duration,
            apply: () =>
            {
                enemySpawner.enemyAttackRate = 1.5f;
                enemySpawner.enemyMoveSpeedRate = 0.7f;
                enemySpawner.enemyScaleMultiplier = 2f;
                eventAlertUI.ShowAlert("でっかい敵が出現！");
            },
            remove: () => { 
                enemySpawner.enemyScaleMultiplier = original;
                enemySpawner.enemyAttackRate = oriAttakRate;
                enemySpawner.enemyMoveSpeedRate = oriMoveSpeedRate;
            }
        );
    }

    private TemporaryEvent CreateEnemySizeDeBoostEvent(float duration)
    {
        float original = enemySpawner.enemyScaleMultiplier;
        return new TemporaryEvent(
            duration,
            apply: () =>
            {
                enemySpawner.enemyScaleMultiplier = 0.5f;
                eventAlertUI.ShowAlert("ちんまい敵が出現！");
            },
            remove: () => enemySpawner.enemyScaleMultiplier = original
        );
    }


    private TemporaryEvent CreateSpawnSpeedBoostEvent(float duration)
    {
        float originalMin = enemySpawner.spawnInterval.x;
        float originalMax = enemySpawner.spawnInterval.y;
        return new TemporaryEvent(
            duration,
            apply: () =>
            {
                enemySpawner.spawnInterval.x *= 0.8f;
                enemySpawner.spawnInterval.y *= 0.8f;
                eventAlertUI.ShowAlert("出現速度アップ！");
            },
            remove: () =>
            {
                enemySpawner.spawnInterval.x = originalMin;
                enemySpawner.spawnInterval.y = originalMax;
            }
        );
    }

    private TemporaryEvent CreateSpawnCountBoostEvent(float duration)
    {
        float originalMin = enemySpawner.spawnCountPerWave.x;
        float originalMax = enemySpawner.spawnCountPerWave.y;
        return new TemporaryEvent(
            duration,
            apply: () =>
            {
                enemySpawner.spawnCountPerWave.x *= 2;
                enemySpawner.spawnCountPerWave.y *= 2;
                eventAlertUI.ShowAlert("出現数アップ！");
            },
            remove: () =>
            {
                enemySpawner.spawnCountPerWave.x = originalMin;
                enemySpawner.spawnCountPerWave.y = originalMax;
            }
        );
    }
}
