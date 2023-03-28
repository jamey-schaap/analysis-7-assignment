namespace TheCardGame.Effects.States;

public abstract class EffectState
{
    public Effect effect { get; set; }
    public EffectState(Effect effect)
    {
        this.effect = effect;
    }

    protected EffectState(EffectState state)
    {
        this.effect = state.effect;
    }
    public virtual void Activate() { }
    public virtual void Trigger() { }
    public virtual void Dispose() { }
}

// Card.state(OnTheBoard).TriggerEffects
// this.card.TriggerEffects