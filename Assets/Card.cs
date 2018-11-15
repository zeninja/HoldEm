using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card : MonoBehaviour {

	public int value;
	public Deck.Suit suit;
	public string id;

	[SerializeField]
	public ARReferenceImage image;


	public Card(int val, Deck.Suit s) {
		value = val;
		suit  = s;
		id    = value + suit.ToString();
	}

	public static string ImageToId(ARReferenceImage img) {
		return img.name;
	}

	// public void ImportImageValues() {
	// 	value = 
	// }

}
