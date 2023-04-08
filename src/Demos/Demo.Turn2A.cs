using TheCardGame.Games;
using TheCardGame.Utils;

namespace TheCardGame.Demos;

public partial class Demo
{
    public static bool Turn2A()
    {
        var gb = GameBoard.GetInstance();
        var player1 = gb.Player1.Id;
        var player2 = gb.Player2.Id;

        gb.PrepareNewTurn();

        Console.WriteLine("=== Turn 2A [Start]");
        if (!gb.StartTurn()) { return false; }

        if (!gb.ToDrawingPhase()) { return false; }

        gb.ToMainPhase();

        // |-> Known Game is turned from face down to face up

        gb.PlayCard(player1, "red-land-5");

        if (gb.PlayCard(player1, "red-creature-1"))
        {
            gb.TapFromCard("red-land-1");
            gb.TapFromCard("red-land-2");
        }

        gb.ActivateEffect(player1, "red-creature-1", "DiscardRandomCard");
        gb.Stack.Resolve();

        gb.SetCardToAttacking("red-creature-1");

        gb.ActivateEffect(player2, "known-game", "DealDamageToAllAttackingCards");
        if (gb.PlayCard(player1, "red-creature-buff-spell"))
        {
            // Arnold is able to play the card and is prompted to turn the lands with the specified colours
            gb.TapFromCard("red-land-3");
            gb.TapFromCard("red-land-4");
            gb.TapFromCard("red-land-5");
            gb.TapFromCard("red-land-6");
            gb.TapFromCard("red-land-7");

            var (creatureCard, _) = Support.FindCard(gb.Player1.GetCards(), "red-creature-1");
            gb.ActivateEffect(player1, "red-creature-buff-spell", "BuffCreatureOneTurn", new() { creatureCard });
        }
        gb.Stack.Resolve();

        gb.ActivateEffect(player2, "known-game", "Dispose");
        gb.Stack.Resolve();

        gb.PeformAttack("red-creature-1");

        gb.EndTurn();
        Console.WriteLine("=== Turn 2A [End]");
        gb.LogCurrentSituation();

        return true;
    }
}