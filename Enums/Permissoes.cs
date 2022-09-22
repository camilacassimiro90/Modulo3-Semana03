using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Xml.Serialization;

namespace RH.Enums
{
  public enum Permissoes
  {
    [XmlEnumAttribute("F")]
    [Display(Name = "Funcionário")]
    Funcionario = 1,
    [XmlEnumAttribute("G")]
    [Display(Name = "Gerente")]
    Gerente,
    [XmlEnumAttribute("A")]
    [Display(Name = "Adm")]
    Adm
  }

  public static class EnumExtensions
  {
    public static string GetName(this Enum enumValue)
    {
      string displayName;
      displayName = enumValue.GetType()
        .GetMember(enumValue.ToString())
        .First()
        ?.GetCustomAttribute<DisplayAttribute>()
        ?.GetName();

      if (String.IsNullOrEmpty(displayName))
      {
        displayName = enumValue.ToString();
      }
      return displayName;
    }
  }
}