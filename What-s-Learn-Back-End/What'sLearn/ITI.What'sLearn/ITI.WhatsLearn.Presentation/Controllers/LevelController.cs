using ITI.WhatsLearn.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ITI.WhatsLearn.Presentation.Controllers
{
    public class LevelController : ApiController
    {

        [HttpGet]
        public ResultViewModel<IEnumerable<MainCategoryViewModel>>GetCategories(int PagSize,int PageIndex)
        {
           

        }
    }
}
