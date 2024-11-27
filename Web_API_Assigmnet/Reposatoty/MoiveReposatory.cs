using Microsoft.EntityFrameworkCore;
using Web_API_Assigmnet.Connection;
using Web_API_Assigmnet.DTOS;
using Web_API_Assigmnet.Models;

namespace Web_API_Assigmnet.Reposatoty
{
    public class MoiveReposatory:IMoiveReposatory
    {
        private readonly ApplicationDbContext _context;

        public MoiveReposatory(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddAll(MoiveDTO moivedto)
        {
            try
            {
                var existmoive = _context.Moives.FirstOrDefault(x => x.Title == moivedto.Title);
                if (existmoive != null)
                    return false;

                var moive = new Moive
                {
                    Title = moivedto.Title,
                    ReleaseYear = moivedto.ReleaseYear,
                    Directors = moivedto.DirectorDTOs.Select(x => new Director
                    {
                        Name = x.Name,
                        Email = x.Email,
                        Contact = x.Contact,
                        Nationality = new Nationality
                        {
                            Name = x.Name,
                        }

                    }).ToList(),
                    Category = new Category
                    {
                        Name = moivedto.CategoryDTO.Name
                    }



                };

                _context.Moives.Add(moive);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error{ex.Message}");
            }
        }

        public IEnumerable<object> GetAll()
        {
            try
            {
                return _context.Moives.Include(x => x.Directors).ThenInclude(x => x.Nationality)
                    .Include(x => x.Category).Select(x => new
                    {
                        Title = x.Title,
                        ReleaseYear = x.ReleaseYear,
                        Directors = x.Directors.Select(x => new
                        {
                            Name = x.Name,
                            Nationality = x.Nationality.Name,

                        }).ToList(),
                        Category = new Category
                        {
                            Name = x.Category.Name,


                        },

                    }).ToList();
            }catch(Exception ex)
            {
                throw new Exception($"Error{ex.Message}");
            }

        }

        public object GetMoive(int id)
        {
            try
            {
                return _context.Moives.Include(x => x.Directors).ThenInclude(x => x.Nationality).
                Include(x => x.Category).Where(x => x.MoiveId == id).Select(x => new
                {
                    Title = x.Title,
                    ReleaseYear = x.ReleaseYear,
                    Directors = x.Directors.Select(x => new
                    {
                        DirectorName = x.Name,
                        Email = x.Email,
                        Contact = x.Contact,
                        Nationality = x.Nationality.Name,
                    }).ToList(),
                    Category = x.Category.Name,
                }).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw new Exception($"Error{ex.Message}");
            }
        }
    }
}
