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
        private static List<string> AdjectiveOne = new List<string>(){ "artless", "bawdy", "beslubbering", "bootless", "churlish", "cockered", "clouted", "craven", "currish","dankish","dissembling","droning","errant","fawning","fobbing","froward","frothy","gleeking","goatish","gorbellied","impertinent","infectious","jarring","joggerheaded","lumpish","mammering","mangled","mewling","paunchy","pribbling","puking","puny","rank","reeky","roguish","ruftish","saucy","spleeny","spongy","surly","tottering","unmuzzled","vain","venomed","villainous","warped","wayward","weedy","yeasty"};

        private static List<string> AdjectiveTwo = new List<string>(){"base-court","bat-forling","beef-witted","beetle-headed","boil-brained","clapper-clawed","clay-brained","common-kissing","crook-pated","dismal-dreaming","dizzy-eyed","doghearted","dread-bolted","earth-vexing","elf-skinned","fat-kidneyed","fen-sucked","flap-mothed","fly-bitten","folly-fallen","fool-born","fill-gorged","guts-griping","half-faced","hasty-witted","hedge-born","hell-hated","idle-headed","ill-breeding","ill-nurtured","knotty-pated","milk-livered","motley-minded","onion-eyed","plume-plucked","pottle-deep","pox-marked","reeling-ripe","rough-hewn","rude-growing","rump-faced","shard-borne","sheep-biting","spur-galled","swag-bellied","tardy-gaited","tickle-brained","toad-spotted","unchin-snoted","weather-bitten"};

        private static List<string> Noun = new List<string>(){"apple-john","baggage","barnacle","bladder","boar-pig","bugbear","bum-bailey","canket-blossom","clack-dish","clotpole","coxcomb","codpiece","death-token","dewberry","flap-dragon","flax-wench","flirt-gill","foot-licker","futilarrian","giglet","gudgeon","haggard","harpy","hedge-pig","horn-beast","hugger-mugger","joithead","lewduster","lout","maggot-pie","malt-worm","mammet","measle","minnow","miscreant","moldwarp","mumble-news","nut-hook","pigeon-egg","pignut","puttock","pumbion","ratsbane","scut","skainsmate","strumpot","varlot","vassal","wheyface","wagtail"};

        public RNGCommand(string name, string[] aliases = null, string harmonyId = null) : base(name, aliases, harmonyId)
        {
        }

        public override Tuple<bool, string> Execute(string[] args)
        {

            int lower = 1;
            int upper = 15;

            bool fail = false;

            if (args.Length == 1) {
                fail = !int.TryParse(args[0], out upper);
                if (fail) return new Tuple<bool, string>(false, "Unable to parse arguments!");
            } else if (args.Length > 1)  {
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
            return "<b>/rng</b> - by default gives a number between 1 and 15. Upper and lower bounds can be changed by giving arguments.";
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
            return "<b>/choose</b> - chooses a random argument.";
        }
    }
}

