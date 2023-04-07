using TheCardGame.Games;

namespace TheCardGame.Effects.States;

public class Unused : EffectState
{
    public Unused(Effect effect)
        : base(effect)
    {
    }

    public Unused(EffectState state)
        : base(state.effect)
    {
    }

    public override void Activate()
    {
        GameBoard.GetInstance().Stack.Push(this.effect);
        this.effect.State = new OnTheStack(this.effect);
    }

    public override void ActivateWithoutStack()
    {
        this.effect.State = new Active(this);
        this.effect.Trigger();
    }

    public override void Dispose()
    {
        this.effect.State = new Used(this);
    }
}