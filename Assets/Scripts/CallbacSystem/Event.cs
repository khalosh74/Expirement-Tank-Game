using System;
using UnityEngine;

public abstract class Event<T> where T : Event<T>{
	public string Description;
	public delegate void EventListener(T info);

	private static event EventListener listeners;

	private bool hasFired;
	
	public static void RegisterListener(EventListener listener)
	{
		listeners += listener;
	}

	public static void UnregisterListener(EventListener listener)
	{
		listeners -= listener;
	}

	public void FireEvent()
	{
		if (hasFired){throw new Exception("Event already been fired.");}
		hasFired = true;
		if (listeners != null){listeners(this as T);}
		
	}
}

public class DebugEvent : Event<DebugEvent>
{

}

public class PlayerKillsEnemyEvent : Event<PlayerKillsEnemyEvent>
{
	public int xpAmount;

}
public class ShootEvent : Event<ShootEvent>
{
    public GameObject holder;
}
public class NextLevelEvent : Event<NextLevelEvent>
{
	public int nextLevel;
}