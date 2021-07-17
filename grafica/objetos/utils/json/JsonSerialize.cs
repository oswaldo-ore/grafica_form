using grafica.objetos.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace grafica.objetos.utils.json
{
    class JsonSerialize
    {
        public static String toJson(Accion accion)
        {
            return JsonConvert.SerializeObject(accion,Formatting.Indented);
        }

        public static Accion fromJsonToAccion(String accion)
        {
            return JsonConvert.DeserializeObject<Accion>(accion);
        }

        public static List<Accion> fromJsonToListAccion(String listAccionJson)
        {
            return JsonConvert.DeserializeObject<List<Accion>>(listAccionJson);
        }

        public static String toJsonListAccion(List<Accion> listAccionJson)
        {
            return JsonConvert.SerializeObject(listAccionJson);
        }

        public static List<Accion> readLibreto(String dir)
        {
            String libreto;
            using (var reader = new StreamReader(dir))
            {
                libreto = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<Accion>>(dir);
        }

        public static void saveLibreto(String name,List<Accion>accion)
        {
            String direccion = "../../assets/" + name + ".json";
            System.IO.File.WriteAllText(direccion,toJsonListAccion(accion));
            Console.WriteLine("se guardo correctamente");
        }
    }
}
