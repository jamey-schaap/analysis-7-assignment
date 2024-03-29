// Jamey Schaap 0950044
// Vincent de Gans 1003196

using TheCardGame.Games;

namespace TheCardGame.Demos;

public partial class Demo
{
    public static void SetupInitialScenario()
    {
        var gb = GameBoard.GetInstance();

        Console.WriteLine("=== Initial setup [Start]");
        // Arnold
        {
            var redLand1 = gb.Player1.DrawCard("p1-red-land-1");
            var redLand2 = gb.Player1.DrawCard("p1-red-land-2");
            var redLand3 = gb.Player1.DrawCard("p1-red-land-3");
            var redLand4 = gb.Player1.DrawCard("p1-red-land-4");

            gb.Player1.PlayCard(redLand1!);
            gb.Player1.PlayCard(redLand2!);
            gb.Player1.PlayCard(redLand3!);
            gb.Player1.PlayCard(redLand4!);

            redLand1!.TapEnergy();
            redLand2!.TapEnergy();
        }


        // Bryce
        {
            var redLand1 = gb.Player2.DrawCard("p2-red-land-1");
            var redLand2 = gb.Player2.DrawCard("p2-red-land-2");
            var blueLand1 = gb.Player2.DrawCard("p2-blue-land-1");
            var blueLand2 = gb.Player2.DrawCard("p2-blue-land-2");
            var blueLand3 = gb.Player2.DrawCard("p2-blue-land-3");
            var redCreature1 = gb.Player2.DrawCard("p2-red-creature-1");

            gb.Player2.PlayCard(redLand1!);
            gb.Player2.PlayCard(redLand2!);
            gb.Player2.PlayCard(blueLand1!);
            gb.Player2.PlayCard(blueLand2!);
            gb.Player2.PlayCard(blueLand3!);
            gb.Player2.PlayCard(redCreature1!);
        }

        gb.DrawInitialCards();
        Console.WriteLine("=== Initial setup [End]");

        gb.LogCurrentSituation();
    }
}