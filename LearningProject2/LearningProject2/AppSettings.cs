using System.ComponentModel.DataAnnotations;

namespace LearningProject2.Properties;

public class AppSettings
{
    [Required] public string CONNECTION_STRING_DB { get; set; }


}