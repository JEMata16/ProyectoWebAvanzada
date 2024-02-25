using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class RatingService : IRatingService
    {
        IUnidadDeTrabajo _unidad;

        public RatingService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidad = unidadDeTrabajo;
        }
        RatingModel Convertir (Rating rating)
        {
            return new RatingModel { 
            RatingId=rating.RatingId,
            CursoId=rating.CursoId,
            Rating1=rating.Rating1, 
            };
        }
        Rating Convertir(RatingModel rating)
        {
            return new Rating
            {
                RatingId = rating.RatingId,
                CursoId = rating.CursoId,
                Rating1 = rating.Rating1,
            };
        }
        public Task<bool> Add(RatingModel rating)
        {
            _unidad._ratingDAL.Add(Convertir(rating));
            var resultRating = _unidad.Complete();
            return Task.FromResult(resultRating);
        }

        public Task<bool> Delete(int id)
        {
            Rating rating = new Rating { RatingId = id };
            _unidad._ratingDAL.Remove(rating);
            var resultRating = _unidad.Complete();
            return Task.FromResult(resultRating);
        }

        public Task<RatingModel> GetRatingById(int id)
        {
            Rating rating = _unidad._ratingDAL.Get(id);
            return Task.FromResult(Convertir(rating));
        }

        public Task<List<RatingModel>> GetRatings()
        {
            var ratings = _unidad._ratingDAL.GetAll();
            List<RatingModel> listaRatings = new List<RatingModel>();
            foreach (var rating in ratings)
            {
                listaRatings.Add(Convertir(rating));
            }
            return Task.FromResult(listaRatings);
        }

        public Task<bool> Update(RatingModel rating)
        {
            _unidad._ratingDAL.Update(Convertir(rating));
            var resultRating = _unidad.Complete();
            return Task.FromResult(resultRating);
        }
    }
}
