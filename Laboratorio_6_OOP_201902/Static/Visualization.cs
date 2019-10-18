using Laboratorio_6_OOP_201902.Cards;
using Laboratorio_6_OOP_201902.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_6_OOP_201902.Static
{
    public static class Visualization
    {
        public static void ShowHand(Hand hand)
        {
            CombatCard combatCard;
            Console.WriteLine("Hand: ");
            for (int i = 0; i<hand.Cards.Count; i++)
            {
                if (hand.Cards[i] is CombatCard)
                {
                    combatCard = hand.Cards[i] as CombatCard;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"|({i}) {combatCard.Name} ({combatCard.Type}): {combatCard.AttackPoints} |");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"|({i}) {hand.Cards[i].Name} ({hand.Cards[i].Type}) |");
                }
                Console.ResetColor();
            }
            Console.WriteLine();
        }
        public static void ShowDecks(List<Deck> decks)
        {
            Console.WriteLine("Select one Deck:");
            for (int i = 0; i<decks.Count; i++)
            {
                Console.WriteLine($"({i}) Deck {i+1}");
            }
        }
        public static void ShowCaptains(List<SpecialCard> captains)
        {
            Console.WriteLine("Select one captain:");
            for (int i = 0; i < captains.Count; i++)
            {
                Console.WriteLine($"({i}) {captains[i].Name}: {captains[i].Effect}");
            }
        }
        public static int GetUserInput(int maxInput, bool stopper = false)
        {
            bool valid = false;
            int value;
            int minInput = stopper ? -1 : 0;
            while (!valid)
            {

                if (int.TryParse(Console.ReadLine(), out value))
                {
                    if (value >= minInput && value <= maxInput)
                    {
                        return value;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine($"The option ({value}) is not valid, try again");
                        Console.ResetColor();
                    }
                }
                else
                {
                    ConsoleError($"Input must be a number, try again");
                }
            }
            return -1;
        }
        public static void ConsoleError(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void ShowProgramMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void ShowListOptions (List<string> options, string message = null)
        {
            if (message != null) Console.WriteLine($"{message}");
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"({i}) {options[i]}");
            }
        }
        public static void ClearConsole()
        {
            Console.ResetColor();
            Console.Clear();
        }
        public static void ShowBoard(Board board, int player, int[] lifePoints, int[] attackPoints)
        {
            IAttackPoints attackPointsType = board;
            Console.WriteLine("Board");
            if (player == 0)
            {
                Console.WriteLine("Opponent - LifePoints: {0} - AttackPoints: {1} :",lifePoints[1], attackPoints[1]);

                //Informacion de cartas longRange de oponente
                Console.WriteLine("(longRange) [{0}]:",attackPointsType.GetAttackPoints(EnumType.longRange)[1]);
                if (board.PlayerCards[1].ContainsKey(EnumType.longRange))
                {
                    foreach (CombatCard card in board.PlayerCards[1][EnumType.longRange])
                    {
                        Console.WriteLine("|{0}|", card.AttackPoints);
                    }
                }
                //Informacion de cartas range de oponente
                Console.WriteLine("(range) [{0}]:", attackPointsType.GetAttackPoints(EnumType.range)[1]);
                if (board.PlayerCards[1].ContainsKey(EnumType.range))
                {
                    foreach (CombatCard card in board.PlayerCards[1][EnumType.range])
                    {
                        Console.WriteLine("|{0}|", card.AttackPoints);
                    }
                }
                //Informacion de cartas melee de oponente
                Console.WriteLine("(melee) [{0}]:", attackPointsType.GetAttackPoints(EnumType.melee)[1]);
                if (board.PlayerCards[1].ContainsKey(EnumType.melee))
                {
                    foreach (CombatCard card in board.PlayerCards[1][EnumType.melee])
                    {
                        Console.WriteLine("|{0}|", card.AttackPoints);
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("Wheather Cards");
                Console.WriteLine("");

                Console.WriteLine("You - LifePoints: {0} - AttackPoints: {1} :", lifePoints[0], attackPoints[0]);

                //Informacion de cartas longRange de jugador actual
                Console.WriteLine("(longRange) [{0}]:", attackPointsType.GetAttackPoints(EnumType.longRange)[0]);
                if (board.PlayerCards[player].ContainsKey(EnumType.longRange))
                {
                    foreach (CombatCard card in board.PlayerCards[player][EnumType.longRange])
                    {
                        Console.WriteLine("|{0}|", card.AttackPoints);
                    }
                }
                //Informacion de cartas rage de jugador actual
                Console.WriteLine("(range) [{0}]:", attackPointsType.GetAttackPoints(EnumType.range)[0]);
                if (board.PlayerCards[player].ContainsKey(EnumType.range))
                {
                    foreach (CombatCard card in board.PlayerCards[player][EnumType.range])
                    {
                        Console.WriteLine("|{0}|", card.AttackPoints);
                    }
                }
                //Informacion de cartas melee de jugador actual
                Console.WriteLine("(melee) [{0}]:", attackPointsType.GetAttackPoints(EnumType.melee)[0]);
                if (board.PlayerCards[player].ContainsKey(EnumType.melee))
                {
                    foreach (CombatCard card in board.PlayerCards[player][EnumType.melee])
                    {
                        Console.WriteLine("|{0}|", card.AttackPoints);
                    }
                }
            }
            else
            {
                Console.WriteLine("Opponent - LifePoints: {0} - AttackPoints: {1} :", lifePoints[0], attackPoints[0]);

                //Informacion de cartas longRange de oponente
                Console.WriteLine("(longRange) [{0}]:", attackPointsType.GetAttackPoints(EnumType.longRange)[0]);
                if (board.PlayerCards[0].ContainsKey(EnumType.longRange))
                {
                    foreach (CombatCard card in board.PlayerCards[0][EnumType.longRange])
                    {
                        Console.WriteLine("|{0}|", card.AttackPoints);
                    }
                }
                //Informacion de cartas range de oponente
                Console.WriteLine("(range) [{0}]:", attackPointsType.GetAttackPoints(EnumType.range)[0]);
                if (board.PlayerCards[0].ContainsKey(EnumType.range))
                {
                    foreach (CombatCard card in board.PlayerCards[0][EnumType.range])
                    {
                        Console.WriteLine("|{0}|", card.AttackPoints);
                    }
                }
                //Informacion de cartas melee de oponente
                Console.WriteLine("(melee) [{0}]:", attackPointsType.GetAttackPoints(EnumType.melee)[0]);
                if (board.PlayerCards[0].ContainsKey(EnumType.melee))
                {
                    foreach (CombatCard card in board.PlayerCards[0][EnumType.melee])
                    {
                        Console.WriteLine("|{0}|", card.AttackPoints);
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("Wheather Cards");
                Console.WriteLine("");

                Console.WriteLine("You - LifePoints: {0} - AttackPoints: {1} :", lifePoints[1], attackPoints[1]);

                //Informacion de cartas longRange de jugador actual
                Console.WriteLine("(longRange) [{0}]:", attackPointsType.GetAttackPoints(EnumType.longRange)[1]);
                if (board.PlayerCards[player].ContainsKey(EnumType.longRange))
                {
                    foreach (CombatCard card in board.PlayerCards[player][EnumType.longRange])
                    {
                        Console.WriteLine("|{0}|", card.AttackPoints);
                    }
                }
                //Informacion de cartas rage de jugador actual
                Console.WriteLine("(range) [{0}]:", attackPointsType.GetAttackPoints(EnumType.range)[1]);
                if (board.PlayerCards[player].ContainsKey(EnumType.range))
                {
                    foreach (CombatCard card in board.PlayerCards[player][EnumType.range])
                    {
                        Console.WriteLine("|{0}|", card.AttackPoints);
                    }
                }
                //Informacion de cartas melee de jugador actual
                Console.WriteLine("(melee) [{0}]:", attackPointsType.GetAttackPoints(EnumType.melee)[1]);
                if (board.PlayerCards[player].ContainsKey(EnumType.melee))
                {
                    foreach (CombatCard card in board.PlayerCards[player][EnumType.melee])
                    {
                        Console.WriteLine("|{0}|", card.AttackPoints);
                    }
                }
            }
        }
    }
    
}
