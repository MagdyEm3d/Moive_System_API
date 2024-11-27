using Web_API_Assigmnet.DTOS;

namespace Web_API_Assigmnet.Reposatoty
{
    public interface IMoiveReposatory
    {
        IEnumerable<object> GetAll();
        public object GetMoive(int id);
        bool AddAll(MoiveDTO moivedto);
    }
}
