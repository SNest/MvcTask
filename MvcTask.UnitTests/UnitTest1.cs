namespace MvcTask.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using MvcTask.Application.AppServices.Concrete;
    using MvcTask.Application.DTOs.Concrete;
    using MvcTask.Application.Utils;
    using MvcTask.Domain.Abstract.Repositories;
    using MvcTask.Domain.Abstract.UnitOfWork;
    using MvcTask.Domain.Entities.Concrete;
    using MvcTask.Web.Infrastructure.Mapping;

    using NLog;

    [TestClass]
    public class GameTests
    {
        private GameAppService gameAppService;

        private Mock<IGameRepository> gameRepositoryMock;

        private Mock<IGenreRepository> genreRepositoryMock;

        private Mock<ILogger> loggerMock;

        private Mock<IPlatformTypeRepository> platformTypeRepositoryMock;

        private Mock<IUnitOfWork> unitOfWorkMock;

        [TestInitialize]
        public void TestInitializer()
        {
            #region init

            var strategy = new Genre { Id = 1, Name = "Startegy" };

            var rts = new Genre { Id = 2, Name = "RTS" };

            var genres = new[] { strategy, rts };

            var desktop = new PlatformType { Id = 1, Type = "Desktop" };

            var mobile = new PlatformType { Id = 2, Type = "Mobile" };

            var platformTypes = new[] { desktop, mobile };

            var starCraft = new Game
                                {
                                    Id = 1,
                                    Name = "StarCraft",
                                    Description = "Cool game of my childhood",
                                    Key = "StarCraft",
                                    Genres = new[] { strategy },
                                    PlatformTypes = new[] { desktop }
                                };

            var LoL = new Game
                          {
                              Id = 2,
                              Name = "LoL",
                              Description = "Something like dota, but better",
                              Key = "LoL",
                              Genres = new[] { rts },
                              PlatformTypes = new[] { desktop }
                          };

            var Deleted = new Game
                              {
                                  Id = 3,
                                  Name = "Deleted",
                                  Description = "Deleted game",
                                  Key = "Del",
                                  Genres = new[] { strategy },
                                  PlatformTypes = new[] { mobile }
                              };

            desktop.Games = new[] { starCraft, LoL };
            mobile.Games = new[] { Deleted };

            var games = new[] { starCraft, LoL, Deleted };

            #endregion

            this.genreRepositoryMock = new Mock<IGenreRepository>();
            this.genreRepositoryMock.Setup(x => x.Get()).Returns(genres);
            this.genreRepositoryMock.Setup(x => x.Get(It.IsAny<long>()))
                .Returns((long id) => genres.FirstOrDefault(g => g.Id == id));

            this.platformTypeRepositoryMock = new Mock<IPlatformTypeRepository>();
            this.platformTypeRepositoryMock.Setup(x => x.Get()).Returns(platformTypes);
            this.platformTypeRepositoryMock.Setup(x => x.Get(It.IsAny<long>()))
                .Returns((long id) => platformTypes.FirstOrDefault(pt => pt.Id == id));
            this.platformTypeRepositoryMock.Setup(x => x.Find(It.IsAny<Func<PlatformType, Boolean>>()))
                .Returns((Func<PlatformType, Boolean> predicate) => platformTypes.Where(predicate));

            this.gameRepositoryMock = new Mock<IGameRepository>();
            this.gameRepositoryMock.Setup(x => x.Get()).Returns(games);
            this.gameRepositoryMock.Setup(x => x.Get(It.IsAny<long>()))
                .Returns((long id) => games.FirstOrDefault(g => g.Id == id));
            this.gameRepositoryMock.Setup(x => x.Find(It.IsAny<Func<Game, Boolean>>()))
                .Returns((Func<Game, Boolean> predicate) => games.Where(predicate));

            this.unitOfWorkMock = new Mock<IUnitOfWork>();
            this.unitOfWorkMock.Setup(x => x.Games).Returns(this.gameRepositoryMock.Object);
            this.unitOfWorkMock.Setup(x => x.Genres).Returns(this.genreRepositoryMock.Object);
            this.unitOfWorkMock.Setup(x => x.PlatformTypes).Returns(this.platformTypeRepositoryMock.Object);

            this.loggerMock = new Mock<ILogger>();
            this.gameAppService = new GameAppService(this.unitOfWorkMock.Object, this.loggerMock.Object);
        }

        [ClassInitialize]
        public static void Initializer(TestContext testContext)
        {
            Mapper.Initialize(
                cfg =>
                    {
                        cfg.AddProfile<ApplicationMappingProfile>();
                        cfg.AddProfile<WebMappingProfile>();
                    });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Get_Game_By_Wrong_Key()
        {
            //Arrange
            const string gameKey = "Wrong_key";

            //Act
            this.gameAppService.GetByKey(gameKey);
        }

        [TestMethod]
        public void Get_Game_By_Right_Key()
        {
            //Arrange
            const string gameKey = "StarCraft";

            //Act
            var game = this.gameAppService.GetByKey(gameKey);

            //Assert

            Assert.AreEqual(1, game.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Get_Games_By_Genre_Id_Zero()
        {
            //Act
            this.gameAppService.GetByGenre(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Get_Games_By_Genre_Id_Less_Zero()
        {
            //Act
            this.gameAppService.GetByGenre(-1);
        }

        [TestMethod]
        public void Get_Games_By_Right_Genre_Id()
        {
            //Arrenge
            const int genreId = 1;

            //Act
            var games = this.gameAppService.GetByGenre(genreId);

            //Assert;
            Assert.AreEqual(2, games.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Get_Games_By_PlatformTypes_Null_Argument()
        {
            //Act
            this.gameAppService.GetByPlatformTypes(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Get_Games_By_Wrong_PlatformTypesList_Zero()
        {
            //Act
            this.gameAppService.GetByPlatformTypes(new List<int> { 0 });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Get_Games_By_Wrong_PlatformTypesList_Less_Zero()
        {
            //Act
            this.gameAppService.GetByPlatformTypes(new List<int> { -1 });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Get_Games_By_Wrong_PlatformTypesList_UnExisting_Id()
        {
            //Act
            this.gameAppService.GetByPlatformTypes(new List<int> { 3 });
        }

        [TestMethod]
        public void Get_Games_By_Right_Arguments()
        {
            //Arrenge
            var IdList = new List<int> { 1, 2 };
            //Act
            var games = this.gameAppService.GetByPlatformTypes(IdList);
            //Assert
            Assert.AreEqual(3, games.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Get_Game_By_Wrong_Id()
        {
            //Act
            this.gameAppService.Get(6);
        }

        [TestMethod]
        public void Get_Game_By_Correct_Id()
        {
            // Arrenge
            const int id = 2;

            //Act
            var game = this.gameAppService.Get(id);

            //Assert
            Assert.AreEqual("LoL", game.Name);
        }

        [TestMethod]
        public void Get_All_Games()
        {
            //Act
            var games = this.gameAppService.Get();

            //Assert
            Assert.AreEqual(3, games.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Edit_Game_Null_Argument()
        {
            //Act
            this.gameAppService.Update(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Edit_Game_With_Existing_Key()
        {
            //Arrange
            var game = new GameDto { Id = 1, Key = "LoL", Name = "StarCraft", Description = "Awesome" };
            //Act
            this.gameAppService.Update(game);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Edit_Game_With_Wrong_Genre()
        {
            //Arrenge
            var game = new GameDto
                           {
                               Id = 1,
                               Key = "StarCraft",
                               Name = "StarCraft",
                               Description = "Awesome",
                               Genres = new List<GenreDto> { new GenreDto() {Id = -1, Name = "Wrong"} }
                           };
            //Act
            this.gameAppService.Update(game);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Edit_Game_With_Wrong_PlatforType()
        {
            //Arrenge
            var game = new GameDto
                           {
                               Id = 1,
                               Key = "StarCraft",
                               Name = "StarCraft",
                               Description = "Awesome",
                               PlatformTypes = new List<PlatformTypeDto>() { new PlatformTypeDto() {Id = 6, Type = "Wrong"}}
                           };
            //Act
            this.gameAppService.Update(game);
        }

        [TestMethod]
        public void Edit_Game_With_Correct_Argument()
        {
            //Arrenge
            var game = new GameDto
                           {
                               Id = 1,
                               Key = "StarCraft2",
                               Name = "StarCraft2",
                               Description = "Awesome",
                               PlatformTypes = new List<PlatformTypeDto>() { new PlatformTypeDto() { Id = 1} },
                               Genres = new List<GenreDto> { new GenreDto() { Id = 2} }
                           };
            //Act
            this.gameAppService.Update(game);
            //Assert
            this.gameRepositoryMock.Verify(x => x.Update(It.IsAny<Game>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Add_Game_Null_Argument()
        {
            //Act
            this.gameAppService.Create(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Add_Game_With_Existing_Key()
        {
            //Arrange
            var game = new GameDto { Key = "LoL", Name = "New", Description = "Awesome" };
            //Act
            this.gameAppService.Create(game);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Add_Game_With_Wrong_Genre()
        {
            //Arrenge
            var game = new GameDto
                           {
                               Id = 1,
                               Key = "New",
                               Name = "New",
                               Description = "Awesome",
                               Genres = new List<GenreDto> { new GenreDto() { Id = 4 } }
                           };
            //Act
            this.gameAppService.Create(game);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Add_Game_With_Wrong_PlatformType()
        {
            //Arrenge
            var game = new GameDto
                           {
                               Key = "New",
                               Name = "New",
                               Description = "Awesome",
                               PlatformTypes = new List<PlatformTypeDto>() { new PlatformTypeDto() { Id = 4 } }
                           };
            //Act
            this.gameAppService.Create(game);
        }

        [TestMethod]
        public void Add_Game_With_Correct_Argument()
        {
            //Arrenge
            var game = new GameDto
                           {
                               Key = "StarCraft2",
                               Name = "StarCraft2",
                               Description = "Awesome",
                               PlatformTypes = new List<PlatformTypeDto>() { new PlatformTypeDto() { Id = 1 } },
                               Genres = new List<GenreDto> { new GenreDto() { Id = 2 } }
                           };
            //Act
            this.gameAppService.Create(game);
            //Assert
            this.gameRepositoryMock.Verify(x => x.Create(It.IsAny<Game>()), Times.Once);
            this.unitOfWorkMock.Verify(x => x.Save(), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Delete_Game_With_Zero_Id()
        {
            //Act
            this.gameAppService.Delete(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Delete_Game_With_Id_Less_Zero()
        {
            //Act
            this.gameAppService.Delete(-1);
        }

        [TestMethod]
        public void Delete_Game_With_Correct_Id()
        {
            //Act
            this.gameAppService.Delete(2);

            //Assert
            this.gameRepositoryMock.Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
        }
    }
}