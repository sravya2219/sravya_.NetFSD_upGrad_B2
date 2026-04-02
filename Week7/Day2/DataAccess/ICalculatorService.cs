namespace StudentDemo.DataAccess
{
    public interface ICalculatorService<TEntity>
    {
        public List<TEntity> GetAllData();
        public TEntity Add(TEntity model);
        public TEntity Subtract(TEntity model);
        public TEntity Multiple(TEntity model);
        public TEntity Divide(TEntity model);


    }
}
