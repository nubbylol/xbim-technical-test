using System.Collections.Generic;
using System.Net;
using xbim_technical_test.Interfaces;

namespace xbim_technical_test.Models
{
    public class StructureRoomsResponse : IStructureResponse
    {
        public StructureRoomsResponse(HttpStatusCode statusCode, List<StructureRoom> rooms)
        {
            StatusCode = statusCode;
            Rooms = rooms;
        }

        public HttpStatusCode StatusCode { get; }
        public List<StructureRoom> Rooms { get; }
    }
}