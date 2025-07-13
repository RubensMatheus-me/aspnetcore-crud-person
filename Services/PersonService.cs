using crud_person_c_.Models;
using crud_person_c_.Repositories;

namespace crud_person_c_.Services;

public class PersonService
{
    private readonly IPersonRepository _repository;

    public PersonService(IPersonRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Person>> GetAllAsync()
    {
        return _repository.GetAllAsync();
    }

    public Task<Person?> GetByIdAsync(long id)
    {
        return _repository.GetByIdAsync(id);
    }

    public Task CreatePersonAsync(Person person)
    {
        return _repository.CreatePersonAsync(person);
    }

    public Task UpdatePersonAsync(long id, Person person)
    {
        return _repository.UpdatePersonAsync(id, person);
    }

    public Task DeletePersonAsync(long id)
    {
        return _repository.DeletePersonAsync(id);
    }
}