using System.Collections.Generic;

namespace Course_Manager.Service.Filter
{
    public class CourseValidation
    {
        public IEnumerable<string> Erros{ get; private set; }

        public CourseValidation(IEnumerable<string> erros)
        {
            Erros = erros;
        }
    }
}
