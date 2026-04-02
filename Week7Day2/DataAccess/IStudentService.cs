namespace StudentDemo.DataAccess
{
    public interface IStudentService<TEntity>
    {
       public  List<TEntity> GetAllStudents();
        public bool AddStudent(TEntity entity);
    }
}
