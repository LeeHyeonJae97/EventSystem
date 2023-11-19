using Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour, IEventListener
{
    private void OnEnable()
    {
        AddEventListener();
    }

    private void OnDisable()
    {
        RemoveEventListener();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            EventManager.Invoke(new EventParamSceneChange("NEW SCENE"));
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            EventManager.Invoke(EventKey.CharacterChanged, new EventParamInt(0));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            EventManager.Invoke(EventKey.CharacterChanged, new EventParamStringCollection(new string[] { "A", "B", "C" }));
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            EventManager.Invoke(EventKey.CharacterChanged, new EventParamCharacterChange(0, "A"));
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            EventManager.Invoke(EventKey.CharacterLevelUp, new EventParamStringCollection(new string[] { "A", "B", "C" }));
        }
    }

    public void AddEventListener()
    {
        EventManager.AddListener(EventKey.SceneChange, this);
        EventManager.AddListener(EventKey.CharacterChanged, this);
        EventManager.AddListener(EventKey.CharacterLevelUp, this);
    }

    public void RemoveEventListener()
    {
        EventManager.RemoveListener(EventKey.SceneChange, this);
        EventManager.RemoveListener(EventKey.CharacterChanged, this);
        EventManager.RemoveListener(EventKey.CharacterLevelUp, this);
    }

    public void OnEvent(uint key, IEventParam param)
    {
        switch (key)
        {
            case EventKey.SceneChange:
                OnSceneChanged(param as EventParamSceneChange);
                break;

            case EventKey.CharacterChanged:
                if (param is EventParamInt paramInt)
                {
                    OnCharacterChanged(paramInt);
                }
                else if (param is EventParamStringCollection paramStringCollection)
                {
                    OnCharacterChanged(paramStringCollection);
                }
                else if (param is EventParamCharacterChange paramCharacterChange)
                {
                    OnCharacterChanged(paramCharacterChange);
                }
                break;

            case EventKey.CharacterLevelUp:
                OnCharacterLevelUp(param as EventParamStringCollection);
                break;
        }
    }

    void OnSceneChanged(EventParamSceneChange sceneChange)
    {
        Debug.Log($"{nameof(OnSceneChanged)} : {sceneChange.SceneName}");
    }

    void OnCharacterChanged(EventParamInt Id)
    {
        Debug.Log($"{nameof(OnCharacterChanged)} : Id : {Id.Value}");
    }

    void OnCharacterChanged(EventParamStringCollection keys)
    {
        foreach (var value in keys.Values)
        {
            Debug.Log($"{nameof(OnCharacterChanged)} : Keys : {value}");
        }
    }

    void OnCharacterChanged(EventParamCharacterChange characterChange)
    {
        Debug.Log($"{nameof(OnCharacterChanged)} : {characterChange.Id} / {characterChange.Name}");
    }

    void OnCharacterLevelUp(EventParamStringCollection keys)
    {
        foreach (var value in keys.Values)
        {
            Debug.Log($"{nameof(OnCharacterLevelUp)} : {value}");
        }
    }
}
