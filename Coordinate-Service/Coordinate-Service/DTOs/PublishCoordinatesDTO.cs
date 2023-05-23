using Coordinate_Service.Models;

namespace Coordinate_Service.DTOs
{
    public class PublishCoordinatesDTO
    {
        public string VehicleId;

        public List<Coordinates> Cords { get; set; } = new List<Coordinates>();

    }
}
