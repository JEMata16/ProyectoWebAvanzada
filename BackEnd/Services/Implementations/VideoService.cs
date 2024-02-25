using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class VideoService : IVideoService
    {
        IUnidadDeTrabajo _unidad;

        public VideoService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidad = unidadDeTrabajo;
        }

        VideoModel Convertir (Video video)
        {
            return new VideoModel { 
                VideoId = video.VideoId,
                Titulo = video.Titulo,
                Url = video.Url,
                CursoId = video.CursoId,
            };
        }

        Video Convertir(VideoModel video)
        {
            return new Video
            {
                VideoId = video.VideoId,
                Titulo = video.Titulo,
                Url = video.Url,
                CursoId = video.CursoId,
            };
        }


        public Task<bool> Add(VideoModel video)
        {
            _unidad._videoDAL.Add(Convertir(video));
            var resultVideo = _unidad.Complete();
            return Task.FromResult(resultVideo);
        }

        public Task<bool> Delete(int id)
        {
            Video video = new Video { VideoId = id };
            _unidad._videoDAL.Remove(video);
            var resultVideo = _unidad.Complete();
            return Task.FromResult(resultVideo);
        }

        public Task<VideoModel> GetVideoById(int id)
        {
            Video video = _unidad._videoDAL.Get(id);
            return Task.FromResult(Convertir(video));
        }

        public Task<List<VideoModel>> GetVideos()
        {
            var videos = _unidad._videoDAL.GetAll();
            List<VideoModel> listaVideos = new List<VideoModel>();
            foreach (var video in videos)
            {
                listaVideos.Add(Convertir(video));
            }
            return Task.FromResult(listaVideos);
        }

        public Task<bool> Update(VideoModel video)
        {
            _unidad._videoDAL.Update(Convertir(video));
            var resultVideo = _unidad.Complete();
            return Task.FromResult(resultVideo);
        }
    }
}
