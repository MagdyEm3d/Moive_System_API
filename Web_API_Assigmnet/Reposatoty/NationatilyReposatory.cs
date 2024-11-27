using Web_API_Assigmnet.Connection;
using Web_API_Assigmnet.DTOS;
using Web_API_Assigmnet.Models;

namespace Web_API_Assigmnet.Reposatoty
{
    public class NationatilyReposatory:INationalityReposatory
    {
        private readonly ApplicationDbContext _context;

        public NationatilyReposatory(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(NationalityDTO nationalitydto)
        {
            try
            {
                var existnationality = _context.Nationalities.FirstOrDefault(x => x.Name == nationalitydto.Name);
                if (existnationality != null)
                    return false;
                var nationality = new Nationality
                {
                    Name = nationalitydto.Name,
                };
                _context.Nationalities.Add(nationality);
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
                var nationality = _context.Nationalities.FirstOrDefault(x => x.NationalityId == id);
                if (nationality == null)
                    return false;
                _context.Nationalities.Remove(nationality);
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
