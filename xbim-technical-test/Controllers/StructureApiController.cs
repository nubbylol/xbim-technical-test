using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using xbim_technical_test.Interfaces;
using xbim_technical_test.Models;

namespace xbim_technical_test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StructureApiController : ControllerBase
    {
        private readonly IStructure _structure;

        // public StructureApiController()
        // {
        //     _structure = new HouseStructure();
        // }
        
        public StructureApiController(IStructure structure)
        {
            _structure = structure;
        }
        
        [HttpGet]
        [Route("GetData")]
        public StructureDataResponse GetData()
        {
            try
            {
                return new StructureDataResponse(HttpStatusCode.OK, _structure.GetStructureData());
            }
            catch (Exception e)
            {
                return new StructureDataResponse(HttpStatusCode.FailedDependency, new StructureData(0, 0, 0));
            }
        }
        
        [HttpGet]
        [Route("GetRooms")]
        public StructureRoomsResponse GetRooms()
        {
            try
            {
                return new StructureRoomsResponse(HttpStatusCode.OK, _structure.GetStructureRooms());
            }
            catch (Exception e)
            {
                return new StructureRoomsResponse(HttpStatusCode.FailedDependency, new List<StructureRoom>());
            }
        }
    }
}
