using crud_person_c_.Data;
using crud_person_c_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud_person_c_.Repositories;

public class PersonRepository :IPersonRepository
{
    private readonly AppDbContext _context;

    public PersonRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Person>> GetAllAsync()
    {
        try
        {
            return await _context.People.ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Person?> GetByIdAsync(long id)
    {
        try
        {
            return await _context.People.FindAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task CreatePersonAsync(Person person)
    {
        try
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task UpdatePersonAsync(long id, [FromBody] Person updatedPerson)
    {
        try
        {
            var existPerson = await GetByIdAsync(id);

            if (existPerson == null) throw new Exception("Pessoa não encontrada");
            
            _context.Entry(existPerson).CurrentValues.SetValues(updatedPerson);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task DeletePersonAsync(long id)
    {
        try
        {
            var person = await _context.People.FindAsync(id);
            if (person != null)
            {
                _context.People.Remove(person);
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}