namespace MvcTask.Infrastructure.Context.Concrete
{
    using System;
    using System.Data.Entity;

    using MvcTask.Domain.Entities.Concrete;

    public class ContextInitializer : DropCreateDatabaseAlways<EfContext>
    {
        private EfContext context;

        protected override void Seed(EfContext context)
        {
            this.context = context;

            //unique indexes
            this.CreateIndex("Key", typeof(Game));
            this.CreateIndex("Name", typeof(Genre));
            this.CreateIndex("Type", typeof(PlatformType));

            //Data
            context.Genres.Add(
                new Genre
                    {
                        Name = "Strategy",
                        ChildGenres = new[] { new Genre { Name = "RTS" }, new Genre { Name = "TBS" } }
                    });
            context.Genres.Add(
                new Genre
                    {
                        Name = "Races",
                        ChildGenres =
                            new[]
                                {
                                    new Genre { Name = "Rally" }, new Genre { Name = "Arcade" },
                                    new Genre { Name = "Formula" }, new Genre { Name = "Off-road" }
                                }
                    });
            context.Genres.Add(
                new Genre
                    {
                        Name = "Action",
                        ChildGenres =
                            new[]
                                {
                                    new Genre { Name = "FPS" }, new Genre { Name = "TPS" },
                                    new Genre { Name = "Misc" }
                                }
                    });

            context.Genres.Add(new Genre { Name = "RPG" });
            context.Genres.Add(new Genre { Name = "Sports" });
            context.Genres.Add(new Genre { Name = "Adventure" });
            context.Genres.Add(new Genre { Name = "Puzzle&Skill" });

            var moba = context.Genres.Add(new Genre { Name = "MOBA" });

            context.PlatformTypes.Add(new PlatformType { Type = "Mobile" });
            context.PlatformTypes.Add(new PlatformType { Type = "Browser" });
            var desktop = context.PlatformTypes.Add(new PlatformType { Type = "Desktop" });
            context.PlatformTypes.Add(new PlatformType { Type = "Console" });

            var dota =
                context.Games.Add(
                    new Game
                        {
                            Name = "Dota 2",
                            Description = "Just try it",
                            Genres = new[] { moba },
                            Key = "dota-2",
                            PlatformTypes = new[] { desktop }
                        });

            context.Comments.Add(
                new Comment
                    {
                        Game = dota,
                        Name = "FirstAuthor",
                        Body = "Trully amazing one",
                        ChildComments =
                            new[] { new Comment { Name = "SecondAuthor", Game = dota, Body = "Can't disagree" } }
                    });
        }

        private void CreateIndex(string field, Type table)
        {
            var command = String.Format("CREATE UNIQUE INDEX IX_{0} ON [{1}s]([{0}])", field, table.Name);
            this.context.Database.ExecuteSqlCommand(command);
        }
    }
}