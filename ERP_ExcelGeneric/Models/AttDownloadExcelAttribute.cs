﻿using System;

namespace ERP_ExcelGeneric.Models
{
    public class AttDownloadExcelAttribute : Attribute
    {
        public string AliasProperty;
        public bool IsVisible = true;
        public bool ApplyFormating = true;
        public bool IsColumnEmpty = false;
        public int LengthString = 0;

    }
}
