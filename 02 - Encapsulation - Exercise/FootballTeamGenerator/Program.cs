using FootballTeamGenerator;
using System;
using System.Collections.Generic;
using System.Linq;

List<Team> teams = new List<Team>();

string input;

while ((input = Console.ReadLine()) != "END")
{
    string[] commArgs = input
        .Split(";");

    string commandType = commArgs[0];
    string teamName = commArgs[1];
	try
	{
        if (commandType == "Team")
        {
            AddTeam(teams, teamName);
        }

        else if (commandType == "Add")
        {
            AddPlayerToTeam(teams, commArgs, teamName);
        }

        else if (commandType == "Remove")
        {
            RemovePlayerFromTeam(teams, commArgs, teamName);
        }

        else if (commandType == "Rating")
        {
            ShowTeamRating(teams, teamName);
        }
    }
	catch (Exception ex)
	{
        Console.WriteLine(ex.Message);
        continue;
	}
}

static void AddTeam(List<Team> teams, string teamName)
{
    Team newtTeam = new Team(teamName);
    teams.Add(newtTeam);
}

static void AddPlayerToTeam(List<Team> teams, string[] commArgs, string teamName)
{
    Team team = teams.FirstOrDefault(t => t.Name == teamName);

    if (team != null)
    {
        Player playerToAdd = new Player(
            commArgs[2],
            int.Parse(commArgs[3]),
            int.Parse(commArgs[4]),
            int.Parse(commArgs[5]),
            int.Parse(commArgs[6]),
            int.Parse(commArgs[7]));
        team.AddPlayer(playerToAdd);
    }
    else
    {
        Console.WriteLine($"Team {teamName} does not exist.");
    }
}

static void RemovePlayerFromTeam(List<Team> teams, string[] commArgs, string teamName)
{
    string playerName = commArgs[2];
    Team team = teams.FirstOrDefault(t => t.Name == teamName);

    team.RemovePlayer(playerName);
}

static void ShowTeamRating(List<Team> teams, string teamName)
{
    Team team = teams.FirstOrDefault(t => t.Name == teamName);

    if (team != null)
    {
        Console.WriteLine($"{teamName} - {team.Rating}");
    }
    else
    {
        Console.WriteLine($"Team {teamName} does not exist.");
    }
}