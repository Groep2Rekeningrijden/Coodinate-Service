using Coordinate_Service.Data.CoordinatesMongoDb;
using Coordinate_Service.Models;
using RekeningRijden.RabbitMq;

namespace Coordinate_Service.Services
{
    public class CoordinatesServiceLayer : ICoordinatesServiceLayer
    {
        private readonly ICoordsRepository<CoordinatesModel> _coordsRepository;
        

        public CoordinatesServiceLayer(ICoordsRepository<CoordinatesModel> repository)         
        {
            _coordsRepository = repository;        
        }

        public async Task Write(RawInputDTO dto)
        {
            CoordinatesModel document = new CoordinatesModel(dto.VehicleId);
            List<Coordinates> coordinates = new List<Coordinates>();
            
            foreach (CoordinatesDTO cord in dto.Coordinates)
            {
                coordinates.Add(new Coordinates
                {
                    Lat = cord.Lat,
                    Long = cord.Lon,
                    TimeStamp = cord.Time
                });
            }

            document.Cords = coordinates;

            try
            {
                if (_coordsRepository.VehicleIdExists(dto.VehicleId))
                {
                    await _coordsRepository.UpdateArray(document);
                }
                else
                {
                    await _coordsRepository.InsertOneAsync(document);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void test()
        {








        }










    }
}
