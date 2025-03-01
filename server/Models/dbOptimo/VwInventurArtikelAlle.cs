using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptimoWork.Models.DbOptimo
{
  [Table("vwInventurArtikelAlle")]
  public partial class VwInventurArtikelAlle
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
    public int ZeilenNr
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
    public string Einheit
    {
      get;
      set;
    }
    public string ArtikelStatus
    {
      get;
      set;
    }
    public double? Einstandspreis
    {
      get;
      set;
    }
    public int? Lagerbestand
    {
      get;
      set;
    }
    public string Notiz
    {
      get;
      set;
    }
  }
}
