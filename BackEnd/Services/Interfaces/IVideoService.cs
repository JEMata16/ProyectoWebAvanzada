using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface IVideoService
    {
        Task<List<VideoModel>> GetVideos();
        Task<bool> Add(VideoModel video);
        Task<bool> Update(VideoModel video);
        Task<bool> Delete(int id);
        Task<VideoModel> GetVideoById(int id);

    }
}
