using IBusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class GuidService : IGuidService
    {
        public Guid NewGuid()
        {
            return Guid.NewGuid();
        }
    }
}
