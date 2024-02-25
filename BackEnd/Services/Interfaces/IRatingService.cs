using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface IRatingService
    {
        Task<List<RatingModel>> GetRatings();
        Task<bool> Add(RatingModel rating);
        Task<bool> Update(RatingModel rating);
        Task<bool> Delete(int id);
        Task<RatingModel> GetRatingById(int id);

    }
}
