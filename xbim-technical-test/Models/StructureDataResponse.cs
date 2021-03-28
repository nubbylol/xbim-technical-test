using System.Net;
using xbim_technical_test.Interfaces;

namespace xbim_technical_test.Models
{
    public class StructureDataResponse : IStructureResponse
    {
        public StructureDataResponse(HttpStatusCode statusCode, StructureData data)
        {
            StatusCode = statusCode;
            Data = data;
        }

        public HttpStatusCode StatusCode { get; }
        public StructureData Data { get; }
    }
}