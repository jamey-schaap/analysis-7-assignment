using TheCardGame.Effects.Types;
using TheCardGame.Games;

namespace TheCardGame.Effects.ConcreteEffects.SinglePurpose;

public class DiscardRandomCardEffect : Effect
{
    public DiscardRandomCardEffect()
        : base(
            new OnRevealEffect(),
            "DiscardRandomCard",
            "Discard a random card from the opponents hand.",
            null,
            null)
    {
    }

    public override void Trigger()
    {
        var randomCard = GameBoard.GetInstance().OpponentPlayer.DiscardRandomCard();
        if (randomCard == null)
        {
            Console.WriteLine($"[DiscardRandomCard] {GameBoard.GetInstance().CurrentPlayer.GetName()} has no cards in their hand, thus discarded nothing.");
        }
        else
        {
            Console.WriteLine($"[DiscardRandomCard] {GameBoard.GetInstance().CurrentPlayer.GetName()} discarded {randomCard.GetId()}.");
        }
        this.Dispose();
    }
}