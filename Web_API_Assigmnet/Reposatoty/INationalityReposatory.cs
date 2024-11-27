using Web_API_Assigmnet.DTOS;

namespace Web_API_Assigmnet.Reposatoty
{
    public interface INationalityReposatory
    {
        bool Add(NationalityDTO nationalitydto);
        bool Delete(int  id);   
    }
}
