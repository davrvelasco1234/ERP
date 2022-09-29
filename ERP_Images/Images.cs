using ERP_Images.Helpers;

namespace ERP_Images
{
    public static class Images
    {
        public static GetIcon Icon16 { get; }
        public static GetIcon Icon24 { get; }
        public static GetIcon Icon32 { get; }
        public static GetIcon Icon48 { get; }

        public static GetImages Images16 { get; }
        public static GetImages Images24 { get; }
        public static GetImages Images32 { get; }
        public static GetImages Images48 { get; }

        public static GetLogo Logo200 { get; }
        public static GetLogo Logo400 { get; }
        public static GetLogo Logo600 { get; }
        public static GetLogo Logo800 { get; }

        static Images()
        {
            Icon16 = new GetIcon("_16");
            Icon24 = new GetIcon("_24");
            Icon32 = new GetIcon("_32");
            Icon48 = new GetIcon("_48");

            Images16 = new GetImages("_16");
            Images24 = new GetImages("_24");
            Images32 = new GetImages("_32");
            Images48 = new GetImages("_48");

            Logo200 = new GetLogo("_200");
            Logo400 = new GetLogo("_400");
            Logo600 = new GetLogo("_600");
            Logo800 = new GetLogo("_800");
        }





    }
}
