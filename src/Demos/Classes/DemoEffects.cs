// Jamey Schaap 0950044
// Vincent de Gans 1003196

using TheCardGame.Common.Models;
using TheCardGame.Effects.ConcreteEffects.MultiPurpose;
using TheCardGame.Effects.ConcreteEffects.SinglePurpose;
using TheCardGame.Effects.Types;
using TheCardGame.Games.States;

namespace TheCardGame.Demos;

public class DemoCounterEffect : CounterEffect
{
    public DemoCounterEffect()
    {
    }
}

public class DemoSleightOfHandEffect<T> : SleightOfHandEffect<T>
    where T : GameState
{
    public DemoSleightOfHandEffect(uint amountOfTurns)
        : base(amountOfTurns)
    {
    }
}

public class DemoDealDamageEffect : DealDamageEffect
{
    public DemoDealDamageEffect(
        string name,
        string description,
        uint damage,
        Func<List<Entity>>? getPreDeterminedTargets = null)
        : base(name, description, damage, getPreDeterminedTargets)
    {
    }
}

public class DemoBuffCreatureEffect : BuffCreatureEffect
{
    public DemoBuffCreatureEffect(
        string name,
        string description,
        int attackOffset,
        int defenseOffset,
        uint amountOfTurns)
        : base(name, description, attackOffset, defenseOffset, amountOfTurns)
    {
    }
}

public class DemoSkipDrawingPhaseEffect : SkipDrawingPhaseEffect
{
    public DemoSkipDrawingPhaseEffect(uint amountOfTurns)
        : base(amountOfTurns)
    {
    }
}

public class DemoDisposeEffect : DisposeEffect
{
    public DemoDisposeEffect()
        : base()
    {
    }
}

public class DemoDiscardRandomCardEffect : DiscardRandomCardEffect
{
    public DemoDiscardRandomCardEffect()
        : base()
    {
    }
}

public class DemoModifyAttackDamageEffect : ModifyAttackDamageEffect
{
    public DemoModifyAttackDamageEffect(
        string name,
        Func<int, int> attackModifier,
        List<Type> creatureStates) 
        : base(name, attackModifier, creatureStates)
    {
    }
}

public class DemoDelayedDisposeEffect<T> : DelayedDisposeEffect<T>
    where T : GameState
{
    public DemoDelayedDisposeEffect(Guid playerId)
        : base(playerId)
    {
    }
}