using System;
using System.Collections;
using System.Collections.Generic;

public static class EventManager {

	public delegate void EventCallback(params object[] parameters);
	private static Dictionary<string, EventCallback> eventDictionary = new Dictionary<string, EventCallback>();

	public static void Subscribe(string subscribedEvent, EventCallback function) {
		if (eventDictionary == null)
			eventDictionary = new Dictionary<string, EventCallback>();

		if (!eventDictionary.ContainsKey(subscribedEvent))
			eventDictionary.Add(subscribedEvent, null);
		eventDictionary[subscribedEvent] += function;

	}



    public static void Unsubscribe(string subscribedEvent, EventCallback function) {
		if (eventDictionary == null)
			return;

		if (!eventDictionary.ContainsKey(subscribedEvent))
			return;

		eventDictionary[subscribedEvent] -= function;
	}

	public static void Call(string item, params object[] args) {
		if(!eventDictionary.ContainsKey(item) || eventDictionary[item]== null)
			return;
		eventDictionary[item](args);
	}


}


