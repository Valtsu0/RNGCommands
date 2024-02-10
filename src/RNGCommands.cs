using SML;
using System;
using CommandLib.API;
using CommandLib;
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

            Service.Game.Sim.simulation.SendChat(Actions.RandomElement(random));
            
            return new Tuple<bool, string>(true, null);
        }

        public string GetHelpMessage()
        {
            return "<b>/pirate <Player> </b> - gives a random duel option.";
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
            if (args.Length > 1) {
                Debug.Log(args);
                return new Tuple<bool, string>(false, $"Too many arguments!");
            }
            if (args.Length < 1) return new Tuple<bool, string>(false, "Too few arguments!");
            System.Random random = new System.Random();

            Service.Game.Sim.simulation.SendChat($"{args[0]} thou {AdjectiveOne.RandomElement(random)} {AdjectiveTwo.RandomElement(random)} {Noun.RandomElement(random)}");
            
            return new Tuple<bool, string>(true, null);
        }

        public string GetHelpMessage()
        {
            return "<b>/slander|sl <Player> </b> - send a shakespearean insult against a player.";
        }
    }
}
