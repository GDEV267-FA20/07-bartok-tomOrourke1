using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // Enables LINQ queries, which will be explained soon

// The player can either be human or an ai
public enum PlayerType
{
    human,
    ai
}

[System.Serializable]                                                    // a
public class Player
{                                                    // b
    public PlayerType type = PlayerType.ai;
    public int playerNum;
    public SlotDef handSlotDef;
    public List<CardBartok> hand; // The cards in this player's hand

    // Add a card to the hand
    public CardBartok AddCard(CardBartok eCB)
    {
        if (hand == null) hand = new List<CardBartok>();

        // Add the card to the hand
        hand.Add(eCB);

        return (eCB);
    }

    // Remove a card from the hand
    public CardBartok RemoveCard(CardBartok cb)
    {
        // If hand is null or doesn't contain cb, return null
        if (hand == null || !hand.Contains(cb)) return null;
        hand.Remove(cb);
        return (cb);
    }

}