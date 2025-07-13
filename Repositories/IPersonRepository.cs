using crud_person_c_.Models;

namespace crud_person_c_.Repositories;

public interface IPersonRepository
{
    Task<IEnumerable<Person>> GetAllAsync();
    Task<Person?> GetByIdAsync(long id);
    Task CreatePersonAsync(Person person);
    Task UpdatePersonAsync(long id, Person person);
    Task DeletePersonAsync(long id);
}