using SML;
using System;
using CommandLib.API;
using CommandLib.Util;
using System.Collections.Generic;
using Services;
using UnityEngine;
using Server.Shared.Extensions;

namespace RNGCommands;

[Mod.SalemMod]
public class RNGCommands
{
    public static void Start()
    {
        CommandRegistry.AddCommand(new RNGCommand("rng", []));
        CommandRegistry.AddCommand(new PirateCommand("pirate", []));
        CommandRegistry.AddCommand(new ChooseCommand("choose", []));
        CommandRegistry.AddCommand(new CoinflipCommand("coinflip", ["coin"]));
    }

    public class PirateCommand : Command, IHelpMessage
    {
        private static List<string> Actions = new List<string>(){ "Sidestep", "Chainmail", "Backpedal" };
        public PirateCommand(string name, string[] aliases = null, string harmonyId = null) : base(name, aliases, harmonyId)
        {
        }

        public override Tuple<bool, string> Execute(string[] args)
        {
            if (args.Length > 0) return new Tuple<bool, string>(false, "Too many arguments!");
            System.Random random = new System.Random();

            FeedbackHelper.SendFeedbackMessage(Actions.RandomElement(random));
            
            return new Tuple<bool, string>(true, null);
        }

        public string GetHelpMessage()
        {
            return "<b>/pirate</b> - gives a random duel option.";
        }
    }

        public class CoinflipCommand : Command, IHelpMessage
    {
        private static List<string> Possibilities = new List<string>(){ "Heads", "Tails" };
        public CoinflipCommand(string name, string[] aliases = null, string harmonyId = null) : base(name, aliases, harmonyId)
        {
        }

        public override Tuple<bool, string> Execute(string[] args)
        {
            if (args.Length > 0) return new Tuple<bool, string>(false, "Too many arguments!");
            System.Random random = new System.Random();

            FeedbackHelper.SendFeedbackMessage(Possibilities.RandomElement(random));
            
            return new Tuple<bool, string>(true, null);
        }

        public string GetHelpMessage()
        {
            return "<b>/coinflip|coin</b> - flips a coin.";
        }
    }

    public class RNGCommand : Command, IHelpMessage
    {
        public RNGCommand(string name, string[] aliases = null, string harmonyId = null) : base(name, aliases, harmonyId)
        {
        }

        public override Tuple<bool, string> Execute(string[] args)
        {
            if (args.Length > 2) return new Tuple<bool, string>(false, "Too many arguments!");

            int lower = 1;
            int upper = 15;

            bool fail = false;

            if (args.Length == 1) {
                fail = !int.TryParse(args[0], out upper);
                if (fail) return new Tuple<bool, string>(false, "Unable to parse arguments!");
            } else if (args.Length == 2)  {
                int arg0;
                int arg1;
                fail = !int.TryParse(args[0], out arg0);
                fail |= !int.TryParse(args[1], out arg1);
                if (fail) return new Tuple<bool, string>(false, "Unable to parse arguments!");

                lower = System.Math.Min(arg0, arg1);
                upper = System.Math.Max(arg0, arg1);
            }
            System.Random random = new System.Random();

            FeedbackHelper.SendFeedbackMessage($"RNG ({lower} to {upper}): {random.Next(lower, upper + 1).ToString()}");
            
            return new Tuple<bool, string>(true, null);
        }

        public string GetHelpMessage()
        {
            return "/rng | <b>/rng [upper] | /rng [lower] [upper]</b> - by default gives a number between 1 and 15. Upper and lower bounds can be changed by giving arguments.";
        }
    }

    public class ChooseCommand : Command, IHelpMessage
    {
        public ChooseCommand(string name, string[] aliases = null, string harmonyId = null) : base(name, aliases, harmonyId)
        {
        }

        public override Tuple<bool, string> Execute(string[] args)
        {
            if (args.Length < 1) return new Tuple<bool, string>(false, "Too few arguments!");

            System.Random random = new System.Random();

            FeedbackHelper.SendFeedbackMessage(new List<string>(args).RandomElement(random));
            
            return new Tuple<bool, string>(true, null);
        }

        public string GetHelpMessage()
        {
            return "<b>/choose <argument1> [argument2] ...</b> - chooses a random argument.";
        }
    }
}

