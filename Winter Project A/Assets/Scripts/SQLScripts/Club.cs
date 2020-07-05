using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club
{
    public int clubID;
    public string clubName;
    public int clubEstYear;
    public List<Player> players;
    public string clubLocation;
    public int clubFame;
    public int clubWealth;
    public string playerString = "null";
    public string transferListString = "null";
    public string loanListString = "null";
    public int belongingLeague;
    public int generated;
    public int captainPID;
    public string startingLineupString;
    public int stadiumCapacity;
    public int supporterCount;
    public string stadiumName;

    public static List<Player> GenerateOptimalStartingLineup(Club target)
    {
        string[] formationList = new string[] { "门将", "左边卫", "中后卫", "中后卫", "右边卫", "左边前卫", "中前卫", "中前卫", "右边前卫", "前锋", "前锋" };
        var list = new List<Player>();
        var temp = new List<Player>();

        foreach (var v in target.players)
        {
            temp.Add(v);
        }

        foreach (var pos in formationList)
        {
            var l = new List<Player>();
            foreach (var v in temp)
            {
                if (v.position == pos)
                    l.Add(v);
            }
            l.Sort(new PlayerEvaluater.AbilityBasedPlayerDescendingComparer());
            if (l.Count > 0)
            {
                list.Add(l[0]);
                temp.Remove(l[0]);
            }
        }

        temp.Sort(new PlayerEvaluater.AttackingAbilityBasedPlayerDescendingComparer());
        int idx = 0;
        while (list.Count < 11)
        {
            if (temp[idx].position != "门将")
                list.Add(temp[idx++]);
        }

        return list;
    }

    public int managerID;
    public int relationship;

    public Club(int clubID, string clubName, int clubEstYear, List<Player> players, string clubLocation, int clubFame, int clubWealth,
        string playerString, string transferListString, string loanListString, int belongingLeague, int generated, string startingLineup, int stadiumCapacity, string stadiumName, int supporterCount, int managerID, int relationship)
    {
        this.clubID = clubID;
        this.clubName = clubName;
        this.clubEstYear = clubEstYear;
        this.players = players;
        this.clubLocation = clubLocation;
        this.clubFame = clubFame;
        this.clubWealth = clubWealth;
        this.playerString = playerString;
        this.transferListString = transferListString;
        this.loanListString = loanListString;
        this.belongingLeague = belongingLeague;
        this.generated = generated;
        this.startingLineupString = startingLineup;
        this.stadiumCapacity = stadiumCapacity;
        this.stadiumName = stadiumName;
        this.supporterCount = supporterCount;
        this.managerID = managerID;
        this.relationship = relationship;
    }

    public string GetCityLocation()
    {
        return this.clubLocation.Split(',')[0];
    }

    public string GetProvinceLocation()
    {
        return this.clubLocation.Split(',')[1];
    }

    public List<Player> GetStartingLineupPlayers()
    {
        List<Player> players = new List<Player>();
        List<int> ids = new List<int>();
        foreach (var v in startingLineupString.Split(':')[0].Split(','))
        {
            ids.Add(System.Int32.Parse(v));
        }
        players = StreamingDatabaseManager.GetMultiplePlayers(ids);
        return players;
    }

    public int GetPowerEstimate()
    {
        int ret = 0;
        foreach (var v in players)
        {
            ret += PlayerEvaluater.EvaluatePlayer(v);
        }
        return ret;
    }

    public string GetDatabaseFormatString()
    {
        string ret = "";
        ret += (clubID + ",");
        ret += ("'" + clubName + "'" + ",");
        ret += (clubWealth + ",");
        ret += (clubFame + ",");
        ret += (clubEstYear + ",");
        ret += ("'" + clubLocation + "'" + ",");
        ret += ("'" + transferListString + "'" + ",");
        ret += ("'" + loanListString + "'" + ",");
        ret += ("'" + playerString + "'" + ",");
        ret += (belongingLeague + ",");
        ret += (generated + "");
        return ret;
    }

    public Player GetPossibleScorer()
    {
        var temp = new List<Player>();
        foreach (var v in players)
            temp.Add(v);
        temp.Sort(new PlayerEvaluater.AttackingAbilityBasedPlayerDescendingComparer());

        int playerIdx = -1;
        float seed = Random.value;
        if (seed < 0.75)
            playerIdx = Random.Range(0, 4);
        else if (seed < 0.95)
            playerIdx = Random.Range(4, 8);
        else
            playerIdx = Random.Range(8, temp.Count - 1);
        return temp[playerIdx];
    }

    public List<Player> GetPossibleScorers()
    {
        var temp = new List<Player>();
        foreach (var v in players)
            temp.Add(v);
        temp.Sort(new PlayerEvaluater.AttackingAbilityBasedPlayerDescendingComparer());

        return temp;
    }

    public List<string> GetStrongestPositions(bool desc)
    {
        List<string> ret = new List<string>();

        string[] formationList = new string[] { "门将", "左边卫", "中后卫", "右边卫", "左边前卫", "中前卫", "后腰", "前腰", "右边前卫", "前锋", "左边锋", "右边锋" };
        Dictionary<string, float[]> dic = new Dictionary<string, float[]>();
        foreach (var v in formationList)
            dic[v] = new float[] { 1f, 0f };
        foreach (var v in players)
        {
            if (!dic.ContainsKey(v.position))
                continue;
            dic[v.position][0] += 1f;
            dic[v.position][1] += PlayerEvaluater.EvaluatePlayer(v);
        }

        //sort and get tops here
        List<string> ks = new List<string>();

        foreach (var v in dic.Keys)
            ks.Add(v);

        if (desc)
            ks.Sort((x, y) => (int)((dic[y][1] / dic[y][0]) - (dic[x][1] / dic[x][0])));
        else
            ks.Sort((y, x) => (int)((dic[y][1] / dic[y][0]) - (dic[x][1] / dic[x][0])));

        return ks;
    }


    public Player GetPossibleAssister(Player scorer)
    {

        var temp = new List<Player>();
        foreach (var v in players)
            if (scorer.ID != v.ID)
                temp.Add(v);
        temp.Sort(new PlayerEvaluater.PassingAbilityBasedPlayerDescendingComparer());

        int playerIdx = -1;
        float seed = Random.value;

        if (seed < 0.6)
            playerIdx = Random.Range(0, 8);
        else if (seed < 0.8)
            playerIdx = Random.Range(8, temp.Count - 2);
        else
            return null;
        return temp[playerIdx];
    }

    public List<Player> GetBestPlayers()
    {
        players.Sort((x, y) => PlayerEvaluater.EvaluatePlayer(y) - PlayerEvaluater.EvaluatePlayer(x));
        return players;
    }

    public Player GetRandomBestPlayer()
    {
        players.Sort((x, y) => PlayerEvaluater.EvaluatePlayer(y) - PlayerEvaluater.EvaluatePlayer(x));
        return players[Random.Range(0, Mathf.Min(8, players.Count - 1))];
    }

    public Player GetRandomWorstPlayer()
    {
        players.Sort((y, x) => PlayerEvaluater.EvaluatePlayer(y) - PlayerEvaluater.EvaluatePlayer(x));
        return players[Random.Range(0, Mathf.Min(3, players.Count - 1))];
    }
}
