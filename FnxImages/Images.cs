using System;

namespace FnxImages
{
    public class Images
    {
        
        static Images()
        {
            

            //GetIcon16 = new ReadResource(Resources16.ResourceManager);
            //GetIcon24 = new ReadResource(Resources24.ResourceManager);
            //GetIcon32 = new ReadResource(Resources32.ResourceManager);
            //GetIcon48 = new ReadResource(Resources48.ResourceManager);
        }

        //public static ReadResource GetIcon16 { get; }
        //public static ReadResource GetIcon24 { get; }
        //public static ReadResource GetIcon32 { get; }
        //public static ReadResource GetIcon48 { get; }


            /*
        public static System.Drawing.Bitmap GetImgAccept        => ((System.Drawing.Bitmap)(Resources.ResourceManager.GetObject("accept")));
        public static System.Drawing.Bitmap GetImgAdd           => ((System.Drawing.Bitmap)(Resources.ResourceManager.GetObject("add")));
        public static System.Drawing.Bitmap GetImgBook          => ((System.Drawing.Bitmap)(Resources.ResourceManager.GetObject("book")));
        public static System.Drawing.Bitmap GetImgClean         => ((System.Drawing.Bitmap)(Resources.ResourceManager.GetObject("clean")));
        public static System.Drawing.Bitmap GetImgLogoFinamex   => ((System.Drawing.Bitmap)(Resources.ResourceManager.GetObject("finamex_azul")));
        public static System.Drawing.Bitmap GetImgGetOut        => ((System.Drawing.Bitmap)(Resources.ResourceManager.GetObject("getOut")));
        public static System.Drawing.Bitmap GetImgGoUp          => ((System.Drawing.Bitmap)(Resources.ResourceManager.GetObject("goUp")));
        public static System.Drawing.Bitmap GetImgModify        => ((System.Drawing.Bitmap)(Resources.ResourceManager.GetObject("modify")));
        public static System.Drawing.Bitmap GetImgRefresh       => ((System.Drawing.Bitmap)(Resources.ResourceManager.GetObject("refresh")));
        public static System.Drawing.Bitmap GetImgRemove        => ((System.Drawing.Bitmap)(Resources.ResourceManager.GetObject("remove")));
        public static System.Drawing.Bitmap GetImgSave          => ((System.Drawing.Bitmap)(Resources.ResourceManager.GetObject("save")));
        public static System.Drawing.Bitmap GetImgView          => ((System.Drawing.Bitmap)(Resources.ResourceManager.GetObject("view")));
        */
        public static byte[] img => (byte[])Resources.ResourceManager.GetObject("finamex_azul");


        

    }
}
