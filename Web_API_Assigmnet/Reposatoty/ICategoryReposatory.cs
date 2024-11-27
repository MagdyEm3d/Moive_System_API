using Web_API_Assigmnet.DTOS;

namespace Web_API_Assigmnet.Reposatoty
{
    public interface ICategoryReposatory
    {
        bool Add(CategoryDTO categorydto);
        bool Delete(int id);
    }
}
