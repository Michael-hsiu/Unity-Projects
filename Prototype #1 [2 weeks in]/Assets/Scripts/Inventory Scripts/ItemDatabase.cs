using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LitJson;

public class ItemDatabase : MonoBehaviour {
	private List<Item> database = new List<Item>();
	private JsonData itemData;

	void Start() {
		// Read all text from file in Assets folder
		itemData = JsonMapper.ToObject (File.ReadAllText(Application.streamingAssetsPath + "/Items.json"));
		ConstructItemDatabase ();	// Add items to the list.

		// Debug.Log (database[1].Description);
		//Debug.Log (FetchItemByID (0).Description);
	}

	public Item FetchItemByID(int id) {
		for (int i = 0; i < database.Count; i++) {
			// Look for the item in the list.
			if (database[i].ID == id) {
				return database[i];		// Return the item.
			}
		}
		return null;	// If item was not found, return null.
	}


	void ConstructItemDatabase() {
		// Go thru and process each item in JSON, adding it to the Item list.
		for (int i = 0; i < itemData.Count; i++) {
			database.Add (new Item ((int) itemData[i]["id"], 
				itemData[i]["title"].ToString(), 
				(int) itemData[i]["value"], 
				(int) itemData[i]["stats"]["power"], 
				(int) itemData[i]["stats"]["defense"],
				(int) itemData[i]["stats"]["vitality"], 
				itemData[i]["description"].ToString(),
				(bool) itemData[i]["stackable"], 
				(int) itemData[i]["rarity"], 
				itemData[i]["slug"].ToString()));
		}

	}

	public void PrintDatabase() {
		foreach(Item i in database) {
			Debug.Log (i.Title);
		}
	}
}

public class Item {
	public int ID { get; set; }
	public string Title { get; set; }
	public int Value { get; set; }
	public int Power { get; set; }
	public int Defense { get; set; }
	public int Vitality { get; set; }
	public string Description { get; set; }
	public bool Stackable { get; set; }
	public int Rarity { get; set; }
	public string Slug { get; set; }
	public Sprite Sprite { get; set; }

	public Item(int id, string title, int value, int power, int defense, int vitality, 
		string description, bool stackable, int rarity, string slug) {
		this.ID = id;
		this.Title = title;
		this.Value = value;
		this.Power = power;
		this.Defense = defense;
		this.Vitality = vitality;
		this.Description = description;
		this.Stackable = stackable;
		this.Rarity = rarity;
		this.Slug = slug;
		this.Sprite = Resources.Load<Sprite> ("Sprites/" + slug);
	}


	public Item() {
		// Empty item
		this.ID = -1;
	}
}