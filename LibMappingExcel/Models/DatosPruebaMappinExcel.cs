
using System.Collections.ObjectModel;

namespace LibMappingExcel.Models
{
    internal class DatosPruebaMappinExcel
    {
        public static MappingExcel DatosPrueba()
        {
            MappingExcel datos = new MappingExcel
            {
                RenglonInicial = 2,
                MaximoRenglones = 0,
                NumeroConlumnas = 15,
                MaximoColumnas = 2000,

                PropiedadesList = new ObservableCollection<Propiedades>
                {
                    new Propiedades
                    {
                        Propiedad = "Propiedad1",
                        ColumnaExcel = 1,
                        ValorPropiedadesList = new ObservableCollection<ValorPropiedades>
                        {
                            new ValorPropiedades { Propiedad = "PROP1", Valor = "1"},
                            new ValorPropiedades { Propiedad = "PROP44", Valor = "44"},
                            new ValorPropiedades { Propiedad = "PROP555", Valor = "555"}
                        },
                    },
                    new Propiedades
                    {
                        Propiedad = "Propiedad2",
                        ColumnaExcel = 2,
                        ValorPropiedadesList = new ObservableCollection<ValorPropiedades>
                        {
                            new ValorPropiedades { Propiedad = "PROP22", Valor = "22"}
                        },
                    },
                    new Propiedades
                    {
                        Propiedad = "Propiedad88888",
                        ColumnaExcel = 3,
                        ValorPropiedadesList = new ObservableCollection<ValorPropiedades>
                        {
                            new ValorPropiedades { Propiedad = "PROP333", Valor = "333"},
                            new ValorPropiedades { Propiedad = "PROP333", Valor = "333"},
                            new ValorPropiedades { Propiedad = "PROP333", Valor = "333"}
                        },
                    },
                    new Propiedades
                    {
                        Propiedad = "Propiedad999999",
                        ColumnaExcel = 3,
                        ValorPropiedadesList = new ObservableCollection<ValorPropiedades>
                        {
                            new ValorPropiedades { Propiedad = "PROP333", Valor = "3"},
                            new ValorPropiedades { Propiedad = "PROP333", Valor = "33"},
                            new ValorPropiedades { Propiedad = "PROP333", Valor = "333"},
                            new ValorPropiedades { Propiedad = "PROP333", Valor = "3333"},
                            new ValorPropiedades { Propiedad = "PROP333", Valor = "33333"},
                            new ValorPropiedades { Propiedad = "PROP333", Valor = "333333"}
                        },
                    },
                    new Propiedades
                    {
                        Propiedad = "Propiedad2",
                        ColumnaExcel = 2,
                        ValorPropiedadesList = new ObservableCollection<ValorPropiedades>
                        {
                            new ValorPropiedades { Propiedad = "PROP99999", Valor = "99999"}
                        },
                    },
                },
            };

            return datos;
        }
    }
}
