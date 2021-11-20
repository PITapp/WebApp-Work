using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptimoWork.Models.DbOptimo
{
  [Table("vwInventurArtikel")]
  public partial class VwInventurArtikel
  {
    public int ArtikelID
    {
      get;
      set;
    }
    [Key]
    public int InventurID
    {
      get;
      set;
    }
    public string Artikelnummer
    {
      get;
      set;
    }
    public string Beschreibung
    {
      get;
      set;
    }
    public string Beschreibung2
    {
      get;
      set;
    }
    public string StdKreditorName
    {
      get;
      set;
    }
    public Int64 AnzahlErfasst
    {
      get;
      set;
    }
  }
}
