namespace MvcTask.Infrastructure.Concrete.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MvcTask.Domain.Abstract.Repositories;
    using MvcTask.Domain.Entities.Concrete;
    using MvcTask.Infrastructure.Context.Abstract;

    public class GameRepository : EfRepository<Game, long>, IGameRepository
    {
        private readonly IContext db;

        public GameRepository(IContext db)
            : base(db)
        {
            this.db = db;
        }

        public override IEnumerable<Game> Find(Func<Game, bool> predicate)
        {
            return this.db.Set<Game, long>().Where(predicate).ToList();
        }
    }
}