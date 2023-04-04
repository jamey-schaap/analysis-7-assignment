using TheCardGame.Common.Models;
using TheCardGame.Effects;
using TheCardGame.Effects.ConcreteEffects.MultiPurpose;
using TheCardGame.Effects.ConcreteEffects.SinglePurpose;

namespace TheCardGame.Demos;

public class DemoEffectFactory : EffectFactory
{
    public override BuffCreatureEffect CreateBuffCreatureEffect(
        string name,
        string description,
        int attackOffset,
        int defenseOffset,
        uint amountOfTurns)
    {
        return new DemoBuffCreatureEffect(
            name,
            description,
            attackOffset,
            defenseOffset,
            amountOfTurns);
    }

    public override CounterEffect CreateCounterEffect()
    {
        return new DemoCounterEffect();
    }

    public override DealDamageEffect CreateDealDamageEffect(
        string name,
        string description,
        uint damage,
        Func<List<Entity>>? getPreDeterminedTargets)
    {
        return new DemoDealDamageEffect(
            name,
            description,
            damage,
            getPreDeterminedTargets);
    }

    public override SleightOfHandEffect CreateSleightOfHandEffect(uint amountOfTurns)
    {
        return new DemoSleightOfHandEffect(amountOfTurns);
    }
}