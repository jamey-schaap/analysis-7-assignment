// Jamey Schaap 0950044
// Vincent de Gans 1003196

using TheCardGame.Common.Models;

namespace TheCardGame.Cards.States;

public abstract class CardState
{
    protected Card card;

    public CardState(Card card)
    {
        this.card = card;
    }

    public virtual bool OnDraw() { return false; }
    public virtual void OnEndTurn() { }
    public virtual void OnStartTurn() { }
    public virtual bool OnPlay() => false;

    public virtual bool IsNotYetInTheGame() { return false; }
    public virtual bool IsInTheHand() { return false; }
    public virtual bool CanBePlayed() { return false; }

    public virtual int GivesEnergyLevel() { return 0; }
    public virtual void TapEnergy() { }
    public virtual void GoDefending() { }
    public virtual void GoAttacking() { }
    public virtual void TurnFaceUp() { }
    public virtual void ActivateEffect(string name, List<Entity>? targets) { }
    public virtual bool PeformAttack() { return false; }
    public virtual (bool, int) AbsorbAttack(int iAttackValue) { return (false, 0); }
    public virtual bool Dispose() { return false; }
}