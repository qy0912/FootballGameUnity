using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public int ID;
    public string playerName;
    public float keeperAnticipation;
    public float keeperSaving;
    public float pace;
    public float anticipation;
    public float tackling;
    public float header;
    public float shortPass;
    public float longPass;
    public float strength;
    public float agility;
    public float fragile;
    public float weakerFoot;
    public string previousClubs;
    public string nationality;
    public string position;
    public int marketValue;
    public int numberPreference;
    public int professional;
    public int moneyStatus;
    public int married;
    public string chlidrenNames;
    public float composure;
    public float dirtyness;
    public float angerControl;
    public float speechMaking;
    public float domesticPopulation;
    public float internationalPopulation;
    public string birthday;
    public string birthPlace;
    public string academyPlace;
    public int educationLevel;
    public int salary;
    public string clubRelations;
    public string peopleRelations;
    public string injuryHistory;
    public string relationshipHistory;
    public string partnerName;
    public string personalSponsor;
    public string brandPreference;
    public int generated;
    public float majiang;
    public float doudizhu;
    public float alchohol;
    public float xiangqi;
    public float shooting;
    public float ambition;
    public float stamina;
    public string umaString;
    public string currentClub;
    public int signatureFont;
    public int height;
    public string profession;
    public string graduatedSchool;
    public int numberWearing;
    public string skill;
    public int weight;

    public int goals;
    public int assists;
    public string statsHistory;
    public string contractDetails;

    public override string ToString() {
        return this.GetDatabaseFormatString();
    }

    public string GetEscapedDatabaseFormatString()
    {
        string ret = "";
        ret += (ID + ",");
        ret += ("''" + currentClub + "''" + ",");
        ret += ("''" + playerName + "''" + ",");
        ret += (keeperAnticipation + ",");
        ret += (keeperSaving + ",");
        ret += (pace + ",");
        ret += (anticipation + ",");
        ret += (tackling + ",");
        ret += (header + ",");
        ret += (shortPass + ",");
        ret += (longPass + ",");
        ret += (strength + ",");
        ret += (agility + ",");
        ret += (fragile + ",");
        ret += (weakerFoot + ",");
        ret += ("''" + previousClubs + "''" + ",");
        ret += ("''" + nationality + "''" + ",");
        ret += ("''" + position + "''" + ",");
        ret += ("''" + umaString + "''" + ",");
        ret += (marketValue + ",");
        ret += (numberPreference + ",");
        ret += (ambition + ",");
        ret += (professional + ",");
        ret += (moneyStatus + ",");
        ret += (married + ",");
        ret += ("''" + chlidrenNames + "''" + ",");
        ret += (composure + ",");
        ret += (dirtyness + ",");
        ret += (angerControl + ",");
        ret += (speechMaking + ",");
        ret += (domesticPopulation + ",");
        ret += (internationalPopulation + ",");
        ret += ("''" + birthday + "''" + ",");
        ret += ("''" + birthPlace + "''" + ",");
        ret += ("''" + academyPlace + "''" + ",");
        ret += (educationLevel + ",");
        ret += (salary + ",");
        ret += ("''" + clubRelations + "''" + ",");
        ret += ("''" + peopleRelations + "''" + ",");
        ret += ("''" + injuryHistory + "''" + ",");
        ret += ("''" + relationshipHistory + "''" + ",");
        ret += ("''" + partnerName + "''" + ",");
        ret += ("''" + personalSponsor + "''" + ",");
        ret += ("''" + brandPreference + "''" + ",");
        ret += (majiang + ",");
        ret += (doudizhu + ",");
        ret += (alchohol + ",");
        ret += (xiangqi + ",");
        ret += (signatureFont + ",");
        ret += (shooting + ",");
        ret += (stamina + ",");
        ret += (generated + ",");
        ret += (height + ",");
        ret += ("''" + profession + "''" + ",");
        ret += ("''" + graduatedSchool + "''" + ",");
        ret += (numberWearing + "");
        return ret;
    }

    public string GetDatabaseFormatString()
    {
        string ret = "";
        ret += (ID + ",");
        ret += ("'"+currentClub+ "'" + ",");
        ret += ("'"+playerName+ "'" + ",");
        ret += (keeperAnticipation + ",");
        ret += (keeperSaving + ",");
        ret += (pace + ",");
        ret += (anticipation + ",");
        ret += (tackling + ",");
        ret += (header + ",");
        ret += (shortPass + ",");
        ret += (longPass + ",");
        ret += (strength + ",");
        ret += (agility + ",");
        ret += (fragile + ",");
        ret += (weakerFoot + ",");
        ret += ("'"+previousClubs+ "'" + ",");
        ret += ("'"+nationality+ "'" + ",");
        ret += ("'"+position+ "'" + ",");
        ret += ("'"+umaString+"'" + ",");
        ret += (marketValue + ",");
        ret += (numberPreference + ",");
        ret += (ambition + ",");
        ret += (professional + ",");
        ret += (moneyStatus + ",");
        ret += (married + ",");
        ret += ("'"+chlidrenNames+"'" + ",");
        ret += (composure + ",");
        ret += (dirtyness + ",");
        ret += (angerControl + ",");
        ret += (speechMaking + ",");
        ret += (domesticPopulation + ",");
        ret += (internationalPopulation + ",");
        ret += ("'"+birthday+"'" + ",");
        ret += ("'"+birthPlace+ "'" + ",");
        ret += ("'"+academyPlace +"'" + ",");
        ret += (educationLevel + ",");
        ret += (salary + ",");
        ret += ("'"+clubRelations+ "'" + ",");
        ret += ("'" + peopleRelations + "'" + ",");
        ret += ("'"+injuryHistory+"'" + ",");
        ret += ("'"+relationshipHistory+ "'" + ",");
        ret += ("'"+partnerName+ "'" + ",");
        ret += ("'"+personalSponsor+"'" + ",");
        ret += ("'"+brandPreference+ "'" + ",");
        ret += (majiang + ",");
        ret += (doudizhu + ",");
        ret += (alchohol + ",");
        ret += (xiangqi + ",");
        ret += (signatureFont + ",");
        ret += (shooting + ",");
        ret += (stamina+ ",");
        ret += (generated + ",");
        ret += (height + ",");
        ret += ("'" + profession + "'" + ",");
        ret += ("'" + graduatedSchool + "'" + ",");
        ret += ("'" + numberWearing + "'" + ",");
        ret += ("'" + skill + "'" + ",");
        ret += (1 + "");
        return ret;
    }

    public int GetAge()
    {
        return System.Int32.Parse(this.birthday);
    }

    public void SetAge(int age)
    {
        this.birthday = age+"";
    }

    public List<Tuple<string,float>> GetStrengths(bool weakest = false)
    {
        List<Tuple<string, float>> tuples = new List<Tuple<string, float>>();
        tuples.Add(new Tuple<string, float>("速度", pace));
        tuples.Add(new Tuple<string, float>("预判", anticipation));
        tuples.Add(new Tuple<string, float>("抢断", tackling));
        tuples.Add(new Tuple<string, float>("头球", header));
        tuples.Add(new Tuple<string, float>("短传", shortPass));
        tuples.Add(new Tuple<string, float>("长传", longPass));
        tuples.Add(new Tuple<string, float>("力量", strength));
        tuples.Add(new Tuple<string, float>("灵巧", agility));
        tuples.Add(new Tuple<string, float>("射门", shooting));
        tuples.Add(new Tuple<string, float>("体力", stamina));
        tuples.Add(new Tuple<string, float>("镇定", composure));
        int mag = weakest ? 1: -1;
        tuples.Sort(
            (a, b) => ((int)(a.Item2 * 10 - b.Item2 * 10) *  mag)
            );
        return tuples;
    }

    public void ModifyAbilityByMagnitude(float mag)
    {
        keeperAnticipation = (int)(keeperAnticipation * mag);
        keeperSaving = (int)(keeperSaving * mag);
        pace = (int)(pace * mag);
        anticipation = (int)(anticipation * mag);
        tackling = (int)(tackling * mag);
        header = (int)(header * mag);
        shortPass = (int)(shortPass * mag);
        longPass = (int)(longPass * mag);
        strength = (int)(strength * mag);
        agility = (int)(agility * mag);
        shooting = (int)(shooting * mag);
        stamina = (int)(stamina * mag);
        height = (int)(height * mag * 1.05);
    }

    public void ModifyAbilityByMagnitudeNoHeight(float mag)
    {
        keeperAnticipation = (int)(keeperAnticipation * mag);
        keeperSaving = (int)(keeperSaving * mag);
        pace = (int)(pace * mag);
        anticipation = (int)(anticipation * mag);
        tackling = (int)(tackling * mag);
        header = (int)(header * mag);
        shortPass = (int)(shortPass * mag);
        longPass = (int)(longPass * mag);
        strength = (int)(strength * mag);
        agility = (int)(agility * mag);
        shooting = (int)(shooting * mag);
        stamina = (int)(stamina * mag);
    }

    public string GetJerseyedUMAString()
    {
        if (this.umaString.ToLower().Contains("asiang8m"))
            return this.umaString;
        var splittedUMAString = umaString.Split(']');
        string jerseySlotString = ",{\"slot\":\"Chest\",\"recipe\":\"M_T-Shirt_4\"}]";
        string jerseyedUMAString = "";
        for (int i = 0; i < splittedUMAString.Length; i++)
        {
            jerseyedUMAString += splittedUMAString[i];
            if (i == splittedUMAString.Length - 2)
                jerseyedUMAString += jerseySlotString;
            else if (i != splittedUMAString.Length - 1)
                jerseyedUMAString += ']';
        }
        return jerseyedUMAString;
    }


    public string GetSuitedUMAString()
    {
        if (this.umaString.ToLower().Contains("asiang8m"))
            return this.umaString;
        var splittedUMAString = umaString.Split(']');
        string jerseySlotString = ",{\"slot\":\"FullOutfit\",\"recipe\":\"M_Suit_2\"}]";
        string jerseyedUMAString = "";
        for (int i = 0; i < splittedUMAString.Length; i++)
        {
            jerseyedUMAString += splittedUMAString[i];
            if (i == splittedUMAString.Length - 2)
                jerseyedUMAString += jerseySlotString;
            else if (i != splittedUMAString.Length - 1)
                jerseyedUMAString += ']';
        }
        return jerseyedUMAString;
    }

    public string GetJerseyedShortsedUMAString()
    {
        if (this.position == "门将")
            return GetKeeperJerseyedShortsedUMAString();

        var splittedUMAString = umaString.Split(']');
        string jerseySlotString = ",{\"slot\":\"Complexion\",\"recipe\":\"AsianG8M.FullPlayerOutfit 1\"}]";
        string jerseyedUMAString = "";
        for (int i = 0; i < splittedUMAString.Length; i++)
        {
            jerseyedUMAString += splittedUMAString[i];
            if (i == splittedUMAString.Length - 2)
                jerseyedUMAString += jerseySlotString;
            else if (i != splittedUMAString.Length - 1)
                jerseyedUMAString += ']';
        }
        return jerseyedUMAString;
    }

    public string GetKeeperJerseyedShortsedUMAString()
    {
        var splittedUMAString = umaString.Split(']');
        string jerseySlotString = ",{\"slot\":\"Complexion\",\"recipe\":\"AsianG8M.FullPlayerOutfit 1\"}]";
        string jerseyedUMAString = "";
        for (int i = 0; i < splittedUMAString.Length; i++)
        {
            jerseyedUMAString += splittedUMAString[i];
            if (i == splittedUMAString.Length - 2)
                jerseyedUMAString += jerseySlotString;
            else if (i != splittedUMAString.Length - 1)
                jerseyedUMAString += ']';
        }
        return jerseyedUMAString;
    }

    public string GetOpponentJerseyedShortsedUMAString()
    {
        if (this.umaString.ToLower().Contains("asiang8m"))
            return this.umaString;
        if (this.position == "门将")
            return GetOpponentKeeperJerseyedShortsedUMAString();

        var splittedUMAString = umaString.Split(']');
        string jerseySlotString = ",{\"slot\":\"Chest\",\"recipe\":\"M_T-Shirt_6\"},{\"slot\":\"Legs\",\"recipe\":\"M_ShortsT2_4\"},{\"slot\":\"Feet\",\"recipe\":\"M_SportShoes\"}]";
        string jerseyedUMAString = "";
        for (int i = 0; i < splittedUMAString.Length; i++)
        {
            jerseyedUMAString += splittedUMAString[i];
            if (i == splittedUMAString.Length - 2)
                jerseyedUMAString += jerseySlotString;
            else if (i != splittedUMAString.Length - 1)
                jerseyedUMAString += ']';
        }
        return jerseyedUMAString;
    }

    public string GetOpponentKeeperJerseyedShortsedUMAString()
    {
        if (this.umaString.ToLower().Contains("asiang8m"))
            return this.umaString;
        var splittedUMAString = umaString.Split(']');
        string jerseySlotString = ",{\"slot\":\"Chest\",\"recipe\":\"M_T-Shirt_7\"},{\"slot\":\"Legs\",\"recipe\":\"M_ShortsT2_5\"},{\"slot\":\"Feet\",\"recipe\":\"M_SportShoes\"},{\"slot\":\"Hands\",\"recipe\":\"M_Gloves_1\"}]";
        string jerseyedUMAString = "";
        for (int i = 0; i < splittedUMAString.Length; i++)
        {
            jerseyedUMAString += splittedUMAString[i];
            if (i == splittedUMAString.Length - 2)
                jerseyedUMAString += jerseySlotString;
            else if (i != splittedUMAString.Length - 1)
                jerseyedUMAString += ']';
        }
        return jerseyedUMAString;
    }

    public static Player DeepCopy(Player player)
    {
        Player p = new Player();
        p.ID = player.ID;
        p.playerName = player.playerName;
        p.keeperAnticipation = player.keeperAnticipation;
        p.keeperSaving = player.keeperSaving;
        p.pace = player.pace;
        p.anticipation = player.anticipation;
        p.tackling = player.tackling;
        p.header = player.header;
        p.shortPass = player.shortPass;
        p.longPass = player.longPass;
        p.strength = player.strength;
        p.agility = player.agility;
        p.fragile = player.fragile;
        p.weakerFoot = player.weakerFoot;
        p.previousClubs = player.previousClubs;
        p.nationality = player.nationality;
        p.position = player.position;
        p.marketValue = player.marketValue;
        p.numberPreference = player.numberPreference;
        p.professional = player.professional;
        p.moneyStatus = player.moneyStatus;
        p.composure = player.composure;
        p.dirtyness = player.dirtyness;
        p.angerControl = player.angerControl;
        p.speechMaking = player.speechMaking;
        p.domesticPopulation = player.domesticPopulation;
        p.internationalPopulation = player.internationalPopulation;
        p.birthday = player.birthday;
        p.birthPlace = player.birthPlace;
        p.academyPlace = player.academyPlace;
        p.educationLevel = player.educationLevel;
        p.salary = player.salary;
        p.generated = player.generated;
        p.shooting = player.shooting;
        p.ambition = player.ambition;
        p.stamina = player.stamina;
        p.umaString = player.umaString;
        p.currentClub = player.currentClub;
        p.signatureFont = player.signatureFont;
        p.height = player.height;
        p.numberWearing = player.numberWearing;
        p.skill = player.skill;
        p.weight = player.weight;
        p.goals = player.goals;
        p.assists = player.assists;
        return p;
    }
}
