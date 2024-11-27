using Web_API_Assigmnet.Connection;
using Web_API_Assigmnet.DTOS;
using Web_API_Assigmnet.Models;

namespace Web_API_Assigmnet.Reposatoty
{
    public class DirectorReposatory:IDirectorReposatory
    {
        private readonly ApplicationDbContext _context;

        public DirectorReposatory(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddAll(DirectorrDTO directorrdto)
        {
            try
            {
                var existdirectoremail = _context.Directors.FirstOrDefault(x => x.Email == directorrdto.Email);
                if (existdirectoremail != null)
                    return false;
                foreach (var moive in directorrdto.MoiveeDTOs)
                {
                    var existmoive = _context.Moives.FirstOrDefault(x => x.Title == moive.Title);
                    if (existmoive != null)
                        return false;
                }

                var directorr = new Director
                {
                    Name = directorrdto.Name,
                    Email = directorrdto.Email,
                    Contact = directorrdto.Contact,
                    Moives = directorrdto.MoiveeDTOs.Select(x => new Moive
                    {
                        Title = x.Title,
                        ReleaseYear = x.ReleaseYear,
                        Category = new Category
                        {
                            Name = x.CategoryDTO.Name,
                        }
                    }).ToList(),
                    Nationality = new Nationality
                    {
                        Name = directorrdto.NationalityDTO.Name,

                    }


                };
                _context.Directors.Add(directorr);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error{ex.Message}");
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var director = _context.Directors.FirstOrDefault(x => x.DirectorId == id);
                if (director == null)
                    return false;
                _context.Directors.Remove(director);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error{ex.Message}");
            }
        }

        public bool UpdateAll(int id, DirectorrDTO directorrdto)
        {
            try
            {
                var director = _context.Directors.FirstOrDefault(x => x.DirectorId == id);
                if (director == null)
                    return false;
                foreach (var moive in directorrdto.MoiveeDTOs)
                {
                    var existmoive = _context.Moives.FirstOrDefault(x => x.Title == moive.Title);
                    if (existmoive != null)
                        return false; 
                }


                director.Name = directorrdto.Name;
                director.Email = directorrdto.Email;
                director.Contact = directorrdto.Contact;
                director.Moives = directorrdto.MoiveeDTOs.Select(x => new Moive
                {
                    Title = x.Title,
                    ReleaseYear = x.ReleaseYear,
                    Category = new Category
                    {
                        Name = x.CategoryDTO.Name,
                    }
                }).ToList();
                director.Nationality = new Nationality
                {
                    Name = directorrdto.NationalityDTO.Name,

                };


                _context.Directors.Update(director);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error{ex.Message}");
            }
        }
    }
}
