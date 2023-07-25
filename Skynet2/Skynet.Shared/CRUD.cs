using java.beans;

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

        public void Update(Person person) 
        {
            var personQuery = databaseContext.Persons.First(currentPerson => currentPerson.Cpf == person.Cpf);
            
            personQuery.Name = person.Name;
            personQuery.Cpf = person.Cpf;
            personQuery.Birthdate = person.Birthdate;
            personQuery.Pai = person.Pai;
            personQuery.Mae = person.Mae;
            personQuery.Pac = person.Pac;

            databaseContext.SaveChanges();
        }

        public void Delete(Person person)
        {
            databaseContext.Remove(person);
            databaseContext.SaveChanges();
            MessageBox.Show("Cliente removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);            
        }

        public FormattableString ReadPersonTable() => $"select * from persons;";
    }
}
