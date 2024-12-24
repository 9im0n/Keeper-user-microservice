namespace UserMicroservice.Repositories
{
    public interface IBaseRepository<TDbModel> where TDbModel : class
    {
        public ICollection<TDbModel> GetAll();
        public TDbModel GetById(Guid id);
        public TDbModel Create(TDbModel model);
        public TDbModel Update(TDbModel model);
        public void Delete(Guid id);
    }
}
