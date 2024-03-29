// Jamey Schaap 0950044
// Vincent de Gans 1003196

namespace TheCardGame.Cards.Colours;

public abstract class ColourFactory
{
    public abstract Red CreateRed(int cost = 0);
    public abstract Blue CreateBlue(int cost = 0);
    public abstract Colourless CreateColourless(int cost = 0);
}