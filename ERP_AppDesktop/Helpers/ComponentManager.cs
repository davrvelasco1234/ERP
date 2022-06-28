using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using ERP_Core.Components;

namespace ERP_AppDesktop.Helpers
{
    public class ComponentManager
    {

        public static ComponentManager GetComponents() => new ComponentManager(Constantes.RutaComponens);


        [ImportMany(typeof(IComponentERP))]
        public IEnumerable<IComponentERP> Modules { get; set; }

        public ComponentManager(string File)
        {
            try
            {
                var catalog = new AggregateCatalog();
                catalog.Catalogs.Add(new AssemblyCatalog(typeof(ComponentManager).Assembly));
                catalog.Catalogs.Add(new DirectoryCatalog(File, Constantes.ExtensoinComponents));

                CompositionContainer container = new CompositionContainer(catalog);

                var batch = new CompositionBatch();
                batch.AddPart(this);

                container.Compose(batch);
            }
            catch (FileNotFoundException fex)
            {

            }
            catch (CompositionException cex) // Belirtilen yol içerisi boş ise.
            {

            }
            catch (DirectoryNotFoundException dex) // Belirtilen yol doğru değil ise.
            {

            }
        }




    }
}
