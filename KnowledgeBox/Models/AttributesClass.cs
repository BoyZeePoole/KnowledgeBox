using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnowledgeBox.Models
{
    [MetadataTypeAttribute(typeof(ItemMetadata))]
    public partial class Item
    {
    }
    [MetadataTypeAttribute(typeof(ContentMetadata))]
    public partial class ContentType
    {
    }
    [MetadataTypeAttribute(typeof(SubjectMetadata))]
    public partial class Subject
    {
    }

    [MetadataTypeAttribute(typeof(TargetMetadata))]
    public partial class Target
    {
    }
    [MetadataTypeAttribute(typeof(PhaseMetadata))]
    public partial class Phase
    {
    }

    public class ItemMetadata
    {
        [Required(ErrorMessage="The name field is required...")]
        [DisplayName("Name")]
        public string Item_Name { get; set; }

        [Required(ErrorMessage = "The description field is required...")]
        [DisplayName("Description")]
        public string Item_Description { get; set; }

        [Required(ErrorMessage = "The tags field is required...")]
        [DisplayName("Tags")]
        public string Item_TagWords { get; set; }

        [Required(ErrorMessage = "The file  field is required...")]
        [DisplayName("File path")]
        public string Item_FilePath { get; set; }

        [DisplayName("Content Type")]
        public virtual ContentType ContentType { get; set; }

    }
    public class ContentMetadata
    {
        [Required(ErrorMessage = "The content type field is required...")]
        [DisplayName("Description")]
        public string ContentType_Description { get; set; }

        [Required(ErrorMessage = "The content type Thumbnail is Required...")]
        [DisplayName("Thumbnail")]
        public string ContentType_Thumbnail { get; set; }
        
    }

    public class SubjectMetadata
    {
        [Required(ErrorMessage = "The subject field is required...")]
        [DisplayName("Description")]
        public string Subject_Description { get; set; }

        [DisplayName("Thumbnail")]
        public string Subject_Thumbnail { get; set; }

    }
    public class TargetMetadata
    {
        [Required(ErrorMessage = "The target field is required...")]
        [DisplayName("Description")]
        public string Target_Description { get; set; }
    }

    public class PhaseMetadata
    {
        [Required(ErrorMessage = "The phase field is required...")]
        [DisplayName("Description")]
        public string Phase_Description { get; set; }
    }

}