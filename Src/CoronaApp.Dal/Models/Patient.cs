using System.ComponentModel.DataAnnotations;

namespace CoronaApp.Dal.Models;
public class Patient
{
    [RegularExpression("^[0-9]{9}$")]
    public string Id { get; set; }
    [MinLength(2)]
    public string Name { get; set; }
    [Range(0,120)]
    public int Age { get; set; }
}