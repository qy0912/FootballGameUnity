using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvaluater : MonoBehaviour {


    public enum EvaluationType { TECHINICAL, PACE, STRENGTH, OFFENCE, DEFENCE, MENTALITY }

    public static string GetAttributeRank(EvaluationType evaluationType,Player p)
    {
        if (evaluationType == EvaluationType.TECHINICAL)
        {
            return GetRank((int)((p.shortPass + p.longPass) / 2));
        }
        else if (evaluationType == EvaluationType.OFFENCE)
        {
            return GetRank((int)((p.shooting + p.anticipation) / 2));
        }
        else if (evaluationType == EvaluationType.DEFENCE)
        {
            return GetRank((int)((p.tackling + p.anticipation) / 2));
        }
        else if (evaluationType == EvaluationType.PACE)
        {
            return GetRank((int)((p.pace + p.agility) / 2));
        }
        else if (evaluationType == EvaluationType.MENTALITY)
        {
            return GetRank((int)((p.anticipation)));
        }
        else if (evaluationType == EvaluationType.STRENGTH)
        {
            return GetRank((int)((p.strength)));
        }
        return "INVALID";
    }

    /// <summary>
    /// Use this function at all times to ensure clean
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    public static int EvaluatePlayer(Player p)
    {
        if (p.position == "前腰")
            return EvaluateAM(p);
        else if (p.position == "后腰")
            return EvaluateDM(p);
        else if (p.position == "中前卫")
            return EvaluateCM(p);
        else if (p.position == "前锋")
            return EvaluateST(p);
        else if (p.position == "中锋")
            return EvaluateCF(p);
        else if (p.position.Contains("边卫"))
            return EvaluateFB(p);
        else if (p.position.Contains("边前卫"))
            return EvaluateWM(p);
        else if (p.position.Contains("边锋"))
            return EvaluateWF(p);
        else if (p.position == ("中后卫"))
            return EvaluateCB(p);
        else if (p.position == ("门将"))
            return EvaluateGK(p);
        else
            return -1;
    }

    public static string GetRank(int val)
    {
        if (val > 90)
            return "S";
        else if (val > 80)
            return "A";
        else if (val > 70)
            return "B";
        else if (val > 60)
            return "C";
        else if (val > 55)
            return "D";
        else
            return "E";
    }

    public static int EvaluatePlayerSalary(Player p)
    {
        float rating = EvaluatePlayer(p);
        float expectedSalary =
            2276.856f + (22.71065f - 2276.856f) / (1 + Mathf.Pow(rating / 94.50385f, 17.76742f));
            ;
        return (int)expectedSalary;
    }

    public static int EvaluatePlayerTransferFee(Player p)
    {
        float overall = EvaluatePlayer(p);
        // y = 217241.9 + (-146.8249 - 217241.9) / (1 + (x / 134.5301) ^ 8.420233)
        var basePrice = 217241.9 + (-146.8249 - 217241.9) / (1 + Mathf.Pow(overall / 134.5301f, 8.420233f));
        return (int)basePrice;
    }

    public static int EvaluateDM(Player p)
    {
        float eval = 0;

        //shooting = 5%;
        //pace = 8%
        //anticipation = 18%;
        //tackling = 15%;
        //header = 10%;
        //shortpass = 6%;
        //longpass = 6%;
        //strength = 10%;
        //stamina = 14%;
        //agility = 8%;

        eval = (float)(p.shooting * .05 + p.pace * .08 + p.anticipation * .18 +
            p.tackling * .15 + p.header * .1 + p.shortPass * .06
            + p.longPass * .06 + p.strength * .10 + p.stamina * .14 + p.agility * .08);

        return (int)(eval);
    }


    public static int EvaluateCM(Player p)
    {
        float eval = 0;

        //shooting = 10%;
        //pace = 10%
        //anticipation = 10%;
        //tackling = 10%;
        //header = 10%;
        //shortpass = 10%;
        //longpass = 10%;
        //strength = 10%;
        //stamina = 10%;
        //agility = 10%;

        eval = (float)(
            p.shooting * .1 +
            p.pace * .1 +
            p.anticipation * .1 +
            p.tackling * .1 +
            p.header * .1 +
            p.shortPass * .1 +
            p.longPass * .1 +
            p.strength * .1 +
            p.stamina * .1 +
            p.agility * .1);

        return (int)(eval);
    }

    public static int EvaluateAM(Player p)
    {
        float eval = 0;

        //shooting = 15%;
        //pace = 12%
        //anticipation = 11%;
        //tackling = 3%;
        //header = 9%;
        //shortpass = 12%;
        //longpass = 12%;
        //strength = 7%;
        //stamina = 8%;
        //agility = 10%;

        eval = (float)(
            p.shooting * .15 +
            p.pace * .12 +
            p.anticipation * .11 +
            p.tackling * .03 +
            p.header * .09 +
            p.shortPass * .12 +
            p.longPass * .12 +
            p.strength * .07 +
            p.stamina * .08 +
            p.agility * .10);

        return (int)(eval);
    }

    public static int EvaluateST(Player p)
    {
        float eval = 0;

        //shooting = 16%;
        //pace = 13%
        //anticipation = 11%;
        //tackling = 1%;
        //header = 13%;
        //shortpass = 9%;
        //longpass = 7%;
        //strength = 10%;
        //stamina = 10%;
        //agility = 10%;

        eval = (float)(
            p.shooting * .16 +
            p.pace * .13 +
            p.anticipation * .11 +
            p.tackling * .01 +
            p.header * .13 +
            p.shortPass * .09 +
            p.longPass * .07 +
            p.strength * .10 +
            p.stamina * .10 +
            p.agility * .10);

        return (int)(eval);
    }

    public static int EvaluateCF(Player p)
    {
        float eval = 0;

        //shooting = 20%;
        //pace = 9%
        //anticipation = 15%;
        //tackling = 0%;
        //header = 16%;
        //shortpass = 5%;
        //longpass = 5%;
        //strength = 15%;
        //stamina = 10%;
        //agility = 5%;

        eval = (float)(
            p.shooting * .20 +
            p.pace * .09 +
            p.anticipation * .15 +
            p.tackling * .0 +
            p.header * .16 +
            p.shortPass * .05 +
            p.longPass * .05 +
            p.strength * .15 +
            p.stamina * .10 +
            p.agility * .05);

        return (int)(eval);
    }

    public static int EvaluateWF(Player p)
    {
        float eval = 0;

        //shooting = 10%;
        //pace = 20%
        //anticipation = 7%;
        //tackling = 1%;
        //header = 7%;
        //shortpass = 8%;
        //longpass = 8%;
        //strength = 7%;
        //stamina = 12%;
        //agility = 20%;

        eval = (float)(
            p.shooting * .10 +
            p.pace * .20 +
            p.anticipation * .07 +
            p.tackling * .01 +
            p.header * .07 +
            p.shortPass * .08 +
            p.longPass * .08 +
            p.strength * .07 +
            p.stamina * .12 +
            p.agility * .20);

        return (int)(eval);
    }

    public static int EvaluateWM(Player p)
    {
        float eval = 0;

        //shooting = 10%;
        //pace = 15%
        //anticipation = 10%;
        //tackling = 7%;
        //header = 7%;
        //shortpass = 10%;
        //longpass = 10%;
        //strength = 7%;
        //stamina = 12%;
        //agility = 12%;

        eval = (float)(
            p.shooting * .10 +
            p.pace * .15 +
            p.anticipation * .10 +
            p.tackling * .07 +
            p.header * .07 +
            p.shortPass * .10 +
            p.longPass * .10 +
            p.strength * .07 +
            p.stamina * .12 +
            p.agility * .12);

        return (int)(eval);
    }

    public static int EvaluateFB(Player p)
    {
        float eval = 0;

        //shooting = 4%;
        //pace = 12%
        //anticipation = 11%;
        //tackling = 18%;
        //header = 7%;
        //shortpass = 8%;
        //longpass = 8%;
        //strength = 9%;
        //stamina = 10%;
        //agility = 13%;

        eval = (float)(
            p.shooting * .04 +
            p.pace * .12 +
            p.anticipation * .11 +
            p.tackling * .18 +
            p.header * .07 +
            p.shortPass * .08 +
            p.longPass * .08 +
            p.strength * .09 +
            p.stamina * .10 +
            p.agility * .13);

        return (int)(eval);
    }

    public static int EvaluateCB(Player p)
    {
        float eval = 0;

        //shooting = 2%;
        //pace = 7%
        //anticipation = 21%;
        //tackling = 20%;
        //header = 10%;
        //shortpass = 5%;
        //longpass = 5%;
        //strength = 15%;
        //stamina = 10%;
        //agility = 5%;

        eval = (float)(
            p.shooting * .02 +
            p.pace * .07 +
            p.anticipation * .21 +
            p.tackling * .20 +
            p.header * .10 +
            p.shortPass * .05 +
            p.longPass * .05 +
            p.strength * .15 +
            p.stamina * .10 +
            p.agility * .05);

        return (int)(eval);
    }

    public static int EvaluateGK(Player p)
    {
        float eval = 0;

        eval = (float)(p.keeperAnticipation * .5 + p.keeperSaving * .5);

        return (int)(eval);
    }

    public class AbilityBasedPlayerComparer : IComparer<Player>
    {
        public int Compare(Player x, Player y)
        {
            return EvaluatePlayer(x) - EvaluatePlayer(y);
        }
    }

    public class AbilityBasedPlayerDescendingComparer : IComparer<Player>
    {
        public int Compare(Player x, Player y)
        {
            return EvaluatePlayer(y) - EvaluatePlayer(x);
        }
    }

    public class AttackingAbilityBasedPlayerDescendingComparer : IComparer<Player>
    {
        public int Compare(Player x, Player y)
        {
            return EvaluateST(y) - EvaluateST(x);
        }
    }

    public class PassingAbilityBasedPlayerDescendingComparer : IComparer<Player>
    {
        public int Compare(Player x, Player y)
        {
            return EvaluateAM(y) - EvaluateAM(x);
        }
    }

    public class GoalsBasedPlayerDescendingComparer : IComparer<Player>
    {
        public int Compare(Player x, Player y)
        {
            return y.goals - x.goals;
        }
    }

    public class AssistBasedPlayerDescendingComparer : IComparer<Player>
    {
        public int Compare(Player x, Player y)
        {
            return y.assists - x.assists;
        }
    }

    public class AgeBasedPlayerComparer : IComparer<Player>
    {
        public int Compare(Player x, Player y)
        {
            return x.GetAge() - y.GetAge();
        }
    }
}
