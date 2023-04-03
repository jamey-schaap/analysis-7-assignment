namespace TheCardGame.Effects.States;

public class OnTheStack : EffectState
{
    public OnTheStack(Effect effect)
        : base(effect)
    {
    }

    public override void Trigger()
    {
        this.effect.Trigger();
        this.effect.State = new Active(this);
    }

    public override void Dispose()
    {
        this.effect.State = new Used(this);
    }
}