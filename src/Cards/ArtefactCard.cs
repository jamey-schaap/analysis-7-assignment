using TheCardGame.Cards.Colours;

namespace TheCardGame.Cards;

public abstract class ArtefactCard : Card
{
    protected ArtefactCard(string cardId, ICollection<Colour> colours)
        : base(cardId, colours)
    {
    }
}