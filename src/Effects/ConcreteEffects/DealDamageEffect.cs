using TheCardGame.Cards;
using TheCardGame.Common.Models;
using TheCardGame.Players;

namespace TheCardGame.Effects.ConcreteEffects;

public class DealDamageEffect : Effect
{
    public uint Damage { get; init; }
    public DealDamageEffect(
        string name,
        string description,
        uint damage,
        Func<List<Entity>>? getPreDeterminedTargets = null,
        Func<bool>? duration = null) 
        : base(name, description, getPreDeterminedTargets, duration)
    {
        this.Damage = damage;
    }

    public override void Trigger()
    {
        var preDeterminedTargets = this._getPreDeterminedTargets();
        var targets = this._userInvokedTargets.Concat(preDeterminedTargets);
        foreach (var target in targets)
        {
            if (target is Card card)
            {
                card.GoDefending();
                card.State.AbsorbAttack((int)this.Damage);
            }
            if (target is Player player)
            {
                player.DecreaseHealthValue((int)this.Damage);
            }
        }
    }
}