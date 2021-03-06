﻿using UnityEngine;
using UnityEngine.Events;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField]
    int id;
    [SerializeField]
    string name;
    [SerializeField]
    string description;
    [SerializeField]
    status currentStatus;
    [SerializeField]
    int idToUnlock;
    public UnityEvent actions;
    public UnityEvent onActive;
    public UnityEvent onDeactivate;
    bool canBeInteracted;

    public enum status {
        locked,
        unlocked
    }

    private void Start()
    {
        MementoManager manager = FindObjectOfType<MementoManager>();
        if (manager)
        {
            manager.AddInteractableObject(this);
        }
    }

    public void Interact()
    {
        if (canBeInteracted)
        {
            actions.Invoke();
        }
    }

    public void SetStatus(status status)
    {
        currentStatus = status;
    }

    public int GetID()
    {
        return id;
    }

    public int GetIDToUnlock()
    {
        return idToUnlock;
    }

    public string GetDescription()
    {
        return description;
    }

    public string GetName()
    {
        return name;
    }

    public void Activate(bool value)
    {
        canBeInteracted = value;
        if (canBeInteracted)
        {
            onActive.Invoke();
        } else {
            onDeactivate.Invoke();
        }
    }

    public bool IsActive()
    {
        return canBeInteracted;
    }
}
