using Web_API_Assigmnet.Connection;
using Web_API_Assigmnet.DTOS;
using Web_API_Assigmnet.Models;

namespace Web_API_Assigmnet.Reposatoty
{
    public class CategoryReposatory:ICategoryReposatory
    {
        private readonly ApplicationDbContext _context;

        public CategoryReposatory(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(CategoryDTO categorydto)
        {
           try
            {
                var existcategory = _context.Categories.FirstOrDefault(x => x.Name == categorydto.Name);
                if (existcategory != null)
                    return false;
                var category = new Category
                {
                    Name = categorydto.Name,
                };
                _context.Categories.Add(category);
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
                var category = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
                if (category == null)
                    return false;
                _context.Categories.Remove(category);
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
