namespace AllSports.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    internal sealed class Configuration : DbMigrationsConfiguration<AllSports.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AllSports.Data.ApplicationDbContext context)
        {

            context.Sports.AddOrUpdate(x => x.SportId,
                 new Sport() { SportName = "Football", YearInvented = 1880, Description = "a contact sport in which two teams of eleven players try to get the ball to the opposing teams end through running and passing of the ball." },
                 new Sport() { SportName = "Hockey", YearInvented = 1875, Description = "A contact sport played on ice in which two teams of players on ice skates compete to get a puck into the opposing teams net." },
                 new Sport() { SportName = "Soccer", YearInvented = 1863, Description = "Two teams of eleven players compete to try and get the ball into the opposing teams' goal." },
                 new Sport() { SportName = "Basketball", YearInvented = 1891, Description = "Two teams of five players try to get the ball into the opposing teams hoop in order to score points, most points at the end of the game wins." },
                 new Sport() { SportName = "Baseball", YearInvented = 1845, Description = "A bat and ball game in which two teams take turns fielding and batting,  the goal being to put the ball into the field of play without being caught, then rounding the bases trying to reach the home bases without being tagged. Team with most points after 9 innings wins." }
             );
            context.SaveChanges();

            context.Leagues.AddOrUpdate(x => x.LeagueId,
                new League() { LeagueName = "National Hockey League", NumberOfTeams = 31, LeagueInception = 1917, BaseCountry = "United States", SportId = 2 },
                new League() { LeagueName = "National Football League", NumberOfTeams = 32, LeagueInception = 1920, BaseCountry = "United States", SportId = 1 },
                new League() { LeagueName = "Major League Soccer", NumberOfTeams = 26, LeagueInception = 1996, BaseCountry = "United States", SportId = 3 },
                new League() { LeagueName = "National Basketball Association", NumberOfTeams = 30, LeagueInception = 1946, BaseCountry = "United States", SportId = 4 },
                new League() { LeagueName = "Major League Baseball", NumberOfTeams = 30, LeagueInception = 1903, BaseCountry = "United States", SportId = 5 }
                );
            context.SaveChanges();

            context.Teams.AddOrUpdate(x => x.TeamId,
                new Team() { TeamName = "Indiana Pacers", Wins = 1, Losses = 0, CityName = "Indianapolis", State = StateAbbreviation.IN, LeagueId = 4 }, //1
                new Team() { TeamName = "Los Angeles Lakers", Wins = 10, Losses = 11, CityName = "Los Angeles", State = StateAbbreviation.CA, LeagueId = 4 }, //2
                new Team() { TeamName = "Dallas Mavericks", Wins = 12, Losses = 0, CityName = "Dallas", State = StateAbbreviation.TX, LeagueId = 4 }, //3
                new Team() { TeamName = "Chicago Bulls", Wins = 0, Losses = 11, CityName = "Chicago", State = StateAbbreviation.IL, LeagueId = 4 }, //4
                new Team() { TeamName = "Boston Celtics", Wins = 12, Losses = 33, CityName = "Boston", State = StateAbbreviation.MA, LeagueId = 4 }, //5
                new Team() { TeamName = "Indianapolis Colts", Wins = 1, Losses = 0, CityName = "Indianapolis", State = StateAbbreviation.IN, LeagueId = 2 }, //6
                new Team() { TeamName = "Los Angeles Rams", Wins = 8, Losses = 8, CityName = "Los Angeles", State = StateAbbreviation.CA, LeagueId = 2 }, //7
                new Team() { TeamName = "Los Angeles Chargers", Wins = 6, Losses = 10, CityName = "Los Angeles", State = StateAbbreviation.CA, LeagueId = 2 }, //8
                 new Team() { TeamName = "Chicago Bears", Wins = 10, Losses = 11, CityName = "Chicago", State = StateAbbreviation.IL, LeagueId = 2 }, //9
                 new Team() { TeamName = "New England Patriots", Wins = 0, Losses = 16, CityName = "Boston", State = StateAbbreviation.MA, LeagueId = 2 }, //10
                 new Team() { TeamName = "Chicago WhiteSoxs", Wins = 16, Losses = 11, CityName = "Chicago", State = StateAbbreviation.IL, LeagueId = 5 }, //11
                 new Team() { TeamName = "Chicago Cubs", Wins = 16, Losses = 12, CityName = "Chicago", State = StateAbbreviation.IL, LeagueId = 5 }, //12
                 new Team() { TeamName = "New York Yankees", Wins = 1, Losses = 33, CityName = "New York City", State = StateAbbreviation.NY, LeagueId = 5 }, //13
                 new Team() { TeamName = "New York Mets", Wins = 12, Losses = 8, CityName = "New York City", State = StateAbbreviation.NY, LeagueId = 5 }, //14
                 new Team() { TeamName = "Los Angeles Dodgers", Wins = 6, Losses = 10, CityName = "Los Angeles", State = StateAbbreviation.CA, LeagueId = 5 }, //15
                 new Team() { TeamName = "Chicago BlackHawks", Wins = 20, Losses = 12, CityName = "Chicago", State = StateAbbreviation.IL, LeagueId = 1 }, //16
                 new Team() { TeamName = "New York Islanders", Wins = 22, Losses = 20, CityName = "New York City", State = StateAbbreviation.NY, LeagueId = 1 }, //17
                 new Team() { TeamName = "New York Rangers", Wins = 15, Losses = 20, CityName = "New York City", State = StateAbbreviation.NY, LeagueId = 1 }, //18
                 new Team() { TeamName = "Columbus Blue Jackets", Wins = 16, Losses = 12, CityName = "Columbus", State = StateAbbreviation.OH, LeagueId = 1 }, //19
                 new Team() { TeamName = "Nashville Predators", Wins = 15, Losses = 8, CityName = "Nashville", State = StateAbbreviation.TN, LeagueId = 1 }, //20
                 new Team() { TeamName = "Chicago Fire F.C.", Wins = 8, Losses = 3, CityName = "Chicago", State = StateAbbreviation.IL, LeagueId = 3 }, //21
                 new Team() { TeamName = "Columbus Crew", Wins = 5, Losses = 10, CityName = "Columbus", State = StateAbbreviation.OH, LeagueId = 3 }, //22
                 new Team() { TeamName = "New York RedBulls", Wins = 10, Losses = 2, CityName = "New York City", State = StateAbbreviation.NY, LeagueId = 3 }, //23
                 new Team() { TeamName = "L.A. Galaxy", Wins = 6, Losses = 10, CityName = "Los Angeles", State = StateAbbreviation.CA, LeagueId = 3 }, //24
                 new Team() { TeamName = "D.C.", Wins = 10, Losses = 5, CityName = "Washington", State = StateAbbreviation.DC, LeagueId = 3 } //25
                 );
            context.SaveChanges();

            context.Players.AddOrUpdate(x => x.PlayerId,
                new Player()
                {
                    FirstName = "T.J.",
                    LastName = "Warren",
                    DateOfBirth = new DateTime(1993, 09, 05), //date time must be formatted like this.
                    JerseyNumber = 1,
                    Height = "6' 8",
                    Weight = 220,
                    YearsWithTeam = 1,
                    College = "North Carolina State",
                    TwitterHandle = "https://twitter.com/TonyWarrenJr",
                    TeamId = 1
                },
                new Player()
                {
                    PlayerId = 1,
                    FirstName = "Malcom",
                    LastName = "Brogdon",
                    DateOfBirth = new DateTime(1992, 12, 11),
                    JerseyNumber = 7,
                    Height = "6' 5",
                    Weight = 229,
                    YearsWithTeam = 1,
                    College = "Virginia",
                    TwitterHandle = "",
                    TeamId = 1
                },
                new Player()
                {
                    FirstName = "Victor",
                    LastName = "Oladipo",
                    DateOfBirth = new DateTime(1992, 12, 11),
                    JerseyNumber = 4,
                    Height = "6' 4",
                    Weight = 213,
                    YearsWithTeam = 3,
                    College = "Indiana",
                    TwitterHandle = "https://twitter.com/VicOladipo",
                    TeamId = 1
                },
                new Player()
                {
                    FirstName = "Domantas",
                    LastName = "Sabonis",
                    DateOfBirth = new DateTime(1996, 05, 03),
                    JerseyNumber = 4,
                    Height = "6' 11",
                    Weight = 240,
                    YearsWithTeam = 2,
                    College = "Gonzaga",
                    TwitterHandle = "https://twitter.com/Dsabonis11",
                    TeamId = 1
                },
                new Player()
                {
                    FirstName = "Lebron",
                    LastName = "James",
                    DateOfBirth = new DateTime(1984, 12, 30),
                    JerseyNumber = 23,
                    Height = "6' 9",
                    Weight = 250,
                    YearsWithTeam = 2,
                    College = "",
                    TwitterHandle = "https://twitter.com/kingjames",
                    TeamId = 2
                },
                new Player()
                {
                    FirstName = "Anthony",
                    LastName = "Davis",
                    DateOfBirth = new DateTime(1993, 03, 11),
                    JerseyNumber = 23,
                    Height = " 6' 10",
                    Weight = 253,
                    YearsWithTeam = 1,
                    College = "Kentucky",
                    TwitterHandle = "https://twitter.com/antdavis23",
                    TeamId = 2
                },
                new Player()
                {
                    FirstName = "Myles",
                    LastName = "Turner",
                    DateOfBirth = new DateTime(1996, 03, 24),
                    JerseyNumber = 33,
                    Height = "6' 11",
                    Weight = 250,
                    YearsWithTeam = 5,
                    College = "Texas",
                    TwitterHandle = "https://twitter.com/Original_Turner",
                    TeamId = 1
                },
                new Player()
                {
                    FirstName = "Kyle",
                    LastName = "Kuzma",
                    DateOfBirth = new DateTime(1995, 07, 24),
                    JerseyNumber = 0,
                    Height = "6' 8",
                    Weight = 221,
                    YearsWithTeam = 2,
                    College = "Utah",
                    TwitterHandle = "https://twitter.com/kylekuzma",
                    TeamId = 2
                },
                new Player()
                {
                    FirstName = "Alex",
                    LastName = "Caruso",
                    DateOfBirth = new DateTime(1994, 02, 28),
                    JerseyNumber = 4,
                    Height = "6' 5",
                    Weight = 186,
                    YearsWithTeam = 2,
                    College = "Texas A&M",
                    TwitterHandle = "https://twitter.com/ACFresh21",
                    TeamId = 2,
                },
                new Player()
                {
                    FirstName = "Rajon",
                    LastName = "Rondo",
                    DateOfBirth = new DateTime(1986, 02, 22),
                    JerseyNumber = 9,
                    Height = "6' 1",
                    Weight = 180,
                    YearsWithTeam = 2,
                    College = "Kentucky",
                    TwitterHandle = "https://twitter.com/rajonrondo",
                    TeamId = 2,
                },
                new Player()
                {
                    FirstName = "Luka",
                    LastName = "Doncic",
                    DateOfBirth = new DateTime(1998, 02, 28),
                    JerseyNumber = 77,
                    Height = "6' 7",
                    Weight = 230,
                    YearsWithTeam = 2,
                    College = "None",
                    TwitterHandle = "https://twitter.com/luka7doncic",
                    TeamId = 3
                },
                new Player()
                {
                    FirstName = "Kristaps",
                    LastName = "Porzingis",
                    DateOfBirth = new DateTime(1995, 08, 02),
                    JerseyNumber = 6,
                    Height = "7' 3",
                    Weight = 240,
                    YearsWithTeam = 1,
                    College = "None",
                    TwitterHandle = "https://twitter.com/kporzee",
                    TeamId = 3,
                },
                new Player()
                {
                    FirstName = "Seth",
                    LastName = "Curry",
                    DateOfBirth = new DateTime(1990, 08, 23),
                    JerseyNumber = 30,
                    Height = "6' 2",
                    Weight = 185,
                    YearsWithTeam = 2,
                    College = "Duke",
                    TwitterHandle = "https://twitter.com/sdotcurry",
                    TeamId = 3,
                },
                new Player()
                {
                    FirstName = "Wendell",
                    LastName = "Carter Jr.",
                    DateOfBirth = new DateTime(1999, 04, 16),
                    JerseyNumber = 34,
                    Height = "6' 9",
                    Weight = 270,
                    YearsWithTeam = 2,
                    College = "Duke",
                    TwitterHandle = "https://twitter.com/WendellCarterJr",
                    TeamId = 4,
                },
                new Player()
                {
                    FirstName = "Coby",
                    LastName = "White",
                    DateOfBirth = new DateTime(2000, 02, 16),
                    JerseyNumber = 0,
                    Height = "6' 4",
                    Weight = 195,
                    YearsWithTeam = 1,
                    College = "North Carolina",
                    TwitterHandle = "https://twitter.com/CobyWhite",
                    TeamId = 4
                },
                new Player()
                {
                    FirstName = "Thaddeus",
                    LastName = "Young",
                    DateOfBirth = new DateTime(1988, 06, 21),
                    JerseyNumber = 21,
                    Height = "6' 8",
                    Weight = 235,
                    YearsWithTeam = 1,
                    College = "Georgia Tech",
                    TwitterHandle = "",
                    TeamId = 4
                }// last database up date point
                );
            context.SaveChanges();







            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}

