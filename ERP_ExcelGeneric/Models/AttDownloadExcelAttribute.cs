using System;

namespace ERP_ExcelGeneric.Models
{

    public class AttDownloadExcelAttribute : Attribute
    {
        /// <summary>
        /// es el titulo que se le dara a la columna en excel si no tiene alias se tomara el nombre de la propiedad
        /// </summary>
        public string AliasProperty;
        /// <summary>
        /// indica si se migrara a excel o no
        /// </summary>
        public bool IsVisible = true;
        /// <summary>
        /// indica si se le dara o no formato a la propiedad
        /// </summary>
        public bool ApplyFormating = true;
        /// <summary>
        /// se utiliza para crear columnas vacias
        /// </summary>
        public bool IsColumnEmpty = false;

        /// <summary>
        /// se utiliza solo para archivos TXT, Longitud del texto
        /// </summary>
        public int LengthString = 0;
        /// <summary>
        /// se utiliza solo para archivos TXT, Caracter que se utilizara para rellenar los espacios
        /// </summary>
        public char FillWith = ' ';
        /// <summary>
        /// se utiliza solo para archivos TXT, Indica de que lado rellenara el texto
        /// </summary>
        public LeftRigh LeftRigh = LeftRigh.Right;
    }
}
