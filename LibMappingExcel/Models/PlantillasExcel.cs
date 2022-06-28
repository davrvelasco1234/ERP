


using System.Collections.ObjectModel;


namespace LibMappingExcel.Models
{
    public class PlantillasExcel
    {
        public int Id { get; set; }
        public string Proyecto { get; set; }
        public string Descripcion { get; set; }
        public MappingExcel MappingExcel { get; set; }
    }



    public class MappingExcel
    {
        public int RenglonInicial { get; set; }
        public int MaximoRenglones { get; set; }
        public int NumeroConlumnas { get; set; }
        public int MaximoColumnas { get; set; }
        public ObservableCollection<Propiedades> PropiedadesList { get; set; }
        
    }


    public class Propiedades
    {
        public string Propiedad { get; set; }
        public string Alias { get; set; }
        public int ColumnaExcel { get; set; }
        public string Comentario { get; set; }
        public ObservableCollection<ValorPropiedades> ValorPropiedadesList { get; set; }
        public FormatDate FormatDate { get; set; }

        public ValorDefault ValorDefault { get; set; }
        internal Propiedades Clone()
        {
            Propiedades clonedObject = (Propiedades)this.MemberwiseClone();
            clonedObject.FormatDate = clonedObject.FormatDate.Clone();
            ObservableCollection<ValorPropiedades> valorPropiedades = new ObservableCollection<ValorPropiedades>();
            foreach(ValorPropiedades valorPropiedad in clonedObject.ValorPropiedadesList)
            {
                valorPropiedades.Add(valorPropiedad.Clone());
            }
            clonedObject.ValorPropiedadesList = valorPropiedades;
            clonedObject.ValorDefault = clonedObject.ValorDefault.Clone();
            return (Propiedades)clonedObject;
        }
    }


    public class ValorPropiedades
    {
        public string Propiedad { get; set; }
        public string Valor { get; set; }
        internal ValorPropiedades Clone()
        {
            return (ValorPropiedades)this.MemberwiseClone();
        }
    }

    public class FormatDate
    {
        public bool IsDate { get; set; }
        public string InputFormatDate { get; set; }
        public string OutputFormatDate { get; set; }
        internal FormatDate Clone()
        {
            return (FormatDate)this.MemberwiseClone();
        }

    }

    public class ValorDefault
    { 
        public bool IsRequired { get; set; }
        public string Valor { get; set; }

        internal ValorDefault Clone()
        {
            return (ValorDefault)this.MemberwiseClone();
        }
    }
}
