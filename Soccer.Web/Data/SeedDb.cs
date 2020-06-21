using Soccer.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Soccer.Web.Data
{
    public class SeedDb
    {
        private readonly DataContex _dataContex;
        
        public SeedDb(DataContex dataContex)
        {
            _dataContex = dataContex;
        }

        public async  Task SeedAsync()
        {
            await _dataContex.Database.EnsureCreatedAsync();
            await CheckTeamsAsync();
            await CheckTournamentsAsync();
        }

        private async Task CheckTeamsAsync()
        {
            if (!_dataContex.Teams.Any())
            {
                await AddTeamAsync("Ajax");
                await AddTeamAsync("America");
                await AddTeamAsync("Argentina");
                await AddTeamAsync("Bolivia");
                await AddTeamAsync("Brasil");
                await AddTeamAsync("Bucaramanga");
                await AddTeamAsync("Canada");
                await AddTeamAsync("Chile");
                await AddTeamAsync("Colombia");
                await AddTeamAsync("Costa Rica");
                await AddTeamAsync("Ecuador");
                await AddTeamAsync("Honduras");
                await AddTeamAsync("Junior");
                await AddTeamAsync("Medellin");
                await AddTeamAsync("Mexico");
                await AddTeamAsync("Millonarios");
                await AddTeamAsync("Nacional");
                await AddTeamAsync("Once Caldas");
                await AddTeamAsync("Panama");
                await AddTeamAsync("Paraguay");
                await AddTeamAsync("Peru");
                await AddTeamAsync("Santa Fe");
                await AddTeamAsync("Uruguay");
                await AddTeamAsync("USA");
                await AddTeamAsync("Venezuela");
                await _dataContex.SaveChangesAsync();
            }
        }

        private async Task AddTeamAsync(string name)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\images\\Teams", $"{name}.jpg");
           //string imagenId=string.Empty;
            _dataContex.Teams.Add(new TeamEntity { Name = name, LogoPath = path });
        }

        private async Task CheckTournamentsAsync()
        {
            if (!_dataContex.Tournaments.Any())
            {
                DateTime startDate = DateTime.Today.AddMonths(2).ToUniversalTime();
                DateTime endDate = DateTime.Today.AddMonths(3).ToUniversalTime();

                
                _dataContex.Tournaments.Add(new TournamentEntity
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    IsActive = true,
                    LogoPath = $"~/images/Tournaments/Copa America 2020.png",
                    Name = "Copa America 2020",
                    Groups = new List<GroupEntity>
                    {
                        new GroupEntity
                        {
                             Name = "A",
                             GroupDetails = new List<GroupDetailEntity>
                             {
                                 new GroupDetailEntity { Team = _dataContex.Teams.FirstOrDefault(t => t.Name == "Colombia") },
                                 new GroupDetailEntity { Team = _dataContex.Teams.FirstOrDefault(t => t.Name == "Ecuador") },
                                 new GroupDetailEntity { Team = _dataContex.Teams.FirstOrDefault(t => t.Name == "Panama") },
                                 new GroupDetailEntity { Team = _dataContex.Teams.FirstOrDefault(t => t.Name == "Canada") }
                             },
                             Matches = new List<MatchEntity>
                             {
                                 new MatchEntity
                                 {
                                     Date = startDate.AddHours(14),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Colombia"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Ecuador")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddHours(17),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Panama"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Canada")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(4).AddHours(14),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Colombia"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Panama")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(4).AddHours(17),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Ecuador"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Canada")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(9).AddHours(16),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Canada"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Colombia")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(9).AddHours(16),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Ecuador"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Panama")
                                 }
                             }
                        },
                        new GroupEntity
                        {
                             Name = "B",
                             GroupDetails = new List<GroupDetailEntity>
                             {
                                 new GroupDetailEntity { Team = _dataContex.Teams.FirstOrDefault(t => t.Name == "Argentina") },
                                 new GroupDetailEntity { Team = _dataContex.Teams.FirstOrDefault(t => t.Name == "Paraguay") },
                                 new GroupDetailEntity { Team = _dataContex.Teams.FirstOrDefault(t => t.Name == "Mexico") },
                                 new GroupDetailEntity { Team = _dataContex.Teams.FirstOrDefault(t => t.Name == "Chile") }
                             },
                             Matches = new List<MatchEntity>
                             {
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(1).AddHours(14),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Argentina"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Paraguay")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(1).AddHours(17),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Mexico"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Chile")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(5).AddHours(14),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Argentina"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Mexico")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(5).AddHours(17),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Paraguay"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Chile")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(10).AddHours(16),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Chile"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Argentina")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(10).AddHours(16),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Paraguay"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Mexico")
                                 }
                             }
                        },
                        new GroupEntity
                        {
                             Name = "C",
                             GroupDetails = new List<GroupDetailEntity>
                             {
                                 new GroupDetailEntity { Team = _dataContex.Teams.FirstOrDefault(t => t.Name == "Brasil") },
                                 new GroupDetailEntity { Team = _dataContex.Teams.FirstOrDefault(t => t.Name == "Venezuela") },
                                 new GroupDetailEntity { Team = _dataContex.Teams.FirstOrDefault(t => t.Name == "USA") },
                                 new GroupDetailEntity { Team = _dataContex.Teams.FirstOrDefault(t => t.Name == "Peru") }
                             },
                             Matches = new List<MatchEntity>
                             {
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(2).AddHours(14),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Brasil"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Venezuela")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(2).AddHours(17),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "USA"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Peru")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(6).AddHours(14),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Brasil"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "USA")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(6).AddHours(17),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Venezuela"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Peru")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(11).AddHours(16),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Peru"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Brasil")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(11).AddHours(16),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Venezuela"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "USA")
                                 }
                             }
                        },
                        new GroupEntity
                        {
                             Name = "D",
                             GroupDetails = new List<GroupDetailEntity>
                             {
                                 new GroupDetailEntity { Team = _dataContex.Teams.FirstOrDefault(t => t.Name == "Uruguay") },
                                 new GroupDetailEntity { Team = _dataContex.Teams.FirstOrDefault(t => t.Name == "Bolivia") },
                                 new GroupDetailEntity { Team = _dataContex.Teams.FirstOrDefault(t => t.Name == "Costa Rica") },
                                 new GroupDetailEntity { Team = _dataContex.Teams.FirstOrDefault(t => t.Name == "Honduras") }
                             },
                             Matches = new List<MatchEntity>
                             {
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(3).AddHours(14),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Uruguay"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Bolivia")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(3).AddHours(17),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Costa Rica"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Honduras")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(7).AddHours(14),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Uruguay"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Costa Rica")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(7).AddHours(17),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Bolivia"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Honduras")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(12).AddHours(16),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Honduras"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Uruguay")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(12).AddHours(16),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Bolivia"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Costa Rica")
                                 }
                             }
                        }
                    }
                });

                startDate = DateTime.Today.AddMonths(1).ToUniversalTime();
                endDate = DateTime.Today.AddMonths(4).ToUniversalTime();

                _dataContex.Tournaments.Add(new TournamentEntity
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    IsActive = true,
                    LogoPath = "wwwroot\\images\\Tournaments\\Liga Aguila 2020-I.png",
                    Name = "Liga Aguila 2020-I",
                    Groups = new List<GroupEntity>
                    {
                        new GroupEntity
                        {
                             Name = "A",
                             GroupDetails = new List<GroupDetailEntity>
                             {
                                 new GroupDetailEntity { Team = _dataContex.Teams.FirstOrDefault(t => t.Name == "America") },
                                 new GroupDetailEntity { Team = _dataContex.Teams.FirstOrDefault(t => t.Name == "Bucaramanga") },
                                 new GroupDetailEntity { Team = _dataContex.Teams.FirstOrDefault(t => t.Name == "Junior") },
                                 new GroupDetailEntity { Team = _dataContex.Teams.FirstOrDefault(t => t.Name == "Medellin") }
                             },
                             Matches = new List<MatchEntity>
                             {
                                 new MatchEntity
                                 {
                                     Date = startDate.AddHours(14),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "America"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Bucaramanga")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddHours(17),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Junior"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Medellin")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(4).AddHours(14),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "America"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Junior")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(4).AddHours(17),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Bucaramanga"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Medellin")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(9).AddHours(14),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Medellin"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "America")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(9).AddHours(17),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Bucaramanga"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Junior")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(15).AddHours(14),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Bucaramanga"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "America")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(15).AddHours(17),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Medellin"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Junior")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(19).AddHours(14),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Junior"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "America")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(19).AddHours(17),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Medellin"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Bucaramanga")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(19).AddHours(14),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "America"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Medellin")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(19).AddHours(17),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Junior"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Bucaramanga")
                                 }
                             }
                        },
                        new GroupEntity
                        {
                             Name = "B",
                             GroupDetails = new List<GroupDetailEntity>
                             {
                                 new GroupDetailEntity { Team = _dataContex.Teams.FirstOrDefault(t => t.Name == "Millonarios") },
                                 new GroupDetailEntity { Team = _dataContex.Teams.FirstOrDefault(t => t.Name == "Nacional") },
                                 new GroupDetailEntity { Team = _dataContex.Teams.FirstOrDefault(t => t.Name == "Once Caldas") },
                                 new GroupDetailEntity { Team = _dataContex.Teams.FirstOrDefault(t => t.Name == "Santa Fe") }
                             },
                             Matches = new List<MatchEntity>
                             {
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(1).AddHours(14),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Millonarios"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Nacional")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(1).AddHours(17),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Once Caldas"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Santa Fe")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(5).AddHours(14),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Millonarios"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Once Caldas")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(5).AddHours(17),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Nacional"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Santa Fe")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(10).AddHours(16),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Santa Fe"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Millonarios")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(10).AddHours(16),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Nacional"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Once Caldas")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(16).AddHours(14),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Nacional"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Millonarios")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(16).AddHours(17),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Santa Fe"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Once Caldas")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(20).AddHours(14),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Once Caldas"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Millonarios")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(20).AddHours(17),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Santa Fe"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Nacional")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(35).AddHours(16),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Millonarios"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Santa Fe")
                                 },
                                 new MatchEntity
                                 {
                                     Date = startDate.AddDays(35).AddHours(16),
                                     Local = _dataContex.Teams.FirstOrDefault(t => t.Name == "Once Caldas"),
                                     Visitor = _dataContex.Teams.FirstOrDefault(t => t.Name == "Nacional")
                                 }
                             }
                        }
                    }
                });

                
                await _dataContex.SaveChangesAsync();
            }
        }
        private List<Photo> LoadPhotos()
        {
            return new List<Photo>
            {
                new Photo { Firstname = "Adala", Lastname = "Samir", Image = "Adala.jpg" },
                new Photo { Firstname = "Amalia", Lastname = "Lopez", Image = "Amalia.jpg" },
                new Photo { Firstname = "Camila", Lastname = "Cardona", Image = "Camila.jpg" },
                new Photo { Firstname = "Carolina", Lastname = "Echavarria", Image = "Carolina.jpg" },
                new Photo { Firstname = "Claudia", Lastname = "Sanchez", Image = "Claudia.jpg" },
                new Photo { Firstname = "Gilberto", Lastname = "Medez", Image = "Gilberto.jpg" },
                new Photo { Firstname = "Jhon", Lastname = "Smith", Image = "Jhon.jpg" },
                new Photo { Firstname = "Ken", Lastname = "Rogers", Image = "Ken.jpg" },
                new Photo { Firstname = "Laura", Lastname = "Zuluaga", Image = "Laura.jpg" },
                new Photo { Firstname = "Luisa", Lastname = "Zapata", Image = "Luisa.jpg" },
                new Photo { Firstname = "Manuel", Lastname = "Rodriguez", Image = "Manuel.jpg" },
                new Photo { Firstname = "Manuela", Lastname = "Ateortua", Image = "Manuela.jpg" },
                new Photo { Firstname = "Mario", Lastname = "Bedoya", Image = "Mario.jpg" },
                new Photo { Firstname = "Monica", Lastname = "Cano", Image = "Monica.jpg" },
                new Photo { Firstname = "Pedro", Lastname = "Correa", Image = "Pedro.jpg" },
                new Photo { Firstname = "Penelope", Lastname = "Arias", Image = "Penelope.jpg" },
                new Photo { Firstname = "Pepe", Lastname = "Lopez", Image = "Pepe.jpg" },
                new Photo { Firstname = "Raul", Lastname = "Matinez", Image = "Raul.jpg" },
                new Photo { Firstname = "Roberto", Lastname = "Rivas", Image = "Roberto.jpg" },
                new Photo { Firstname = "Rosa", Lastname = "Velasquez", Image = "Rosa.jpg" },
                new Photo { Firstname = "Rosario", Lastname = "Sandoval", Image = "Rosario.jpg" },
                new Photo { Firstname = "Sandra", Lastname = "Machado", Image = "Sandra.jpg" },
                new Photo { Firstname = "Sandro", Lastname = "Ruiz", Image = "Sandro.jpg" },
                new Photo { Firstname = "Teresa", Lastname = "Santamaria", Image = "Teresa.jpg" }
            };
        }



        private class Photo
        {
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public string Image { get; set; }
        }
    }
}
