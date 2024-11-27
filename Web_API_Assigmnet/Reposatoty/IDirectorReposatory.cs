using Web_API_Assigmnet.DTOS;

namespace Web_API_Assigmnet.Reposatoty
{
    public interface IDirectorReposatory
    {
        bool AddAll(DirectorrDTO directorrdto);
        bool UpdateAll(int id, DirectorrDTO directorrdto);
        bool Delete(int id);   
    }
}
