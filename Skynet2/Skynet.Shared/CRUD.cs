namespace Skynet2.Skynet.Shared
{
    public class CRUD
    {
        private DatabaseContext databaseContext = new();

        public void Create(Person person)
        {
            databaseContext.Add(person);
            databaseContext.SaveChanges();
            MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public List<Person> Read(FormattableString sql) => databaseContext.Persons.FromSqlInterpolated(sql).ToList();

        public void Delete(Person person)
        {
            databaseContext.Remove(person);
            databaseContext.SaveChanges();
            MessageBox.Show("Cliente removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);            
        }
    }
}
