using UserMicroservice.Models;
using UserMicroservice.Database;

namespace UserMicroservice.Repositories
{
    public class BaseRepository<TDbModel> : IBaseRepository<TDbModel> where TDbModel : BaseModel
    {
        protected AppDbContext Context { get; set; }
        public BaseRepository(AppDbContext context) 
        {
            Context = context; 
        }


        public virtual ICollection<TDbModel> GetAll()
        {
            return Context.Set<TDbModel>().ToList();
        }


        public virtual TDbModel GetById(Guid id)
        {
            return Context.Set<TDbModel>().FirstOrDefault(m => m.Id == id);
        }


        public virtual TDbModel Create(TDbModel model)
        {
            Context.Set<TDbModel>().Add(model);
            Context.SaveChanges();
            return model;
        }


        public virtual TDbModel Update(TDbModel model)
        {
            TDbModel toUpdate = Context.Set<TDbModel>().FirstOrDefault(m => m.Id == model.Id);

            if (toUpdate != null)
            {
                toUpdate = model;
            }

            Context.Update(toUpdate);
            Context.SaveChanges();

            return toUpdate;
        }


        public virtual void Delete(Guid id)
        {
            TDbModel toDelete = Context.Set<TDbModel>().FirstOrDefault(m => m.Id == id);
            Context.Set<TDbModel>().Remove(toDelete);
            Context.SaveChanges();
        }
    }
}
