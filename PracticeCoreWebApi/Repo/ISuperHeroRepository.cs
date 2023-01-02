using PracticeCoreWebApi.Model;

namespace PracticeCoreWebApi.Repo
{
    public interface ISuperHeroRepository
    {
        Task<CommonResponseStatus> AddSuperHeroDetail(SuperHero newSuperHero);
        Task<CommonResponseStatus> UpdateSuperHeroDetail(SuperHero newSuperHero);
        Task<SuperHeroResponseModel> GetAllSuperHeroDetail();
        Task<SuperHeroResponseModel> GetSuperHeroById(int id);
        Task<CommonResponseStatus> DeleteSuperHero(int id);

    }
}
