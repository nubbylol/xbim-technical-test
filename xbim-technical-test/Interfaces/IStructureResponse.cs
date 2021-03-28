using System.Net;

namespace xbim_technical_test.Interfaces
{
    public interface IStructureResponse
    {
        HttpStatusCode StatusCode { get; }
    }
}