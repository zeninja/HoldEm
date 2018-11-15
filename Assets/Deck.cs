using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {


	private static Deck instance;
	public static Deck GetInstance() {
		return instance;
	}

	void Awake() {
		if(instance == null) {
			instance = this;
		} else {
			if(this != instance) {
				Destroy(gameObject);
			}
		}
	}

	public enum Suit { S, H, C, D};

	void Start() {
		GenerateDeck();
	}
	
	Dictionary<string, Card> fullDeck = new Dictionary<string, Card>();
	List<Card> outsDeck = new List<Card>();

	void GenerateDeck() {
		for(int i = 0; i < 4; i++) {
			for (int j = 1; j < 14; j++) {
				Suit suit = ((Suit)i);
				string id = j + suit.ToString();
				fullDeck.Add(id, new Card(j, suit));
			}
		}
	}

	public void HandleCardRecognized(ARReferenceImage img) {
		Card.ImageToId(img);
	}

	public void HandleCardRemoved(ARReferenceImage img) {
		string cardID = Card.ImageToId(img);
		outsDeck.Remove(GetCardById(cardID));
	}

	Card GetCardById(string id) {
		Card c;
		fullDeck.TryGetValue(id, out c);
		return c;
	}

	void UpdateDeckStatistics() {

	}
}
