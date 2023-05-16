using Coordinate_Service.Models.MongoDb;

namespace Coordinate_Service.Models
{
    [BsonCollection("Coordinates")]
    public class CoordinatesModel : Document
    {
        public string VehicleId;

        public List<Coordinates> Cords { get; set; }

        public CoordinatesModel(string id) 
        { 
            VehicleId = id;
            Cords = new List<Coordinates>();     
        }   

    }
}
