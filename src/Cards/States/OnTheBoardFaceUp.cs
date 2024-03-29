// Jamey Schaap 0950044
// Vincent de Gans 1003196

using TheCardGame.Cards.Events;
using TheCardGame.Common.Models;
using TheCardGame.Effects.Types;
using TheCardGame.Games;

namespace TheCardGame.Cards.States;

public class OnTheBoardFaceUp
    : CardState
{
    public OnTheBoardFaceUp(Card card)
        : base(card)
    {
    }

    public override void TapEnergy()
    {
        Console.WriteLine($"[System] {this.card.GetId()} has been turned.");
        this.card.State = new IsTapped(this.card);
    }

    public override void GoDefending()
    {
        this.card.State = new IsDefending(this.card);
    }

    public override void GoAttacking()
    {
        this.card.State = new IsAttacking(this.card);
    }

    public override int GivesEnergyLevel()
    {
        return 0;
    }

    public override bool Dispose()
    {
        var disposedEvent = new CardDisposedEvent(this.card);
        foreach (var obs in this.card.Observers)
        {
            obs.CardDisposed(disposedEvent);
        }

        this.card.Effects.ForEach(e => e.Dispose());

        GameBoard.GetInstance().RemoveObserver(this.card);
        this.card.RemoveAllObservers();

        this.card.State = new OnTheDisposedPile(this.card);

        return true;
    }

    public override bool CanBePlayed() { return true; }

    public override void ActivateEffect(string name, List<Entity>? targets)
    {
        var effect = this.card.Effects.FirstOrDefault(e => e.Name == name);

        if (effect == null)
        {
            throw new ArgumentException($"Effect with name {name} does not exist on card {this.card.GetId()}");
        }

        if (effect.Type is OnRevealEffect)
        {
            effect.Activate(targets);
        }
    }
}