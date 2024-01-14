using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InntoDB 
{
    public class SectionTemplate
    {
        [Key]
        public int SectionTemplateID { get; set; }
        public int SectionID {  get; set; }
        public int SectionFieldNumber { get; set; }
        public string? SectionFieldName { get; set; }
        public SectionFieldTypeEnum SectionFieldType { get; set; }
        public bool IsUnique { get; set; }
    }

    public enum SectionFieldTypeEnum
    {
        Text=0,
        Number=1,
        List=2,
        Picture=3
    }
}
