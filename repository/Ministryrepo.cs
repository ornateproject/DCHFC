using Microsoft.AspNetCore.Mvc.Rendering;

namespace ssc.repository
{
    public class Ministryrepo
    {

        public IEnumerable<SelectListItem> Getrecord()
        {
            List<SelectListItem> ministry = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = null,
                    Text = " "
                }
            };
            return ministry;
        }
    }
}

