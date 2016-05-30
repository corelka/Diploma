using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.ViewModels
{
    public class LectureNoteViewModel
    {
        public string Name { get; set; }
        public int Course { get; set; }
        public string Subject { get; set; }
        public IFormFile Attachment { get; set; }
    }
}
