using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models.Repository;

namespace WebApplication1.Models.DataManager
{
    public class PersonsManager : IDataRepository<persons>
    {
        readonly PersonsContext _personsContext;

        public PersonsManager(PersonsContext context)
        {
            _personsContext = context;
        }

        public IEnumerable<persons> GetAll()
        {
            return _personsContext.persons.ToList();
        }

        public persons Get(long id)
        {
            return _personsContext.persons
                  .FirstOrDefault(e => e.EmployeeId == id);
        }

        public void Add(persons entity)
        {
            _personsContext.persons.Add(entity);
            _personsContext.SaveChanges();
        }

        public void Update(persons employee, persons entity)
        {
            employee.FirstName = entity.FirstName;
            employee.LastName = entity.LastName;
        

            _personsContext.SaveChanges();
        }

        public void Delete(persons persons)
        {
            _personsContext.persons.Remove(persons);
            _personsContext.SaveChanges();
        }
    }
}